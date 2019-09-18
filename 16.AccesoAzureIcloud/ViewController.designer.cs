// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _16.AccesoAzureIcloud
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView tabla { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tabla != null) {
				tabla.Dispose ();
				tabla = null;
			}
		}
	}
}
