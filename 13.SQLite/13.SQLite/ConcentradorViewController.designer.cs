// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _13.SQLite
{
	[Register ("ConcentradorViewController")]
	partial class ConcentradorViewController
	{
		[Outlet]
		UIKit.UITableView tbTabla { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tbTabla != null) {
				tbTabla.Dispose ();
				tbTabla = null;
			}
		}
	}
}
