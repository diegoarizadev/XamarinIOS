using Foundation;
using System;
using UIKit;

namespace _3.AccesoCamara
{
    public partial class ViewController : UIViewController
    {
        //Decalración de variables.
        UIImagePickerController SeleccionImagen;
        UIImage Fotografia; //Objecto de tipo image.



        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            SeleccionImagen = new UIImagePickerController(); //Se crea la instancia del objecto.
            SeleccionImagen.FinishedPickingMedia += FinalizandoSeleccion; //Verificar cuando el evento de seleccion termina.
            SeleccionImagen.Canceled += CanceledaSeleccion; //Evento de cancelación.


            btnCamara.TouchUpInside += delegate {

                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.Camera; // Se selecciona el origen "Biblioteca"

                PresentViewController(SeleccionImagen,
                                        true,
                                        null);

        	};


            btnBiblioteca.TouchUpInside += delegate {

                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary; // Se selecciona el origen "Camara"

                PresentViewController(SeleccionImagen,
                                        true,
                                        null);

            };

        }

        //Se escriben los eventos FinalizandoSeleccion y CanceledaSeleccion
        private void CanceledaSeleccion(object sender, EventArgs e)
        {

            SeleccionImagen.DismissViewControllerAsync(true);

        }


        private void FinalizandoSeleccion(object sender, UIImagePickerMediaPickedEventArgs e)
        {

            Fotografia = e.Info[UIImagePickerController.OriginalImage] as UIImage; //Se captura la inagen de tipo Image que es la imagen que esta ingresando al evento.

            imagenes.Image = Fotografia; //Se envia al componente grafico.

            SeleccionImagen.DismissViewControllerAsync(true); //Quitar la pantalla del picker Controller

        }




        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}