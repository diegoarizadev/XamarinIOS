using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Foundation;
using SQLite;
using UIKit;

namespace _13.SQLite
{
    public partial class ConcentradorViewController : UIViewController
    {
        List<Pasajeros> Lista = new List<Pasajeros>();
        UIAlertController Alerta;

        public ConcentradorViewController() : base("ConcentradorViewController", null)
        {
        }

        protected ConcentradorViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            LlenarTabla();
        }

        public void LlenarTabla()
        {
            Console.WriteLine("N0rf3n - LlenarTabla - BEGIN  ");
            Lista.Clear(); //Limpiar la lista

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//Apuntar a la Base de datos
            path = Path.Combine(path, "Basen0r.db3");
            var conexion = new SQLiteConnection(path);//Conecta

            try
            {
                var elementos = from s in conexion.Table<Pasajeros>()
                                select s; //Selecciona todos los elementos de la tabla
                foreach (var fila in elementos)//Se recorre los registros
                {
                    Lista.Add(new Pasajeros //Se agragan los datos a la lista
                    {
                        Nombre = fila.Nombre,
                        Empresa = fila.Empresa,
                        Fotografia = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fila.Fotografia) //apunta a la fotografia del path
                    });

                    Console.WriteLine("N0rf3n - LlenarTabla - Nombre : " + fila.Nombre);
                    Console.WriteLine("N0rf3n - LlenarTabla - Puesto : " + fila.Puesto);
                    Console.WriteLine("N0rf3n - LlenarTabla - Fotografia : " + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fila.Fotografia));
                }
            }
            catch (Exception ex)
            {
                MessageBox("Error:", ex.Message);//mostrar el error.
            }

            tbTabla.Source = null; //Se vacia la tabla
            tbTabla.Source = new OrigenTabla(Lista, this); //se envia la lista a la tabla
            tbTabla.ReloadData(); //Mostrar informacion de la tabla

            Console.WriteLine("N0rf3n - LlenarTabla - END");

        }

        public void MessageBox(string titulo, string mensaje)
        {
            Alerta = UIAlertController.Create(titulo, mensaje,UIAlertControllerStyle.Alert);
            Alerta.AddAction(UIAlertAction.Create("Aceptar",UIAlertActionStyle.Default,null));
            PresentViewController(Alerta, true, null);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class OrigenTabla : UITableViewSource
    {
        public string Nombre;
        List<Pasajeros> ElementosTabla; //se va encargar de recibira a lista para la tabla
        string IDCelda = "Celda";
        UIViewController Controlador;


        //constructor
        public OrigenTabla(List<Pasajeros> elementos,UIViewController controlador)
        {
            ElementosTabla = elementos;
            Controlador = controlador;
        }

        //Metoodo para ajustar la imagen en la tabla y se maneje un estandar
        public UIImage AjustarImagen(UIImage origenImagen, float ancho, float alto)
        {
            UIGraphics.BeginImageContext(new SizeF(ancho, alto));
            origenImagen.Draw(new RectangleF(0, 0, ancho, alto)); //imagen que llega al metodo.
            var destinoImagen = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();//qui se termina la edicion de la imagen
            return destinoImagen;
        }

        //getCell
        public override UITableViewCell GetCell(UITableView tableView,NSIndexPath indexPath)
        {

            Console.WriteLine("N0rf3n - UITableViewCell - BEGIN  ");
            var celda = tableView.DequeueReusableCell(IDCelda); //
            Console.WriteLine("N0rf3n - UITableViewCell - celda  : "+ celda);
            string elemento = ElementosTabla[indexPath.Row].Nombre;
            Console.WriteLine("N0rf3n - UITableViewCell - elemento  : " + elemento);
            string detalle = ElementosTabla[indexPath.Row].Empresa;
            Console.WriteLine("N0rf3n - UITableViewCell - detalle  : " + detalle);

            if (celda == null)
            {
                celda = new UITableViewCell(UITableViewCellStyle.Subtitle,IDCelda);//Se encar de llenar cada regon en el tabletView
                Console.WriteLine("N0rf3n - UITableViewCell - IF - celda  : " + celda);
            }

            //estos datos seran especificos para el reglon
            celda.TextLabel.Text = elemento;
            celda.DetailTextLabel.Text = detalle;
            celda.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

            Console.WriteLine("N0rf3n - UITableViewCell - UIImage  : " + UIImage.FromBundle(ElementosTabla[indexPath.Row].Fotografia));

            //Se envia la imagen
            celda.ImageView.Image = AjustarImagen(UIImage.FromBundle(ElementosTabla[indexPath.Row].Fotografia), 80, 80);//se defininen las dimensiones de la imagen

            Console.WriteLine("N0rf3n - UITableViewCell - End  ");

            return celda;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ElementosTabla.Count;
        }


        //Cuando el usuario seleccione el registro, se extrae el nombre del inidice y crear la instancia al DetalleViewController
        public override void RowSelected(UITableView tableView,NSIndexPath indexPath)
        {
            Nombre = ElementosTabla[indexPath.Row].Nombre;
            var detalle = Controlador.Storyboard.InstantiateViewController("DetalleViewController") as DetalleViewController; //DetalleController es el ID del Storyboard
            detalle.Indice = Nombre; //Se envia al ViewController de detalle
            Controlador.PresentViewControllerAsync(detalle, true); //Se invoca el controlador.
        }

    }
}

