using Foundation;
using System;
using UIKit;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Plugin.Geolocator;
using System.Security.Policy;

namespace _14.Rest
{
    public partial class ViewController : UIViewController
    {
        double latitud, longitud;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            Console.WriteLine("N0rf3n - ViewDidLoad - Begin ");
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnConsultarClima.TouchUpInside += async delegate
            {

                Console.WriteLine("N0rf3n - btnConsultarClima - Begin ");

                var Localizador = CrossGeolocator.Current;
                var posicion = await Localizador.GetLastKnownLocationAsync();
                posicion = await Localizador.GetPositionAsync(TimeSpan.FromSeconds(10), null, true);
                latitud = posicion.Latitude;
                Console.WriteLine("N0rf3n - btnConsultarClima - latitud :  "+ latitud);
                longitud = posicion.Longitude;
                Console.WriteLine("N0rf3n - btnConsultarClima - longitud :  " + longitud);


                var output = string.Format("N0rf3n - btnConsultarClima - Time: {0} \nLat: {1} \nLong: {2} \nAltitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \nHeading: {6} \nSpeed: {7}",
                    posicion.Timestamp, posicion.Latitude, posicion.Longitude,
                    posicion.Altitude, posicion.AltitudeAccuracy, posicion.Accuracy, posicion.Heading, posicion.Speed);

                Console.WriteLine(output);


                var ServicioREST = "http://api.geonames.org/findNearByWeatherJSON?lat=" +latitud + "&lng=" + longitud + "&username=enrique.aguilar"; //ruta del servicio
                Console.WriteLine("N0rf3n - btnConsultarClima - ServicioREST : "+ ServicioREST);
                JsonValue json = await TraerClima(ServicioREST);
                Transformar(json);

                Console.WriteLine("N0rf3n - btnConsultarClima - End ");

            };

            Console.WriteLine("N0rf3n - ViewDidLoad - End ");


        }


        public async Task<JsonValue> TraerClima(string ServicioREST)
        {
            Console.WriteLine("N0rf3n - TraerClima - Begin ");
            Console.WriteLine("N0rf3n - TraerClima - ServicioREST : " + ServicioREST);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(ServicioREST));//consumir el servicio.
            //WebRequest request = WebRequest.Create(new Uri(ServicioREST));//consumir el servicio.
            Console.WriteLine("N0rf3n - TraerClima - request : "+ request);
            request.ContentType = "application/json";//Tipo de consumo
            request.Method = "GET/POST";//metodo de consumo
            using (WebResponse response = await request.GetResponseAsync())//A la espera del response con el request
            {

                using (Stream stream = response.GetResponseStream())//Carga los datos del request
                {
                    var jsondoc = await Task.Run(() => JsonValue.Load(stream));//Parseo directo del String
                    Console.WriteLine("N0rf3n - TraerClima - jsondoc : "+ jsondoc);
                    Console.WriteLine("N0rf3n - TraerClima - End ");
                    return jsondoc;
                }
            }
        }



        //toma la respuesta o request del servio para colocarlo en el viewController
        public void Transformar(JsonValue json)
        {
            Console.WriteLine("N0rf3n - Transformar - Begin ");
            Console.WriteLine("N0rf3n - Transformar - json :  "+ json);
            var Resultados = json["weatherObservation"];
            lblLocalidad.Text = Resultados["stationName"];
            var temperatura = Resultados["temperature"];
            lblTemperatura.Text = string.Format("{0}", temperatura) + "C";
            var Humedad = Resultados["humidity"];
            lblHumedad.Text = Humedad.ToString() + "%";
            var Nubes = Resultados["clouds"];
            var Condiciones = Resultados["weatherCondition"];
            lblCondiciones.Text = Nubes + ", " + Condiciones;
            Console.WriteLine("N0rf3n - Transformar - End ");
        }
    }
}