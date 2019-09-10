using System;
using CoreGraphics;
using UIKit;

namespace _9.AnimacionUIKIT
{
    public partial class AnclajeViewController : UIViewController
    {

        public UIDynamicAnimator Animador { get; set; } //esta variable desencadenara las animaciones.
        public AnclajeViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Gravedad = new UIGravityBehavior(Imagen1);//Se agrega gravedad a uno de los objectos.
            var Colision = new UICollisionBehavior(Imagen2)
            {
                TranslatesReferenceBoundsIntoBoundary = true
            };

            var PuntoCentral = new CGPoint(Imagen1.Center.X,
                                            Imagen1.Center.Y -
                                            100);

            var Anclaje = new UIAttachmentBehavior(Imagen1, PuntoCentral) //Se conecta la imagen al punto centra
            {

                Frequency = 1.0f,
                Damping = 0.1f //forma en la que esta haciendo el rebote.

        };

            Imagen2.Center = Anclaje.AnchorPoint;
            Imagen2.Center = new CGPoint(50.0f, 50.0f);
            Animador = new UIDynamicAnimator(View);
            Animador.AddBehaviors(Anclaje, Gravedad, Colision);
            View.AddGestureRecognizer(new UIPanGestureRecognizer((gesto) =>
           {

               Anclaje.AnchorPoint = gesto.LocationInView(View);
               Imagen2.Center = Anclaje.AnchorPoint;
           }));

        }


    }
}

