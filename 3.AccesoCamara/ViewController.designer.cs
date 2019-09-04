// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _3.AccesoCamara
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnBiblioteca { get; set; }

		[Outlet]
		UIKit.UIButton btnCamara { get; set; }

		[Outlet]
		UIKit.UIImageView imagenes { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnBiblioteca != null) {
				btnBiblioteca.Dispose ();
				btnBiblioteca = null;
			}

			if (btnCamara != null) {
				btnCamara.Dispose ();
				btnCamara = null;
			}

			if (imagenes != null) {
				imagenes.Dispose ();
				imagenes = null;
			}
		}
	}
}
