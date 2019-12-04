// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace _21.UIViewAnimate
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewAnimate { get; set; }

        [Action ("ActionBajar:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionBajar (UIKit.UIButton sender);

        [Action ("ActionSubir:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionSubir (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (viewAnimate != null) {
                viewAnimate.Dispose ();
                viewAnimate = null;
            }
        }
    }
}