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
	[Register ("CeldaController")]
	partial class CeldaController
	{
		[Outlet]
		UIKit.UIImageView image { get; set; }

		[Outlet]
		UIKit.UILabel lblCorreo { get; set; }

		[Outlet]
		UIKit.UILabel lblEmpresa { get; set; }

		[Outlet]
		UIKit.UILabel lblNombre { get; set; }

		[Outlet]
		UIKit.UILabel lblPuesto { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblNombre != null) {
				lblNombre.Dispose ();
				lblNombre = null;
			}

			if (lblPuesto != null) {
				lblPuesto.Dispose ();
				lblPuesto = null;
			}

			if (lblCorreo != null) {
				lblCorreo.Dispose ();
				lblCorreo = null;
			}

			if (lblEmpresa != null) {
				lblEmpresa.Dispose ();
				lblEmpresa = null;
			}

			if (image != null) {
				image.Dispose ();
				image = null;
			}
		}
	}
}
