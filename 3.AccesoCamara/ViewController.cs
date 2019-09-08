using Foundation;
using System;
using UIKit;
using System.IO;
using Foundation;

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


            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))// Validar si el dispositivo tiene camara.
            {

                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.Camera;

            }
            else //no tiene camara.
            {

                SeleccionImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            }

            btnCamara.TouchUpInside += delegate {

             
                PresentViewController(SeleccionImagen,
                                        true,
                                        null);

        	};


            btnBiblioteca.TouchUpInside += delegate {

                string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//Ruta del dispositivo

                string nombreArchivo = "FotoN0rf3n01.jpg"; //nombre del archivo

                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                imagenes.Image = UIImage.FromFile(rutaCompleta);

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

            Fotografia.SaveToPhotosAlbum(delegate (UIImage imagen, NSError error)
            {

                if(null != error) //Si, el error contiene información, debe mostrarla.
                {
                    Console.WriteLine(error.LocalizedDescription);//muestra la información del error
                }
            }
            );

            Fotografia.AsJPEG(); //Almacena en el album de photografias.

            string rutaCarpeta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//Ruta del dispositivo

            string nombreArchivo = "Foto01.jpg"; //nombre del archivo

            string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            NSError err = null;

            NSData img  = Fotografia.AsJPEG(); //Almacena en el album de photografias, Se selecciona la imagen que esta guardad localmente.

            img.Save(rutaCompleta, false, out err);

            imagenes.Image = UIImage.FromFile(rutaCompleta);

            SeleccionImagen.DismissViewControllerAsync(true);


        }




        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}