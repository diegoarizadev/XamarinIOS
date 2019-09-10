using System;

using UIKit;

namespace _9.AnimacionUIKIT
{
    public partial class GravedadViewController : UIViewController
    {
        public UIDynamicAnimator Animador { get; set; } //esta variable desencadenara las animaciones.
        public GravedadViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Animador = new UIDynamicAnimator(View); //Se asigna a la vista actual.

            Animador.AddBehavior(new UIGravityBehavior(Imagen1));//Se agrega un comportamiento


        }

    }
}

