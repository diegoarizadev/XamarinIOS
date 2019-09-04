using Foundation;
using System;
using UIKit;
using CoreGraphics;
using Foundation;
using AVFoundation;

namespace _2.AccesoAVideos
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
            btnVideoLocal.TouchUpInside += delegate//Habilita el primer boton
            {
                //Aquí se almacenara la acción del botón.

                AVPlayer Reproductor;
                AVPlayerLayer CapaReproductor;
                AVAsset Recurso;
                AVPlayerItem RecursoReproducir;

                Recurso = AVAsset.FromUrl(NSUrl.FromFilename("VideoExample.mp4"));//establece un nombre local de un archivo.
                RecursoReproducir = new AVPlayerItem(Recurso);
                Reproductor = new AVPlayer(RecursoReproducir);
                CapaReproductor = AVPlayerLayer.FromPlayer(Reproductor); //La capa se pone ensima de nuestra vista.
                CapaReproductor.Frame = new CGRect(50,140,300,250); //Se definen las dimenciones.
                View.Layer.AddSublayer(CapaReproductor); //Agregar sobre nuestra vista.
                Reproductor.Play(); //Inicia la reproducción del video.



            };

            btnVideoInternet.TouchUpInside += delegate {

                //Aquí se almacenara la acción del botón.

                AVPlayer Reproductor;
                AVPlayerLayer CapaReproductor;
                AVAsset Recurso;
                AVPlayerItem RecursoReproducir;

                Recurso = AVAsset.FromUrl(NSUrl.FromString("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
                RecursoReproducir = new AVPlayerItem(Recurso);
                Reproductor = new AVPlayer(RecursoReproducir);
                CapaReproductor = AVPlayerLayer.FromPlayer(Reproductor); //La capa se pone ensima de nuestra vista.
                CapaReproductor.Frame = new CGRect(50, 540, 300, 250);
                View.Layer.AddSublayer(CapaReproductor); //Agregar sobre nuestra vista.
                Reproductor.Play(); //Inicia la reproducción del video.


            };

            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}