using Foundation;
using System;
using UIKit;
using System.IO;
using SQLite;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

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

            btnFotografia.TouchUpInside += delegate {
                Console.WriteLine("N0rf3n - btnFotografia - Begin ");
                PresentViewController(SeleccionadorImagen, true, null);
                Console.WriteLine("N0rf3n - btnFotografia - End ");
            };

            btnGuardar.TouchUpInside += async delegate
            {
                try
                {

                    var CuentaAlmacenamiento = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=almacenaenriqueaguilar;AccountKey=uGbhDArj46DRfEvv47bLhgS775SocE94R7sq9VHiA03ss7ODcy+RwgQ7AIs/E6Ak68Y+K0MNPx6B2Y90JEH2hw==;EndpointSuffix=core.windows.net");
                    var ClienteTabla = CuentaAlmacenamiento.CreateCloudTableClient();
                    var Tabla = ClienteTabla.GetTableReference("Pasajeros"); //Se le signa una referencia de la tabla.
                    bool x = await Tabla.CreateIfNotExistsAsync(); //Si la tabla no existe la crea.
                    var pasajero = new Pasajeros("Registro", txtNombre.Text); // Se crea una nueva instancia, mando como parametro "registro" y como clave el valor digitado en el campo.
                    pasajero.Empresa = txtEmpresa.Text;
                    pasajero.Puesto = txtPuesto.Text;
                    pasajero.Correo = txtCorreo.Text;
                    pasajero.Fotografia = txtNombre.Text + ".jpg";
                    TableOperation Insertar = TableOperation.Insert(pasajero); //Se crea una operación para realizar el insert.
                    await Tabla.ExecuteAsync(Insertar); //realiza el insert
                    MessageBox("Guardado en Azure", " Tabla NoSQL");


                    var clienteBlob = CuentaAlmacenamiento.CreateCloudBlobClient(); //Se crea una bd para almacenar archivos grandes.
                    var contenedor = clienteBlob.GetContainerReference("imagenes"); //contenedor de la información
                    var recursoblob = contenedor.GetBlockBlobReference(txtNombre.Text + ".jpg");
                    await recursoblob.UploadFromFileAsync(ruta); //SEalmacena la imagen.
                    MessageBox("Guardado en", "Azure Storage Blobs");

                    //Se limpia las cajas de texto e imagen,
                    txtNombre.Text = "";
                    txtPuesto.Text = "";
                    txtCorreo.Text = "";
                    txtEmpresa.Text = "";
                    imgImagen.Image = null;

                }
                catch (Exception ex)
                {
                    MessageBox("Error", ex.Message);
                }
            };

            SeleccionadorImagen = new UIImagePickerController();
            SeleccionadorImagen.FinishedPickingMedia += SeleccionImagen;
            SeleccionadorImagen.Canceled += ImagenCancelada;

            //Validación para identificar si la camara esta diponible.
            if (UIImagePickerController.IsSourceTypeAvailable
                (UIImagePickerControllerSourceType.Camera))
            {
                SeleccionadorImagen.SourceType = UIImagePickerControllerSourceType.Camera;
            }
            else
            {
                SeleccionadorImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            }
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
    public class Pasajeros: TableEntity
    {
        public Pasajeros(string Registros, string Nombre)//recibe la clave de partición y la clave de reglon, son datos fundamentales para una tabla NoSQL
        {
            PartitionKey = Registros; //Clave de partición
            RowKey = Nombre; //Clave de renglon
        }
        public string Puesto { get; set; }
        public string Correo { get; set; }
        public string Empresa { get; set; }
        public string Fotografia { get; set; }
    }

}