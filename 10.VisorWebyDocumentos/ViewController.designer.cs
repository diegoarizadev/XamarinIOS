// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _10.VisorWebyDocumentos
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnDocumentos { get; set; }

		[Outlet]
		UIKit.UIButton btnVisorWeb1 { get; set; }

		[Outlet]
		UIKit.UIButton btnVisorWeb2 { get; set; }

		[Outlet]
		UIKit.UIButton btnVisorWeb3 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnDocumentos != null) {
				btnDocumentos.Dispose ();
				btnDocumentos = null;
			}

			if (btnVisorWeb1 != null) {
				btnVisorWeb1.Dispose ();
				btnVisorWeb1 = null;
			}

			if (btnVisorWeb2 != null) {
				btnVisorWeb2.Dispose ();
				btnVisorWeb2 = null;
			}

			if (btnVisorWeb3 != null) {
				btnVisorWeb3.Dispose ();
				btnVisorWeb3 = null;
			}
		}
	}
}
