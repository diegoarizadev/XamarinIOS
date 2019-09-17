
using System;
using UIKit;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Plugin.Geolocator;
using Newtonsoft.Json;

namespace _14.Rest
{
    public partial class ViewController : UIViewController
    {
        double latitud, longitud;
        WebResponse response;
        private JsonValue jsondoc;


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
                Clima p = await TraerClima(ServicioREST);
                // Close the response.  
                response.Close();
                Transformar(p);

                Console.WriteLine("N0rf3n - btnConsultarClima - End ");

            };

            Console.WriteLine("N0rf3n - ViewDidLoad - End ");


        }


        public async Task<Clima> TraerClima(string ServicioREST)
        {
            Console.WriteLine("N0rf3n - TraerClima - Begin ");
            Console.WriteLine("N0rf3n - TraerClima - ServicioREST : " + ServicioREST);

            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(ServicioREST);

            // Get the response.  
            response = request.GetResponse();

            // Display the status.  
            Console.WriteLine("N0rf3n - TraerClima -  : status" + ((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server. 
            // The using block ensures the stream is automatically closed. 
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();

                // Display the content.  
                Console.WriteLine("N0rf3n - TraerClima - responseFromServer : " + responseFromServer);

                //Deserializa el objecto JSon de la respuesta del sW
                Clima c = await Task.Run(() => JsonConvert.DeserializeObject<Clima>(responseFromServer));

                
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.elevation);
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.lng);
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.observation);
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.ICAO);
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.clouds);
                Console.WriteLine("N0rf3n - TraerClima -  : " + c.WeatherObservation.dewPoint);

                return c;

            }
        }

        /*Funcion original... no me sirvio.!
               public async Task<JsonValue> TraerClima(string ServicioREST)
        {
            var request = (HttpWebRequest)WebRequest.Create
                                                    (new Uri(ServicioREST));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var jsondoc = await Task.Run(() => 
                                        JsonValue.Load(stream));
                    return jsondoc;
                }
            }
        }
         */

        //toma la respuesta o request del servio para colocarlo en el viewController
        public void Transformar(Clima climaco)
        {
            Console.WriteLine("N0rf3n - Transformar - Begin ");
            lblLocalidad.Text = climaco.WeatherObservation.stationName;
            var temperatura = climaco.WeatherObservation.temperature; 
            lblTemperatura.Text = string.Format("{0}", temperatura) + "C";
            var Humedad = climaco.WeatherObservation.seaLevelPressure;
            lblHumedad.Text = Humedad.ToString() + "%";
            var Nubes = climaco.WeatherObservation.clouds;
            var Condiciones = climaco.WeatherObservation.weatherCondition;
            lblCondiciones.Text = Nubes + ", " + Condiciones;
            Console.WriteLine("N0rf3n - Transformar - End ");
        }
    }


    //Se escriben las clases para la deserialización de la respuesta del servicio.
    public  class Clima
    {
        public WeatherObservation WeatherObservation { get; set; }
    }

    public class WeatherObservation
    {

        public long elevation { get; set; }

        public double lng { get; set; }

        public string observation { get; set; }

        public string ICAO { get; set; }

        public string clouds { get; set; }

        public string dewPoint { get; set; }

        public DateTimeOffset datetime { get; set; }

        public double seaLevelPressure { get; set; }

        public string countryCode { get; set; }

        public string temperature { get; set; }

        public string stationName { get; set; }

        public string weatherCondition { get; set; }

        public double lat { get; set; }

    }
}