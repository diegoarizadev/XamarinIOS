using Foundation;
using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using CoreMotion;
using LocalAuthentication;
using System.Threading;

namespace _5.Touch
{
    public partial class ViewController : UIViewController
    {
        CMMotionManager Movimiento; //Utilizar el Acelerometro
        nfloat Altura;
        nfloat Ancho;
        nfloat AnchoCapaa;
        nfloat AlturaCapa;
        nfloat ActualizaX;
        nfloat ActualizaY;
        CALayer CapaImagen
            ;//Capa

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {

            base.ViewDidLoad();

            Console.WriteLine("N0rf3n - ViewDidLoad - Begin");

            try
            {

                Console.WriteLine("N0rf3n - ViewDidLoad - Begin/Try");

                var Verifica = new LAContext(); //Context
                var myReason = new NSString("Autenticación Biométrica");
                var autoriza = await Verifica.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthenticationWithBiometrics,//Await, es un proceso Asyncrono y toca cambiar el  public override void  por ->  public override async void y vamos a usar la validación biometrica.
                    myReason);

                if (autoriza.Item1) //el primer elemento Item1 hace refenrecia al OK y el segundo al error.
                {
                    Console.WriteLine("N0rf3n - ViewDidLoad - Ingreso App - TouchID");

                    //Se establece todo el ancho y altura de la vista de la pantalla
                    Altura = View.Bounds.Width;
                    Ancho = View.Bounds.Height;
                    AnchoCapaa = Altura / 2;
                    Altura = Ancho / 6;
                    CapaImagen = new CALayer(); //Se define una capa nueva.
                    CapaImagen.Bounds = new CGRect(Altura/2 - Ancho,
                                                   Ancho/2 -Altura/2,
                                                   AnchoCapaa,
                                                   AlturaCapa);

                    CapaImagen.Position = new CGPoint(100,100); //Se establece una posición.
                    CapaImagen.Contents = UIImage.FromFile("Tanjiro.jpg").CGImage;
                    View.Layer.AddSublayer(CapaImagen); //Se agrega a la vista la nueva capa
                    var Actualiza = CapaImagen.Frame; //se obtienen los frames de la capa imagen, para obtener las coordenadas
                    Movimiento = new CMMotionManager(); //instancia nueva del movimiento.


                    if(Movimiento.AccelerometerAvailable) //Validar si el dispositivo tiene el acelerometro esta disponible
                    {
                        //Si el aceleremetro esta disposnible le vamos a definir el intervalo para estar verificando los objectos que estan en el view controller

                        Movimiento.AccelerometerUpdateInterval = 0.02;
                        Movimiento.StartAccelerometerUpdates(NSOperationQueue.CurrentQueue, (data, error) =>//Metodo para detectar el movimiento del dispositivo.
                        {
                            //Se capturan las coordenadas de la capa imagen
                            ActualizaX = CapaImagen.Frame.X;
                            ActualizaY = CapaImagen.Frame.Y;

                            if(ActualizaX + (nfloat)data.Acceleration.X * 10 > 0 && //Si el acelerometro se mueve
                                ActualizaX + (nfloat)data.Acceleration.X * 10 < Altura - AnchoCapaa) //para que el objecto se mantega en la vista actual.
                            {

                                //Se actualiza la posicion.
                                Actualiza.X = ActualizaX + (nfloat)data.Acceleration.X * 10; // el objeto empieza a tener movimiento

                            }

                            if (ActualizaY + (nfloat)data.Acceleration.Y * 10 > 0 && //Si el acelerometro se mueve
                                ActualizaY + (nfloat)data.Acceleration.Y * 10 < Ancho - AlturaCapa) //para que el objecto se mantega en la vista actual.
                            {

                                //Se actualiza la posicion.
                                Actualiza.Y = ActualizaY + (nfloat)data.Acceleration.Y * 10; // el objeto empieza a tener movimiento

                                lblValueX.Text = data.Acceleration.X.ToString("00");
                                lblValueY.Text = data.Acceleration.Y.ToString("00");
                                lblValueZ.Text = data.Acceleration.Z.ToString("00");

                                //Se realiza la actualizaciòn de la capa imagen
                                CapaImagen.Frame = Actualiza; //la variable tiene los valores en X y Z

                            }



                        }
                        ); 
                    }



                }
                else
                {
                   // System.Threading.Thread.CurrentThread.Abort();//Salga de la venta,  la coloque en segundo plano y coloque la App en primer plano
                    Console.WriteLine("N0rf3n - ViewDidLoad - Else");
                    Thread.CurrentThread.Abort();
                }

                Console.WriteLine("N0rf3n - ViewDidLoad - End");

            }
            catch (Exception ex)
            {

                Console.WriteLine("N0rf3n - ViewDidLoad - End/Catch Error : " + ex.Message);

                var alerta = UIAlertController.Create("Estado",
                                              ex.Message,
                                              UIAlertControllerStyle.Alert);


                alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

                PresentViewController(alerta, true, null);


            }
            
        }


    }
}