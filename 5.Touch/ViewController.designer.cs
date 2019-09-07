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
		UIKit.UILabel lblValueX { get; set; }

		[Outlet]
		UIKit.UILabel lblValueY { get; set; }

		[Outlet]
		UIKit.UILabel lblValueZ { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblValueX != null) {
				lblValueX.Dispose ();
				lblValueX = null;
			}

			if (lblValueY != null) {
				lblValueY.Dispose ();
				lblValueY = null;
			}

			if (lblValueZ != null) {
				lblValueZ.Dispose ();
				lblValueZ = null;
			}
		}
	}
}
