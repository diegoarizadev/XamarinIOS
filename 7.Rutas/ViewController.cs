using Foundation;
using System;
using UIKit;
using CoreLocation;
using MapKit;
using System.Collections.Generic;

namespace _7.Rutas
{
    public partial class ViewController : UIViewController
    {

        List<Datos> Lista; //Se crea una lista de la clase Datos

        public ViewController(IntPtr handle) : base(handle)
        {

            //AL momento de iniciar
            Lista = DatosLista();
        }

        public List<Datos> DatosLista() //Datos con los cuales se va cargar el mapa.
        {
            var InformacionLista = new List<Datos>() //Esto es una instanacia.
            {
                new Datos("Bogota", 4.570868, -74.2973328),
                new Datos("Medellin", 6.2518400, -75.5635900),
                new Datos("Bucaramanga",  7.11392, -73.1198)
            };

            return InformacionLista;

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                var CentrarMapa = new CLLocationCoordinate2D(4.570868, -74.2973328); 
                var AlturaMapa = new MKCoordinateSpan(.003, .003);
                var Region = new MKCoordinateRegion(CentrarMapa, AlturaMapa);
                mpMapa.SetRegion(Region, true); //Se asigna la región en el mapa.

                Selector.ValueChanged += (sender, e) => //Cuando el selector cambie, se le va asignar un evento.
                {

                    switch(Selector.SelectedSegment) //Para cuando cambiar el valor del selector.
                    {
                        case 0: //Mapa Estandar
                            mpMapa.MapType =  MKMapType.Standard;
                            break;

                        case 1: //Mapa Satellite
                            mpMapa.MapType = MKMapType.Satellite;
                            break;

                        case 2: //Mapa Hibrido
                            mpMapa.MapType = MKMapType.HybridFlyover;
                            break;
                    }
                };

                Lista.ForEach(x => mpMapa.AddAnnotation(new MKPointAnnotation()    //ciclo para la lista y se agregara un marcador
                {
                    Title = x.Titulo,
                    Coordinate = new CLLocationCoordinate2D() {
                        Latitude = x.Latitud,
                        Longitude = x.Longitud
                    }

                }));

                var Bogota = new CLLocationCoordinate2D(4.570868, -74.2973328); //origen y destino deseado
                var Medellin = new CLLocationCoordinate2D(6.2518400, -75.5635900); //origen y destino deseado
                var Info = new NSDictionary();//Variable de tipo diccionario

                var OrigenDestino = new MKDirectionsRequest()
                {
                    Source = new MKMapItem(new MKPlacemark(Bogota, Info)),//Origen
                    Destination = new MKMapItem(new MKPlacemark(Medellin, Info)),//Destino
                };

                var Direcciones = new MKDirections(OrigenDestino);
                Direcciones.CalculateDirections((response, error) => {//aqui se realiza el calculo de la ruta

                    //Se empizan a definir las propiedades para el trazo de la ruta.

                    var Ruta = response.Routes[0]; //ruta!
                    var Linea = new MKPolylineRenderer(Ruta.Polyline)//Se debe asignar una linea
                    {
                        //Aqui van las propiedades de la linea en la ruta.
                        LineWidth = 5.0f, //ancho de la linea
                        StrokeColor = UIColor.Blue//Color de la linea


                    };

                    mpMapa.OverlayRenderer = (mapView, overly) => Linea;//Asignación de la linea o linea sobre el mapa.
                    mpMapa.AddOverlay(Ruta.Polyline, MKOverlayLevel.AboveRoads); //Se agrega la ruta en el mapa y Va pasar por encima de las etiquetas "MKOverlayLevel.AboveRoads"


                });

            }
            catch (Exception ex)
            {

                Console.WriteLine("N0rf3n - ViewDidLoad - End/Catch Error : " + ex.Message);

                var alerta = UIAlertController.Create("Estado",
                                              ex.Message,
                                              UIAlertControllerStyle.Alert);


                alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

                PresentViewController(alerta, true, null);

            }

        }


    }


    //Creación de una clase nueva
    public class Datos
    {

        public Datos(String titulo, double latitud, double longitud) //la clase recibe 3 valores.
        {
            Titulo = titulo;
            Latitud = latitud;
            Longitud = longitud;
        }

        //Getters and Setters
        public String Titulo { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}