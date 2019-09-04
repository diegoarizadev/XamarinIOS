// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _2.AccesoAVideos
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnVideoInternet { get; set; }

		[Outlet]
		UIKit.UIButton btnVideoLocal { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnVideoInternet != null) {
				btnVideoInternet.Dispose ();
				btnVideoInternet = null;
			}

			if (btnVideoLocal != null) {
				btnVideoLocal.Dispose ();
				btnVideoLocal = null;
			}
		}
	}
}
