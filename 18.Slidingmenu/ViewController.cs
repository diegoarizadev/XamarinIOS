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
        MenuTableSource objMenuTableSource;
        nfloat flViewShiftUpY;
        nfloat flViewBringDownY;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            Console.WriteLine("N0rf3n - ViewController - ViewDidLoad - Begin");
            base.ViewDidLoad();
            InicializarView();
            tableViewMenu.Hidden = true;
            FnBindMenu();
            Console.WriteLine("N0rf3n - ViewController - ViewDidLoad - End");

        }

        public override void DidReceiveMemoryWarning()
        {
            Console.WriteLine("N0rf3n - ViewController - DidReceiveMemoryWarning - Begin");
            base.DidReceiveMemoryWarning();
            Console.WriteLine("N0rf3n - ViewController - DidReceiveMemoryWarning - End");
        }

        void InicializarView()
        {
            Console.WriteLine("N0rf3n - ViewController - InicializarView - Begin");
            CGRect rectBounds = UIScreen.MainScreen.Bounds;

            flViewBringDownY = rectBounds.Height - 30f; //vista completa de viewContainer
            flViewShiftUpY = rectBounds.Height - 120f;//200 es la altura de viewContainer

            var recognizerRight = new UISwipeGestureRecognizer(FnSwipeLeftToRight);
            recognizerRight.Direction = UISwipeGestureRecognizerDirection.Right;
            View.AddGestureRecognizer(recognizerRight);

            var recognizerLeft = new UISwipeGestureRecognizer(FnSwipeRightToLeft);
            recognizerLeft.Direction = UISwipeGestureRecognizerDirection.Left;
            View.AddGestureRecognizer(recognizerLeft);
            Console.WriteLine("N0rf3n - ViewController - InicializarView - End");
        }

        void FnSwipeRightToLeft()
        {
            Console.WriteLine("N0rf3n - ViewController - FnSwipeRightToLeft - Begin");
            if (!tableViewMenu.Hidden)
                FnPerformTableTransition();
            Console.WriteLine("N0rf3n - ViewController - FnSwipeRightToLeft - End");
        }

        void FnSwipeLeftToRight()
        {
            Console.WriteLine("N0rf3n - ViewController - FnSwipeLeftToRight - Begin");
            if (tableViewMenu.Hidden)
                FnPerformTableTransition();
            Console.WriteLine("N0rf3n - ViewController - FnSwipeLeftToRight - End");

        }

        void FnPerformTableTransition()
        {
            Console.WriteLine("N0rf3n - ViewController - FnPerformTableTransition - Begin");
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
            Console.WriteLine("N0rf3n - ViewController - FnPerformTableTransition - End");
        }


        void FnBindMenu()
        {

            Console.WriteLine("N0rf3n - ViewController - FnBindMenu - Begin");
            if (objMenuTableSource != null)
            {
                Console.WriteLine("N0rf3n - ViewController - FnBindMenu - IF");
                objMenuTableSource.MenuSelected -= FnMenuSelected;
                objMenuTableSource = null;
            }
            objMenuTableSource = new MenuTableSource();
            Console.WriteLine("N0rf3n - ViewController - FnBindMenu - 1");
            objMenuTableSource.MenuSelected += FnMenuSelected;
            Console.WriteLine("N0rf3n - ViewController - FnBindMenu - 2");
            tableViewMenu.Source = objMenuTableSource;
            Console.WriteLine("N0rf3n - ViewController - FnBindMenu - End");
        }

        void FnMenuSelected(string strMenuSeleted)
        {
            Console.WriteLine("N0rf3n - ViewController - FnMenuSelected - Begin");
            lblTitulo.Text = strMenuSeleted;
            FnSwipeRightToLeft();
            Console.WriteLine("N0rf3n - ViewController - FnMenuSelected - End");
        }

    }
}