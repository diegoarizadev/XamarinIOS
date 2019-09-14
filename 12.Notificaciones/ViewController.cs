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


            btnNotificacionesCalendario.TouchUpInside += delegate {


	        };


            btnNotificacionesIntervalo.TouchUpInside += delegate {

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


            };


            btnNotificacionesRespuesta.TouchUpInside += delegate {
	

	        };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}