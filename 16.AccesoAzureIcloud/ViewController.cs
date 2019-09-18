using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using UIKit;

namespace _16.AccesoAzureIcloud
{
    public partial class ViewController : UIViewController
    {
        VistaCargado carga = null;
        List<Pasajeros> Lista = new List<Pasajeros>();
        UIAlertController Alerta;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Lista.Clear(); //Se limpia.
            carga = new VistaCargado(UIScreen.MainScreen.Bounds);//Se muestra la pantalla de cargando.

            try
            {
                //conexión.
                var cuentaAlmacenamiento = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;" +
                                                                    "AccountName=n0rf3n;" +
                                                                    "AccountKey=B7vZmPhmDtkKFQqcK9fVPClPUEnDuH6U31ntI5mNv6467t5jivYyPHVWklp+zmYNj4J2iTRlSxKrcs9Ngt8UVg==;" +
                                                                    "EndpointSuffix=core.windows.net");

                var clienteBlob = cuentaAlmacenamiento.CreateCloudBlobClient();
                var contenedor = clienteBlob.GetContainerReference("imagenes");//contenedor al que deseamos acceder
                var clienteTabla = cuentaAlmacenamiento.CreateCloudTableClient();
                var TablaCloud = clienteTabla.GetTableReference("Pasajeros");//Taba de datos.
                var Consulta = new TableQuery<Pasajeros>();//Consulta con referencia a Pasajeors
                TableContinuationToken token = null;
                View.Add(carga);//Agregamos a la vista el show loading o cargando.
                string Elemento = "";
                var Receptor = await TablaCloud.ExecuteQuerySegmentedAsync<Pasajeros>(Consulta, token, null, null);//ejecuta el query sobre la tabla de pasajeros
                Lista.AddRange(Receptor.Results);//se agrega a lista el recsultao de la consulta.
                int contador = 0;
                while (contador < Lista.Count)//Se recorre la lista para descargar las iamagenes.
                {
                    Elemento = Lista.ElementAt(contador).Fotografia;
                    var recursoBlob = contenedor.GetBlockBlobReference(Elemento);//SearchDisplayController //Se estrae el texto de la fotografia.
                    var ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//ruta para almacenar la imagen.
                    var archivoJPG = Path.Combine(ruta, Elemento);//
                    var stream = File.OpenWrite(archivoJPG);
                    await recursoBlob.DownloadToStreamAsync(stream);//Descarga el archivo o fotografia.
                    contador++;
                }
            }
            catch (Exception ex)
            {
                MessageBox("Error: ", ex.Message);
            }

            tabla.Source = null;
            tabla.Source = new OrigenTabla(Lista); //Se crea una instanacia de la lista.
            tabla.ReloadData(); //Se quita la capa del show loading.
            carga.Esconder();
        }

        public void MessageBox(string titulo, string mensaje)
        {
            Alerta = UIAlertController.Create(titulo, mensaje,UIAlertControllerStyle.Alert);
            Alerta.AddAction(UIAlertAction.Create("Aceptar",UIAlertActionStyle.Default, null));
            PresentViewController(Alerta, true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}