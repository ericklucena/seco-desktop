using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HackerCidadao4.Services
{
    class Network
    {
        private const string GET_SENSORS = "http://172.19.5.253/embarquelab/downloads/EL_sensores_json.php";
        private const string GET_GAS_SENSOR = "https://e115dc0e-a589-42bd-87bd-715cd63833d5-bluemix.cloudant.com/emprel-iot/_all_docs?&limit=1&include_docs=true&descending=true";

        public static string SensorsData()
        {
            return GetResponse(GET_SENSORS);
        }

        public static string MultiSensorData()
        {
            return GetResponse(GET_GAS_SENSOR);
        }

        private static string GetResponse(string url)   
        {
            string webresponse = null;

            // create a new instance of WebClient
            WebClient client = new WebClient();

            // set the user agent to IE6
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
            try
            {
                // actually execute the GET request
                webresponse = client.DownloadString(new Uri(url));
            
            }
            catch (WebException we)
            {
                // WebException.Status holds useful information
                Console.WriteLine(we.Message + "\n" + we.Status.ToString());
            }
            catch (NotSupportedException ne)
            {
                // other errors
                Console.WriteLine(ne.Message);
            }
            catch
            {

            }

            return webresponse;
        }

    }
}
