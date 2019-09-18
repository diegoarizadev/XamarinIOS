using System;
using System.IO;
using UIKit;
using CoreAnimation;

namespace _16.AccesoAzureIcloud
{
    public partial class CeldaController : UITableViewCell
    {

        protected CeldaController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void ActualizarCelda(Pasajeros pasajero)
        {
            lblNombre.Text = pasajero.RowKey;
            lblCorreo.Text = pasajero.Correo;
            lblPuesto.Text = pasajero.Puesto;
            lblEmpresa.Text = pasajero.Empresa;
            var rutaImagen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),pasajero.Fotografia);
            image.Image = UIImage.FromFile(rutaImagen);

            //redondear imagen
            CALayer RedondeoImage = image.Layer;
            RedondeoImage.CornerRadius = 40; //se aplica redondeo del 40 en las esquinas
            RedondeoImage.MasksToBounds = true;//Se aplica la mascara.
        }
    }
}
