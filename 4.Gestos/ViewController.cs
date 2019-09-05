using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace _4.Gestos
{
    public partial class ViewController : UIViewController
    {

        nfloat rotacion = 0;
        nfloat coordenadasX = 0;
        nfloat coordenadasY = 0;

        bool Toque;

        UIRotationGestureRecognizer GestoRotar;
        UIPanGestureRecognizer GestoMover;
        UIAlertController ALerta;



        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            image.UserInteractionEnabled = true; //
            var GestoToque = new UITapGestureRecognizer(Tocando);

            //Se aplican los gestos a la imagen
            image.AddGestureRecognizer(GestoToque);

            GestoMover = (UIKit.UIPanGestureRecognizer)new UIGestureRecognizer(() =>
            {

                if ((GestoMover.State == UIGestureRecognizerState.Began || //Validar el estado del gesto
                    GestoMover.State == UIGestureRecognizerState.Changed) &&
                    (GestoMover.NumberOfTouches == 1))
                {

                    var P0 = GestoMover.LocationInView(View); //Gesto en toda la pantalla.

                    if (coordenadasX == 0)
                        coordenadasX = P0.X - image.Center.X;

                    if (coordenadasY == 0)
                        coordenadasY = P0.Y - image.Center.Y;

                    var P1 = new CGPoint(P0.X - coordenadasX, P0.Y - coordenadasY);

                    image.Center = P1;

                }
                else
                {

                    coordenadasX = 0;
                    coordenadasY = 0;

                }
            });


            GestoRotar = (UIKit.UIRotationGestureRecognizer)new UIGestureRecognizer(() =>
            {

                if ((GestoRotar.State == UIGestureRecognizerState.Began || //Validar el estado del gesto
                    GestoRotar.State == UIGestureRecognizerState.Changed) &&
                    (GestoRotar.NumberOfTouches == 2)) //el gesto de rotar se hace con dos toques.
                {
                    image.Transform = CGAffineTransform.MakeRotation(GestoRotar.Rotation + rotacion); //Se vuelve a verificar el estado, para validar en donde se quedo.
                }
                else if (GestoRotar.State == UIGestureRecognizerState.Ended)
                {
                    rotacion = GestoRotar.Rotation; //Se obtinen los valores de rotación.
                }
            });

            //Se aplican los gestos a la imagen
            image.AddGestureRecognizer(GestoMover);
            image.AddGestureRecognizer(GestoRotar);

        }


        void Tocando(UITapGestureRecognizer toque)
        {
            if (!Toque)
            {
                toque.View.Transform *= CGAffineTransform.MakeRotation((float)Math.PI);
                Toque = true;
                ALerta = UIAlertController.Create("Imagen Tocada",//Titulo
                                                  "Imagen Girando",//Mensaje
                                                  UIAlertControllerStyle.Alert);

                ALerta.AddAction(UIAlertAction.Create("Aceptar", //Se agrega un botón al alert.
                                                      UIAlertActionStyle.Default, //estilo del sistema operativo
                                                      null));

                PresentViewController(ALerta, true, null); //Mostrar el alert al usuario.

            }
            else
            {

                toque.View.Transform *= CGAffineTransform.MakeRotation((float)-Math.PI);
                Toque = false;
                ALerta = UIAlertController.Create("Imagen Regresa",//Titulo
                                                  "Imagen Regresando",//Mensaje
                                                  UIAlertControllerStyle.Alert);

                ALerta.AddAction(UIAlertAction.Create("Aceptar", //Se agrega un botón al alert.
                                                      UIAlertActionStyle.Default, //estilo del sistema operativo
                                                      null));

                PresentViewController(ALerta, true, null); //Mostrar el alert al usuario.

            }
        }

 
    }
}