﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace _18.Slidingmenu
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitulo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewMenu { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblTitulo != null) {
                lblTitulo.Dispose ();
                lblTitulo = null;
            }

            if (tableViewMenu != null) {
                tableViewMenu.Dispose ();
                tableViewMenu = null;
            }
        }
    }
}