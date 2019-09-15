using System;
using System.IO;
using SQLite;
using UIKit;

namespace _13.SQLite
{
    public partial class DetalleViewController : UIViewController
    {
        public string Indice { get; set; }

        public DetalleViewController(string indice) : base("DetalleViewController", null)
        {
            Indice = indice;
        }

        protected DetalleViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//Apuntar a la Base de datos
            path = Path.Combine(path, "Basen0r.db3");//Nombre de la base de datos
            var conexion = new SQLiteConnection(path);//conexion con la base de datos
            var elementos = from s in conexion.Table<Pasajeros>() //consulta la tabla
                            where s.Nombre == Indice //condicion de la consulta
                            select s; //Resultado de la consulta, selecciona todo
            foreach (var fila in elementos) //Se recorren el resultado de la consulta y se colocan en el formulario.
            {
                lblNombre.Text = fila.Nombre;
                lblPuesto.Text = fila.Puesto;
                lblEmpresa.Text = fila.Empresa;
                lblCorreo.Text = fila.Correo;
                imgDetalle.Image = UIImage.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fila.Fotografia));
            }
        }
    }
}

