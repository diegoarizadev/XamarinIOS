// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _11.PatronAutoFac
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnAutoFac { get; set; }

		[Outlet]
		UIKit.UILabel lblResultado { get; set; }

		[Outlet]
		UIKit.UITextField txtInfo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtInfo != null) {
				txtInfo.Dispose ();
				txtInfo = null;
			}

			if (btnAutoFac != null) {
				btnAutoFac.Dispose ();
				btnAutoFac = null;
			}

			if (lblResultado != null) {
				lblResultado.Dispose ();
				lblResultado = null;
			}
		}
	}
}
