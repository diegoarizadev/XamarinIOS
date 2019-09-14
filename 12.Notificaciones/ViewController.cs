using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using UserNotifications;

namespace _12.Notificaciones
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnNotificacionesIntervalo.TouchUpInside += delegate {

                Console.WriteLine("N0rf3n - btnNotificacionesIntervalo - Begin ");

                NSUrl ArchivoGif = NSUrl.FromFilename("Notificacion.gif");
                var IdArchivo = "Not";//identificador del archivo
                var OpcionesAdjuntar = new UNNotificationAttachmentOptions();
                var Contenido = new UNMutableNotificationContent();
                Contenido.Title = "Nueva Notificacion";
                Contenido.Subtitle = "Suena la campana.Tirin tirin.. ";
                Contenido.Body = "Notificacion Local";
                Contenido.Sound = UNNotificationSound.Default;
                Contenido.Badge = 1;

                NSError error;

                var Adjuntar = UNNotificationAttachment.FromIdentifier(IdArchivo, ArchivoGif, OpcionesAdjuntar, out error);

                Contenido.Attachments = new UNNotificationAttachment[] { Adjuntar };

                var Disparador = UNTimeIntervalNotificationTrigger.CreateTrigger(10, false); //Se le especifica que tarde 3 segundos.

                var IdSolicitud = "Solicitud"; //id para la notificación

                var Solicitud = UNNotificationRequest.FromIdentifier(IdSolicitud, Contenido, Disparador);

                UNUserNotificationCenter.Current.AddNotificationRequest(Solicitud, (err) => { });

                Console.WriteLine("N0rf3n - btnNotificacionesIntervalo - End ");

            };

            btnNotificacionesCalendario.TouchUpInside += delegate {


                Console.WriteLine("N0rf3n - btnNotificacionesCalendario - Begin ");

                NSUrl ArchivoGif = NSUrl.FromFilename("Notificacion.gif");
                var IdArchivo = "Not";//identificador del archivo
                var OpcionesAdjuntar = new UNNotificationAttachmentOptions();
                var Contenido = new UNMutableNotificationContent();
                Contenido.Title = "Notificacion Calendario";
                Contenido.Subtitle = "Suena la campana.Tirin tirin.. ";
                Contenido.Body = "Notificacion Local";
                Contenido.Sound = UNNotificationSound.Default;
                Contenido.Badge = 1;

                NSError error;

                var Adjuntar = UNNotificationAttachment.FromIdentifier(IdArchivo, ArchivoGif, OpcionesAdjuntar, out error);

                Contenido.Attachments = new UNNotificationAttachment[] { Adjuntar };


                //Se onbtiniene los datos de la fecha, hora y demas información del DatePicker.
                DateTime Fecha = (DateTime)Calendario.Date; //Se parcea la fecha del DatePicker
                DateTime Hora = DateTime.SpecifyKind((DateTime)Calendario.Date, DateTimeKind.Utc).ToLocalTime();

                var ElementoFecha = new NSDateComponents();//Variable para alimentar a la notificacion
                ElementoFecha.Minute = nint.Parse(Hora.Minute.ToString());
                ElementoFecha.Hour = nint.Parse(Hora.Hour.ToString());
                ElementoFecha.Month = nint.Parse(Fecha.Month.ToString());
                ElementoFecha.Year = nint.Parse(Fecha.Year.ToString());
                ElementoFecha.Day = nint.Parse(Fecha.Day.ToString());
                ElementoFecha.TimeZone = NSTimeZone.SystemTimeZone;

                Console.WriteLine(string.Format("N0rf3n - {0}io - ElementoFecha :  ", "btnNotificacionesCalendar") + ElementoFecha);


                var Disparador = UNCalendarNotificationTrigger.CreateTrigger(ElementoFecha, false); //Se le especifica que tarde 3 segundos.

                var IdSolicitud = "Solicitud2"; //id para la notificación

                var Solicitud = UNNotificationRequest.FromIdentifier(IdSolicitud, Contenido, Disparador);

                UNUserNotificationCenter.Current.AddNotificationRequest(Solicitud, (err) => { });

                Console.WriteLine("N0rf3n - btnNotificacionesCalendario - End ");

            };

            UNUserNotificationCenter CentrodeNotificacion =
               UNUserNotificationCenter.Current; //Permite generar categorias

            NSNotificationCenter.DefaultCenter.AddObserver((NSString)//Se debe crear un observador, para que este atento de lo que el usuario esta realizando.
                "NotificacionDeRespuesta", NotificacionDeRespuesta); //la palabra clave será NotificacionDeRespuesta


            btnNotificacionesRespuesta.TouchUpInside += delegate {
                Console.WriteLine("N0rf3n - btnNotificacionesSRespuesta - Begin ");
                Console.WriteLine("N0rf3n - btnTmp - test... ");
                CentrodeNotificacion.Delegate = new Notificacion(); //Es una instancia hacia notificacion.
                Notificacion.Categoria();
                Notificacion.EnviarNotificacion();
                Console.WriteLine("N0rf3n - btnNotificacionesSRespuesta - End ");

            };
        }

        public void NotificacionDeRespuesta(NSNotification Notifica) //Recibe una notificación.
        {
            var ContenidoRespuesta = Notifica.UserInfo.ValueForKey((NSString)"Respuesta"); //a traves del userinfo se extrae la palabra clave de referencia
            lblRespuesta.Text = ContenidoRespuesta.ToString(); //Se va enviar el contenido de la variable ContenidoRespuesta a la pantalla
        }
    }

    //Creación de clase de notificación.
    public class Notificacion : UNUserNotificationCenterDelegate
    {

        //Dentro de la especificación "UNUserNotificationCenterDelegate" se debe agregar dos validaciones o aspectos importantes.

        //1. Validación en caso de que exista una notificación.
        public override void WillPresentNotification(UNUserNotificationCenter center,
                                            UNNotification notification,
                                            Action<UNNotificationPresentationOptions> completionHandler)
        {
            Console.WriteLine("N0rf3n - WillPresentNotification/Notificacion - Begin ");
            completionHandler(UNNotificationPresentationOptions.Alert); //Se mostrar un alert
            Console.WriteLine("N0rf3n - WillPresentNotification/Notificacion - End ");
        }

        //2. Cuando la notificación llegue al centro de notificaciones.
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center,
                                                           UNNotificationResponse response,
                                                           Action completionHandler)
        {
            Console.WriteLine("N0rf3n - DidReceiveNotificationResponse/Notificacion - Begin ");
            //Aqui se recibe la información que viaja en la notificación y dependiendo de la categoria se obtiene el String para enviar a la APp para colocarlo en una etiqueta
            var Respuesta = response as UNTextInputNotificationResponse;

            Console.WriteLine("N0rf3n - DidReceiveNotificationResponse/Notificacion - Respuesta :  " + Respuesta);

            NSNotificationCenter.DefaultCenter.PostNotificationName("NotificacionDeRespuesta", //Esta es la identificación de la notificación
                                                                    this,
                                                                    new NSDictionary("Respuesta", //palabra clave.
                                                                    Respuesta.UserText));

            completionHandler();
            Console.WriteLine("N0rf3n - DidReceiveNotificationResponse/Notificacion - End ");
        }

        //Enviar la notificación.-...
        public static void EnviarNotificacion()
        {

            Console.WriteLine("N0rf3n - EnviarNotificacion/Notificacion - Begin ");

            NSUrl ArchivoGif = NSUrl.FromFilename("Notificacion.gif");
            var IdArchivo = "Not";//identificador del archivo
            var OpcionesAdjuntar = new UNNotificationAttachmentOptions();
            var Contenido = new UNMutableNotificationContent();
            Contenido.Title = "Notificacion Local";
            Contenido.Subtitle = "Suena la campana.Tirin tirin.. ";
            Contenido.Body = "Notificacion Local";
            Contenido.Sound = UNNotificationSound.Default;
            Contenido.Badge = 1;

            //Se agrega la categoria.
            Contenido.CategoryIdentifier = "IdentificadorCategoria";//Se registra la categoria y se puede establecer cuando el usuario realice la escritura, caracteristicas del botón y demas.


            NSError error;

            var Adjuntar = UNNotificationAttachment.FromIdentifier(IdArchivo, ArchivoGif, OpcionesAdjuntar, out error);

            Contenido.Attachments = new UNNotificationAttachment[] { Adjuntar };

            var Disparador = UNTimeIntervalNotificationTrigger.CreateTrigger(5, false); //Se le especifica que tarde 3 segundos.

            var IdSolicitud = "Solicitud3"; //id para la notificación

            var Solicitud = UNNotificationRequest.FromIdentifier(IdSolicitud, Contenido, Disparador);

            UNUserNotificationCenter.Current.AddNotificationRequest(Solicitud, (err) => { });

            Console.WriteLine("N0rf3n - EnviarNotificacion/Notificacion - End ");

        }

        public static void Categoria()
        {

            Console.WriteLine("N0rf3n - EnviarNotificacion/Categoria - Begin ");
            var Accion = new List<UNNotificationAction>();
            var IdAccion = "Responder";
            var Titulo = "Titulo Respuesta";
            var TituloBoton = "Enviar";
            var MarcaAgua = "Ingresa tu respuesta";//PlaceHolder
            var RespuestaAccion = UNTextInputNotificationAction.FromIdentifier(IdAccion, Titulo, UNNotificationActionOptions.None, TituloBoton, MarcaAgua);
            Accion.Add(RespuestaAccion);
            var IdCategoria = "IdentificadorCategoria"; //debe conincidir con el indicado en el envio de la notificacion
            var Acciones = Accion.ToArray();
            var Identificadores = new String[] { };
            var categoria = UNNotificationCategory.FromIdentifier(IdCategoria, Acciones, Identificadores, UNNotificationCategoryOptions.None);//Se adjuntan los elementos de la categoria.
            var categorias = new UNNotificationCategory[] { categoria };

            //Notification Center
            UNUserNotificationCenter.Current.SetNotificationCategories(new NSSet<UNNotificationCategory>(categorias));

            Console.WriteLine("N0rf3n - EnviarNotificacion/Categoria - End ");
        }
    }
}