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

        protected ViewController(IntPtr handle) : base(handle)
        {

            //AL momento de iniciar
            Lista = DatosLista();
        }

        public List<Datos> DatosLista() //Datos con los cuales se va cargar el mapa.
        {
            var InformacionLista = new List<Datos>() //Esto es una instanacia.
            {
                new Datos("Bucaramanga", 7.1253901, -73.1197968),
                new Datos("Bogotá", 4.6097102, -74.081749),
                new Datos("Medellin", 6.2518401, -75.563591)
            };

            return InformacionLista;

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Console.WriteLine("N0rf3n - ViewDidLoad - Begin ");

            try
            {
                var CentrarMapa = new CLLocationCoordinate2D(4.6097102, -74.081749);
                var AlturaMapa = new MKCoordinateSpan(.003, .003);
                var Region = new MKCoordinateRegion(CentrarMapa, AlturaMapa);
                mpMapa.SetRegion(Region, true); //Se asigna la región en el mapa.

                Selector.ValueChanged += (sender, e) => //Cuando el selector cambie, se le va asignar un evento.
                {

                    switch (Selector.SelectedSegment) //Para cuando cambiar el valor del selector.
                    {
                        case 0: //Mapa Estandar
                            mpMapa.MapType = MKMapType.Standard;
                            break;

                        case 1: //Mapa Satellite
                            mpMapa.MapType = MKMapType.Satellite;
                            break;

                        case 2: //Mapa Hibrido
                            mpMapa.MapType = MKMapType.HybridFlyover;
                            break;
                    }
                };

                Lista.ForEach(x => mpMapa.AddAnnotation(new MKPointAnnotation()    //ciclo para la vista y se agregara un marcador en el mapa
                {
                    Title = x.Titulo,
                    Coordinate = new CLLocationCoordinate2D()
                    {
                        Latitude = x.Latitud,
                        Longitude = x.Longitud
                    }

                }));

                var Leon = new CLLocationCoordinate2D(21.1502859, -101.7104848); //origen y destino deseado
                var CDMX = new CLLocationCoordinate2D(19.4329256, -99.1334383); //origen y destino deseado
        
                var Info = new NSDictionary();//Variable de tipo diccionario

                var OrigenDestino = new MKDirectionsRequest()
                {
                    Source = new MKMapItem(new MKPlacemark(Leon, Info)),//Origen
                    Destination = new MKMapItem(new MKPlacemark(CDMX, Info)),//Destino
                };

                MKDirections mKDirections = new MKDirections(OrigenDestino);
                MKDirections Direcciones = mKDirections;
                Direcciones.CalculateDirections((response, error) => //aqui se realiza el calculo de la ruta
                {
                    //Se empizan a definir las propiedades para el trazo de la ruta.

                    var Ruta = response.Routes[0]; //ruta!
                    var Linea = new MKPolylineRenderer(Ruta.Polyline)//Se debe asignar una linea
                    {
                        //Aqui van las propiedades de la linea en la ruta.
                        LineWidth = 5.0f, //ancho de la linea
                        StrokeColor = UIColor.Blue//Color de la linea


                    };

                    mpMapa.OverlayRenderer = (mapView, overlay) => Linea;//Asignación de la linea o linea sobre el mapa.
                    mpMapa.AddOverlay(Ruta.Polyline,
                                      MKOverlayLevel.AboveRoads); //Se agrega la ruta en el mapa y Va pasar por encima de las etiquetas "MKOverlayLevel.AboveRoads"


                });

                Console.WriteLine("N0rf3n - ViewDidLoad - End ");

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

        public Datos(string titulo, double latitud, double longitud) //la clase recibe 3 valores.
        {
            Titulo = titulo;
            Latitud = latitud;
            Longitud = longitud;
        }

        //Getters and Setters
        public string Titulo { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
