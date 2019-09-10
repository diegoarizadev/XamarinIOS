// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace _7.Rutas
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		MapKit.MKMapView mpMapa { get; set; }

		[Outlet]
		UIKit.UISegmentedControl Selector { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Selector != null) {
				Selector.Dispose ();
				Selector = null;
			}

			if (mpMapa != null) {
				mpMapa.Dispose ();
				mpMapa = null;
			}
		}
	}
}
