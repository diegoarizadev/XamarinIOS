using CoreGraphics;
using Foundation;
using System;
using UIKit;

namespace _21.UIViewAnimate
{
    public partial class ViewController : UIViewController
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            InicializarView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        partial void ActionSubir(UIButton sender)
        {
            Console.WriteLine("N0rf3n - ActionSubir - Begin");
            var animator = new UIViewPropertyAnimator(0.3, new UIViewAnimationCurve(), () => {

                viewAnimate.Frame = new CGRect(viewAnimate.Frame.X, viewAnimate.Frame.Y - (viewAnimate.Frame.Height-20), viewAnimate.Frame.Width, viewAnimate.Frame.Height);

            });
            animator.StartAnimation();

            Console.WriteLine("N0rf3n - ActionSubir - End");
        }

        partial void ActionBajar(UIButton sender)
        {
            Console.WriteLine("N0rf3n - ActionSubir - Begin");
            var animator = new UIViewPropertyAnimator(0.3, new UIViewAnimationCurve(), () => {

                viewAnimate.Frame = new CGRect(viewAnimate.Frame.X, viewAnimate.Frame.Y + (viewAnimate.Frame.Height-20), viewAnimate.Frame.Width, viewAnimate.Frame.Height);

            });
            animator.StartAnimation();

            Console.WriteLine("N0rf3n - ActionSubir - End");
        }


        void InicializarView()
        {
            Console.WriteLine("N0rf3n - InicializarView - Begin");


            var recognizerDown = new UISwipeGestureRecognizer(FnSwipeDownToUp);
            recognizerDown.Direction = UISwipeGestureRecognizerDirection.Down;
            viewAnimate.AddGestureRecognizer(recognizerDown);

            var recognizerUp = new UISwipeGestureRecognizer(FnSwipeUpToDown);
            recognizerUp.Direction = UISwipeGestureRecognizerDirection.Up;
            viewAnimate.AddGestureRecognizer(recognizerUp);
            Console.WriteLine("N0rf3n - InicializarView - End");
        }


        void FnSwipeDownToUp()
        {
            Console.WriteLine("N0rf3n - FnSwipeDownToUp - Begin");
            DownToUp();
            Console.WriteLine("N0rf3n - FnSwipeDownToUp - End");
        }

        void FnSwipeUpToDown()
        {
            Console.WriteLine("N0rf3n - FnSwipeUpToDown - Begin");
            UpToDown();
            Console.WriteLine("N0rf3n - FnSwipeUpToDown - End");

        }


        public void DownToUp()
        {
            Console.WriteLine("N0rf3n - DownToUp - Begin");
            var animator = new UIViewPropertyAnimator(0.3, new UIViewAnimationCurve(), () =>
            {

                viewAnimate.Frame = new CGRect(viewAnimate.Frame.X, viewAnimate.Frame.Y + (viewAnimate.Frame.Height - 20), viewAnimate.Frame.Width, viewAnimate.Frame.Height);
                Console.WriteLine("N0rf3n - DownToUp");
                
            });

            animator.StartAnimation();
            Console.WriteLine("N0rf3n - DownToUp - End");

        }

        public void UpToDown()
        {
            Console.WriteLine("N0rf3n - UpToDown - Begin");
            var animator = new UIViewPropertyAnimator(0.3, new UIViewAnimationCurve(), () => {

                viewAnimate.Frame = new CGRect(viewAnimate.Frame.X, viewAnimate.Frame.Y - (viewAnimate.Frame.Height - 20), viewAnimate.Frame.Width, viewAnimate.Frame.Height);
                
                Console.WriteLine("N0rf3n - UpToDown");
            });

            animator.StartAnimation();
            Console.WriteLine("N0rf3n - UpToDown - End");

        }
    }
}