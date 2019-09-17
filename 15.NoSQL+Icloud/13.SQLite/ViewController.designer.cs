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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnFotografia { get; set; }

		[Outlet]
		UIKit.UIButton btnGuardar { get; set; }

		[Outlet]
		UIKit.UIImageView imgImagen { get; set; }

		[Outlet]
		UIKit.UITextField txtCorreo { get; set; }

		[Outlet]
		UIKit.UITextField txtEmpresa { get; set; }

		[Outlet]
		UIKit.UITextField txtNombre { get; set; }

		[Outlet]
		UIKit.UITextField txtPuesto { get; set; }

		[Outlet]
		UIKit.UITextView txtVisor { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtNombre != null) {
				txtNombre.Dispose ();
				txtNombre = null;
			}

			if (txtPuesto != null) {
				txtPuesto.Dispose ();
				txtPuesto = null;
			}

			if (txtEmpresa != null) {
				txtEmpresa.Dispose ();
				txtEmpresa = null;
			}

			if (txtCorreo != null) {
				txtCorreo.Dispose ();
				txtCorreo = null;
			}

			if (btnFotografia != null) {
				btnFotografia.Dispose ();
				btnFotografia = null;
			}

			if (btnGuardar != null) {
				btnGuardar.Dispose ();
				btnGuardar = null;
			}

			if (txtVisor != null) {
				txtVisor.Dispose ();
				txtVisor = null;
			}

			if (imgImagen != null) {
				imgImagen.Dispose ();
				imgImagen = null;
			}
		}
	}
}
