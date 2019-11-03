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

namespace _18.Slidingmenu.ViewControllers
{
    [Register ("MenuTableViewController")]
    partial class MenuTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imagen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTexto { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imagen != null) {
                imagen.Dispose ();
                imagen = null;
            }

            if (lblTexto != null) {
                lblTexto.Dispose ();
                lblTexto = null;
            }
        }
    }
}