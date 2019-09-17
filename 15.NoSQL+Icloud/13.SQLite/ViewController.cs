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

            txtVisor.Text = ""; //Se limpia cada vez que ingrese.

            var Carpeta = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal)); //Aqui se guardara la base de datos y las imagenes

            //Se verifica el visor para obtener la informacion de la carpeta donde almacenamos la información.
            foreach (var archivos in Carpeta)
            {
                txtVisor.Text += archivos + Environment.NewLine;
            }

            SeleccionadorImagen = new UIImagePickerController();
            SeleccionadorImagen.FinishedPickingMedia += SeleccionImagen;
            SeleccionadorImagen.Canceled += ImagenCancelada;

            //Validación para identificar si la camara esta diponible.
            if (UIImagePickerController.IsSourceTypeAvailable
                (UIImagePickerControllerSourceType.Camera))
            {
                SeleccionadorImagen.SourceType =UIImagePickerControllerSourceType.Camera;
            }
            else
            {
                SeleccionadorImagen.SourceType =UIImagePickerControllerSourceType.PhotoLibrary;
            }


            var rutabase = Environment.GetFolderPath (Environment.SpecialFolder.Personal); //ruta de la base de datos
            rutabase = Path.Combine(rutabase, "Basen0r.db3"); //Nombre de la base de datos
            var conexion = new SQLiteConnection(rutabase); //Conexion a la base de datos.
            conexion.CreateTable<Pasajeros>();//Estrucutra de la tabla.

            btnGuardar.TouchUpInside += delegate
            {
                try
                {
                    var Insertar = new Pasajeros(); //Instancia de Pasajeros
                    Insertar.Nombre = txtNombre.Text;
                    Insertar.Puesto = txtPuesto.Text;
                    Insertar.Empresa = txtEmpresa.Text;
                    Insertar.Correo = txtCorreo.Text;
                    Insertar.Fotografia = txtNombre.Text + ".jpg";

                    conexion.Insert(Insertar); //Inserta el resgistro a la BD
                    //Se limpia el formulario
                    txtNombre.Text = "";
                    txtPuesto.Text = "";
                    txtCorreo.Text = "";
                    txtEmpresa.Text = "";
                    imgImagen.Image = null;

                    MessageBox("Almacenado correctamente", "SQLite");
                }
                catch (Exception ex)
                {
                    MessageBox("Error", ex.Message);
                }
            };


            btnFotografia.TouchUpInside +=delegate {
                Console.WriteLine("N0rf3n - btnFotografia - Begin ");
                PresentViewController(SeleccionadorImagen, true, null);
                Console.WriteLine("N0rf3n - btnFotografia - End ");
            };


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
                Console.WriteLine("N0rf3n - SeleccionImagen - Begin ");
                var ImagenSeleccionada = e.Info[UIImagePickerController.OriginalImage] as UIImage;//Seleccion de la imagen
                Console.WriteLine("N0rf3n - SeleccionImagen - ImagenSeleccionada : " + ImagenSeleccionada);
                var rutaImagen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),txtNombre.Text + ".jpg");//ruta de la imagen
                Console.WriteLine("N0rf3n - SeleccionImagen - rutaImagen : " + rutaImagen);
                if (File.Exists(rutaImagen))
                {
                    MessageBox("Aviso:", "La imagen ya existente");
                }
                else
                {
                    ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    Console.WriteLine("N0rf3n - SeleccionImagen - ruta : " + ruta);
                    ArchivoImagen = Path.Combine(ruta, txtNombre.Text + ".jpg");
                    Console.WriteLine("N0rf3n - SeleccionImagen - txtNombre.Text : " + txtNombre.Text);
                    Console.WriteLine("N0rf3n - SeleccionImagen - ArchivoImagen : " + ArchivoImagen);
                    NSError error;
                    var DatosImagen = ImagenSeleccionada.AsJPEG();
                    DatosImagen.Save(ArchivoImagen, false, out error);
                    imgImagen.Image = UIImage.FromFile(ArchivoImagen);
                    SeleccionadorImagen.DismissViewController(true, null);
                }
                Console.WriteLine("N0rf3n - SeleccionImagen - End ");
            }
            catch (Exception ex)
            {
                MessageBox("Error", ex.Message);
                SeleccionadorImagen.DismissViewController(true, null);
            }
        }

        //Accion para cuando el usuario cancela la camara o fototeca 
        public void ImagenCancelada(object sender, EventArgs e)
        {
            SeleccionadorImagen.DismissViewController(true, null);
        }

    }

    //Se crea nueva clase
    public class Pasajeros
    {
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Correo { get; set; }
        public string Empresa { get; set; }
        public string Fotografia { get; set; }
    }

}