using System;

using UIKit;

namespace _9.AnimacionUIKIT
{
    public partial class ReboteViewController : UIViewController
    {

        public UIDynamicAnimator Animador { get; set; }
        public ReboteViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var Gravedad = new UIGravityBehavior(Imagen1, Imagen2);//Se agrega gravedad a uno de los objectos.
            var Colision = new UICollisionBehavior(Imagen1, Imagen2)
            {
                TranslatesReferenceBoundsIntoBoundary = true
            };

            var Rebote = new UIDynamicItemBehavior(Imagen2)
            {
                Elasticity = 1f
            };
            Animador = new UIDynamicAnimator(View);
            Animador.AddBehaviors(Gravedad, Colision, Rebote);

        }

    }
}

