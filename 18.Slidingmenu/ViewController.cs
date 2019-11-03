using _18.Slidingmenu.Model;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace _18.Slidingmenu
{
    public partial class ViewController : UIViewController
    {
        MenuTableSourceClass objMenuTableSource;
        nfloat flViewShiftUpY;
        nfloat flViewBringDownY;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InicializarView();
            tableViewMenu.Hidden = true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void InicializarView()
        {
            CGRect rectBounds = UIScreen.MainScreen.Bounds;

            flViewBringDownY = rectBounds.Height - 30f; //vista completa de viewContainer
            flViewShiftUpY = rectBounds.Height - 120f;//200 es la altura de viewContainer

            var recognizerRight = new UISwipeGestureRecognizer(FnSwipeLeftToRight);
            recognizerRight.Direction = UISwipeGestureRecognizerDirection.Right;
            View.AddGestureRecognizer(recognizerRight);

            var recognizerLeft = new UISwipeGestureRecognizer(FnSwipeRightToLeft);
            recognizerLeft.Direction = UISwipeGestureRecognizerDirection.Left;
            View.AddGestureRecognizer(recognizerLeft);
        }

        void FnSwipeRightToLeft()
        {
            if (!tableViewMenu.Hidden)
                FnPerformTableTransition();
        }

        void FnSwipeLeftToRight()
        {
            if (tableViewMenu.Hidden)
                FnPerformTableTransition();

        }

        void FnPerformTableTransition()
        {
            tableViewMenu.Hidden = !tableViewMenu.Hidden;
            var transition = new CATransition();
            transition.Duration = 0.25f;
            transition.Type = CAAnimation.TransitionPush;
            if (tableViewMenu.Hidden)
            {
                transition.TimingFunction = CAMediaTimingFunction.FromName(new Foundation.NSString("easeOut"));
                transition.Subtype = CAAnimation.TransitionFromRight;
            }
            else
            {
                transition.TimingFunction = CAMediaTimingFunction.FromName(new Foundation.NSString("easeIn"));
                transition.Subtype = CAAnimation.TransitionFromLeft;
            }
            tableViewMenu.Layer.AddAnimation(transition, null);
        }

    }
}