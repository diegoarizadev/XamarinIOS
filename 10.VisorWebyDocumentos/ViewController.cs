using Foundation;
using QuickLook;
using SafariServices;
using System;
using System.Collections.Generic;
using UIKit;
using WebKit;

namespace _10.VisorWebyDocumentos
{
    
    public partial class ViewController : UIViewController
    {

        QLPreviewController Controlador;
        List<Elemento> Elementos;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            //Botón Web View
            btnVisorWeb1.TouchUpInside += delegate {

                WKWebView Webview = new WKWebView(View.Frame, new WKWebViewConfiguration()); //una nueva instancia que ocupa toda la pantalla y se le asigna configuración.
                View.AddSubview(Webview);//Se agrega directamente a la vista.
                var url = new NSUrl("https://www.raywenderlich.com/ios/");
                var request = new NSUrlRequest(url);
                Webview.LoadRequest(request);
	

	        };

            //Botón Web en Safari Services
            btnVisorWeb2.TouchUpInside += delegate {

                //Invocar a safiri services o invocar al navegador safari
                var url = new NSUrl("https://www.raywenderlich.com/4919757-your-first-ios-and-swiftui-app");
                var safari = new SFSafariViewController(url); //invoca el services de safari.
                PresentViewController(safari, true, null); //Aqui se invoca al navegador del dispositivo safari services.



            };

            //Botón Web Safari IOS
            btnVisorWeb3.TouchUpInside += delegate {

                //Aqui la aplicación queda en segundo plano

                var Url = new NSUrl("https://www.raywenderlich.com/1320561-machine-learning-in-ios");
                var Opcion = new UIApplicationOpenUrlOptions();
                Opcion.OpenInPlace = true;
                UIApplication.SharedApplication.OpenUrl(Url, Opcion, null);


            };

            btnDocumentos.TouchUpInside += delegate {

                Elementos = new List<Elemento>()
                {
                    //Instancia a la clase Elemento
                    new Elemento("Power Point", NSUrl.FromFilename("Docs/uno.ppt")),
                    new Elemento("Word", NSUrl.FromFilename("Docs/dos.docx")),
                    new Elemento("Excel", NSUrl.FromFilename("Docs/tres.xlsx"))

                };

                Controlador = new QLPreviewController();//Se crea una nueva instancia.
                Controlador.DataSource = new OrigenDatos(Elementos);
                PresentViewController(Controlador, true, null); //SEle arga el controlador.

	        };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    //nuev clase
    public class OrigenDatos : QLPreviewControllerDataSource //origen de los datos.
    {
        //Constructor
        public OrigenDatos(List<Elemento> elementos)
        {
            ListaElementos = elementos;

        }

        private List<Elemento> ListaElementos;
        public override nint PreviewItemCount(QLPreviewController controller)//Cantidad de elementos de lectura de documentos, para nuestro caso 3
        {
            return ListaElementos.Count;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index) //regresar al elemento anterior.
        {
            int x = (int)(index);
            return ListaElementos[x]; //ze realiza la extracción de elementos en el indice, para saber en que documento nos encontramos.
            
        }

    }

    //Se agrega una nueva clase.
    public class Elemento : QLPreviewItem
    {

        //Se agrega el constructor.
        public Elemento(string titulo, NSUrl ruta)
        {

            //Asignar los valores.
            ElementoTitulo = titulo;
            ElementoRuta = ruta;
            
        }

        //Se establecen los elementos del titulo y de la ruta.
        private string ElementoTitulo;
        private NSUrl ElementoRuta;

        public override string ItemTitle {

            get{
                return ElementoTitulo;
            }

        }

        public override NSUrl ItemUrl{

            get
            {
                return ElementoRuta;
            }

        }




    }
}