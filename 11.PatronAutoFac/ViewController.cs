using _11.PatronAutoFac.Interfaces;
using Foundation;
using System;
using UIKit;

namespace _11.PatronAutoFac
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Console.WriteLine("N0rf3n - ViewDidLoad - Begin ");

            //Implementación del AutoFac

            ICacheMFHelper iCacheHelper = AppDelegate.Resolve<ICacheMFHelper>();
            iCacheHelper.SaveToken("Regay");

            btnAutoFac.TouchUpInside += delegate
            {
                Console.WriteLine("N0rf3n - ViewDidLoad/btnAutoFac - Begin ");

                var info = txtInfo.Text;

                Console.WriteLine("N0rf3n - ViewDidLoad/btnAutoFac - info :  " + info);

                var resultado = iCacheHelper.GetToken(info);

                Console.WriteLine("N0rf3n - ViewDidLoad/btnAutoFac - resultado :  " + resultado);

                lblResultado.Text = resultado;

                Console.WriteLine("N0rf3n - ViewDidLoad/btnAutoFac - End ");
            };

            Console.WriteLine("N0rf3n - ViewDidLoad - End ");
        }

        public override void DidReceiveMemoryWarning()
        {

            Console.WriteLine("N0rf3n - DidReceiveMemoryWarning - Begin ");
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.

            Console.WriteLine("N0rf3n - DidReceiveMemoryWarning - End ");
        }
    }
}