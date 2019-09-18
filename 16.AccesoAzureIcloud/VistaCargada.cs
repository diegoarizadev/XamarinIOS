using System;
using CoreGraphics;
using UIKit;
namespace _16.AccesoAzureIcloud
{
    public class VistaCargado : UIView
    {

        //esta clase se utilizara para mostrar un Show Loading..
        UIActivityIndicatorView Indicador;
        UILabel Mensaje;

        public VistaCargado(CGRect frame) : base(frame)
        {
            BackgroundColor = UIColor.Black; //color de fondo
            Alpha = 0.75f; //alpha
            AutoresizingMask = UIViewAutoresizing.All; //aplica a toda la vista

            //Dimensiones de las etiquetas
            nfloat labelAlto = 22;
            nfloat labelAncho = Frame.Width - 20;
            nfloat centerX = Frame.Width / 2;
            nfloat centerY = Frame.Height / 2;

            Indicador = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            Indicador.Frame = new CGRect(
            //Se mostrara el mensaje en todo el centro de la pantalla.
            centerX - (Indicador.Frame.Width / 2),
            centerY - Indicador.Frame.Height - 20,
            Indicador.Frame.Width,Indicador.Frame.Height);
            Indicador.AutoresizingMask = UIViewAutoresizing.All;
            AddSubview(Indicador);
            Indicador.StartAnimating();//efecto del circulo dando vueltas


            //Etiqueta.
            Mensaje = new UILabel(new CGRect(
            //aparecera en el centro  
            centerX - (labelAncho / 2),
            centerY + 20,labelAncho,labelAlto));
            Mensaje.BackgroundColor = UIColor.Clear;
            Mensaje.TextColor = UIColor.White;
            Mensaje.Text = "Cargando Datos...";
            Mensaje.TextAlignment = UITextAlignment.Center;
            Mensaje.AutoresizingMask = UIViewAutoresizing.All;
            AddSubview(Mensaje);
        }

        //Se oculta antes de cargar los datos.
        public void Esconder()
        {
            UIView.Animate(0.5, () =>
            { Alpha = 0; }, () =>
            { RemoveFromSuperview(); }
            );
        }
    }
}
