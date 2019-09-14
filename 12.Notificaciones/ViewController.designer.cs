// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _12.Notificaciones
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnNotificacionesCalendario { get; set; }

		[Outlet]
		UIKit.UIButton btnNotificacionesIntervalo { get; set; }

		[Outlet]
		UIKit.UIButton btnNotificacionesSRespuesta { get; set; }

		[Outlet]
		UIKit.UIDatePicker Calendario { get; set; }

		[Outlet]
		UIKit.UILabel lblRespuesta { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNotificacionesSRespuesta != null) {
				btnNotificacionesSRespuesta.Dispose ();
				btnNotificacionesSRespuesta = null;
			}

			if (btnNotificacionesCalendario != null) {
				btnNotificacionesCalendario.Dispose ();
				btnNotificacionesCalendario = null;
			}

			if (btnNotificacionesIntervalo != null) {
				btnNotificacionesIntervalo.Dispose ();
				btnNotificacionesIntervalo = null;
			}

			if (Calendario != null) {
				Calendario.Dispose ();
				Calendario = null;
			}

			if (lblRespuesta != null) {
				lblRespuesta.Dispose ();
				lblRespuesta = null;
			}
		}
	}
}
