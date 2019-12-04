using CoreGraphics;
using Foundation;
using System;
using System.Drawing;
using UIKit;

namespace _22.MultipleGestures
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        private float _scale;
        private float _angle;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var gestureView = new UIView()
            {
                Frame = new RectangleF(PointF.Empty, new SizeF(200, 200)),
                BackgroundColor = UIColor.Red
            };

            View.AddSubview(gestureView);

            var panGesture = new UIPanGestureRecognizer((g) =>
            {
                var t = g.TranslationInView(View);
                var frame = gestureView.Frame;
                frame.X = t.X;
                frame.Y = t.Y;
                gestureView.Frame = frame;
            });

            var pinchGesture = new UIPinchGestureRecognizer((g) =>
            {
                _scale = (float)g.Scale;

                gestureView.Transform = MakeTransform();
            });

            var rotateGesture = new UIRotationGestureRecognizer((g) =>
            {
                _angle = (float)g.Rotation;

                gestureView.Transform = MakeTransform();
            });

            panGesture.ShouldRecognizeSimultaneously = (gesture1, gesture2) => gesture2 == pinchGesture || gesture2 == rotateGesture;
            pinchGesture.ShouldRecognizeSimultaneously = (gesture1, gesture2) => gesture2 == panGesture || gesture2 == rotateGesture;
            rotateGesture.ShouldRecognizeSimultaneously = (gesture1, gesture2) => gesture2 == panGesture || gesture2 == pinchGesture;

            gestureView.AddGestureRecognizer(panGesture);
            gestureView.AddGestureRecognizer(pinchGesture);
            gestureView.AddGestureRecognizer(rotateGesture);

        }

        private CGAffineTransform MakeTransform()
        {
            var transform = CGAffineTransform.MakeIdentity();
            transform.Scale(_scale, _scale);
            transform.Rotate(_angle);
            return transform;
        }
    
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}