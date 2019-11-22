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

namespace _19.TableViewExpandible
{
    [Register ("TableCell")]
    partial class TableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UILabel lblCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblCell != null) {
                lblCell.Dispose ();
                lblCell = null;
            }
        }
    }
}