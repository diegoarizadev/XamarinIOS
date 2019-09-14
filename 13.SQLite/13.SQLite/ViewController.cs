using Foundation;
using System;
using UIKit;
using System.IO;
using SQLite;

namespace _13.SQLite
{
    public partial class ViewController : UIViewController
    {
        string ArchivoImagen, ruta;
        UIAlertController Alerta;
        UIImagePickerController SeleccionadorImagen;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
            txtVisor.Text = ""; //Se limpia cada vez que ingrese.

            var Carpeta = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal)); //Aqui se guardara la base de datos y las imagenes

             

        }

        public void MessageBox(string titulo, string mensaje) //funcion para mostrar alertas
        {
            Alerta = UIAlertController.Create(titulo, mensaje,UIAlertControllerStyle.Alert);
            Alerta.AddAction(UIAlertAction.Create("Aceptar",UIAlertActionStyle.Default,null));
            PresentViewController(Alerta, true, null); //Se envia a la pantalla actual
        }


        //Funcion para capturar la imagen
        public void SeleccionImagen(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            try
            {
                var ImagenSeleccionada = e.Info[UIImagePickerController.
                                                OriginalImage] as UIImage;
                var rutaImagen = Path.Combine(Environment.GetFolderPath
                                              (Environment.SpecialFolder.
                                               Personal),
                                              txtNombre.Text + ".jpg");
                if (File.Exists(rutaImagen))
                {
                    MessageBox("Aviso:", "La imagen ya existente");
                }
                else
                {
                    ruta = Environment.GetFolderPath(Environment.
                                                     SpecialFolder.
                                                     Personal);
                    ArchivoImagen = Path.Combine(ruta, txtNombre.Text + ".jpg");
                    NSError error;
                    var DatosImagen = ImagenSeleccionada.AsJPEG();
                    DatosImagen.Save(ArchivoImagen, false, out error);
                    imgImagen.Image = UIImage.FromFile(ArchivoImagen);
                    SeleccionadorImagen.DismissViewController(true, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox("Error", ex.Message);
                SeleccionadorImagen.DismissViewController(true, null);
            }
        }

    }

    //Se crea nueva clase
    public class Asistentes
    {
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Correo { get; set; }
        public string Empresa { get; set; }
    }

}