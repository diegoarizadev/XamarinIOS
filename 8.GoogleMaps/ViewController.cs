using Foundation;
using System;
using UIKit;
using CoreLocation;
using CoreGraphics;
using Google.Maps;


namespace _8.GoogleMaps
{
    public partial class ViewController : UIViewController
    {
        MapView Mapa;//Se decalara un objecto de tipo MapView
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CameraPosition Camera = CameraPosition.FromCamera(41.887, -87.622, 15, 30, 40); //Se instalancia el CLLocationCoordinate2D con la ubicación, el angulo y la altura que va a tener la unicación.

            Mapa = MapView.FromCamera(CGRect.Empty, Camera); //la pantalla o mapa la queremos ver en toda la pantalla, colocamos CGRect.Empty

            var Marcador = new Marker() //Un marcador para agregar en el mapa
            {

                Title = "Chicago",
                Icon = UIImage.FromFile("IconMaps.png"),
                AppearAnimation = MarkerAnimation.Pop,
                Snippet = "Ciudad de Chicago - N0rf3n",
                Position = new CLLocationCoordinate2D(41.887, -87.622),
                Map = Mapa
            };

            Mapa.SelectedMarker = Marcador; //como ya se tiene el marcado se agrega al mapa.
            View = Mapa;

        }

    }
}