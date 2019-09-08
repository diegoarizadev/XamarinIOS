using CoreLocation;
using Foundation;
using MapKit;
using Plugin.Geolocator;
using System;
using UIKit;
using Xamarin.Essentials;



namespace _6.Mapas
{
    public partial class ViewController : UIViewController
    {
        double  Latitud, Longitud;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            mpMapa.ShowsUserLocation = true;
            var Localizador = CrossGeolocator.Current;
            var Posicion = await Localizador.GetPositionAsync(TimeSpan.FromSeconds(10), null, true); //obtener la posición cada 10 segundos.
            var Ubicacion = new CLLocation(Posicion.Latitude, Posicion.Longitude);
            var Georeferencia = new CLGeocoder();
            var DatosGeo = await Georeferencia.ReverseGeocodeLocationAsync(Ubicacion);


            Latitud = Posicion.Latitude;
            Longitud = Posicion.Longitude;

            lblCiudad.Text = DatosGeo[0].Locality;
            lblDepartamento.Text = DatosGeo[0].AdministrativeArea;
            lblLatitud.Text = Latitud.ToString();
            lblLongitud.Text = Longitud.ToString();
            lblMunicipio.Text = DatosGeo[0].SubLocality;
            lblPais.Text = DatosGeo[0].Country;
            txtDescripcion.Text = DatosGeo[0].Description;

            mpMapa.MapType = MapKit.MKMapType.HybridFlyover; //Se establece el tipo de mapa
            var CentrarMapa = new CLLocationCoordinate2D(Latitud, Longitud);
            var AlturaMapa = new MKCoordinateSpan(.003, .003);
            var Region = new MKCoordinateRegion(CentrarMapa, AlturaMapa);
            mpMapa.SetRegion(Region, true );


        }


    }
}