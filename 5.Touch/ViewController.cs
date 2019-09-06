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
        CMMotionActivityManager Movimiento; //Utilizar el Acelerometro
        nfloat Altura;
        nfloat Ancho;
        nfloat AnchoCapaa;
        nfloat AlturaCapa;
        nfloat ActualizaX;
        nfloat ActualizaY;
        CALayer CapaImagen3;//Capa

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