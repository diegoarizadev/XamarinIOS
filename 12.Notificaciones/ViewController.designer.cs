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
		UIKit.UIButton btnNotificacionesRespuesta { get; set; }

		[Outlet]
		UIKit.UIDatePicker Calendario { get; set; }

		[Outlet]
		UIKit.UILabel lblRespuesta { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNotificacionesIntervalo != null) {
				btnNotificacionesIntervalo.Dispose ();
				btnNotificacionesIntervalo = null;
			}

			if (btnNotificacionesCalendario != null) {
				btnNotificacionesCalendario.Dispose ();
				btnNotificacionesCalendario = null;
			}

			if (btnNotificacionesRespuesta != null) {
				btnNotificacionesRespuesta.Dispose ();
				btnNotificacionesRespuesta = null;
			}

			if (lblRespuesta != null) {
				lblRespuesta.Dispose ();
				lblRespuesta = null;
			}

			if (Calendario != null) {
				Calendario.Dispose ();
				Calendario = null;
			}
		}
	}
}
