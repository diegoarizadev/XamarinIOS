// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _14.Rest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnConsultarClima { get; set; }

		[Outlet]
		UIKit.UILabel lblCondiciones { get; set; }

		[Outlet]
		UIKit.UILabel lblHumedad { get; set; }

		[Outlet]
		UIKit.UILabel lblLocalidad { get; set; }

		[Outlet]
		UIKit.UILabel lblTemperatura { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblLocalidad != null) {
				lblLocalidad.Dispose ();
				lblLocalidad = null;
			}

			if (lblTemperatura != null) {
				lblTemperatura.Dispose ();
				lblTemperatura = null;
			}

			if (lblHumedad != null) {
				lblHumedad.Dispose ();
				lblHumedad = null;
			}

			if (lblCondiciones != null) {
				lblCondiciones.Dispose ();
				lblCondiciones = null;
			}

			if (btnConsultarClima != null) {
				btnConsultarClima.Dispose ();
				btnConsultarClima = null;
			}
		}
	}
}
