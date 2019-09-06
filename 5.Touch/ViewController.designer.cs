// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _5.Touch
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel lblX { get; set; }

		[Outlet]
		UIKit.UILabel lblY { get; set; }

		[Outlet]
		UIKit.UILabel lblZ { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblX != null) {
				lblX.Dispose ();
				lblX = null;
			}

			if (lblY != null) {
				lblY.Dispose ();
				lblY = null;
			}

			if (lblZ != null) {
				lblZ.Dispose ();
				lblZ = null;
			}
		}
	}
}
