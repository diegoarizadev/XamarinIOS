// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _6.Mapas
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel lblCiudad { get; set; }

		[Outlet]
		UIKit.UILabel lblDepartamento { get; set; }

		[Outlet]
		UIKit.UILabel lblLatitud { get; set; }

		[Outlet]
		UIKit.UILabel lblLongitud { get; set; }

		[Outlet]
		UIKit.UILabel lblMunicipio { get; set; }

		[Outlet]
		UIKit.UILabel lblPais { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblPais != null) {
				lblPais.Dispose ();
				lblPais = null;
			}

			if (lblDepartamento != null) {
				lblDepartamento.Dispose ();
				lblDepartamento = null;
			}

			if (lblCiudad != null) {
				lblCiudad.Dispose ();
				lblCiudad = null;
			}

			if (lblMunicipio != null) {
				lblMunicipio.Dispose ();
				lblMunicipio = null;
			}

			if (lblLatitud != null) {
				lblLatitud.Dispose ();
				lblLatitud = null;
			}

			if (lblLongitud != null) {
				lblLongitud.Dispose ();
				lblLongitud = null;
			}
		}
	}
}
