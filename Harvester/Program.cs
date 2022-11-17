using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using static BusinessObjects.WeatherReading;
using static WeatherD.WeatherData;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Configuration;

using BusinessLayer;

namespace Harvester
{
    public class Harvest
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                if (DateTime.Now.Minute == 0)
                {
                    int code = GetData();
                    while (code == 0)
                    {
                        GetData();
                        Thread.Sleep(5000);
                    }
                    Thread.Sleep(60000);
                }
                Thread.Sleep(10000);
            }
        }
        static int GetData()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.218632&lon=10.943399");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = "bolle";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var classes = JsonSerializer.Deserialize<Weather>(result);
                    float temperatur = classes.properties.timeseries[0].data.instant.details.air_temperature;
                    float millimeter = classes.properties.timeseries[0].data.instant.details.precipitation_rate;
                    float luftfuktighet = classes.properties.timeseries[0].data.instant.details.relative_humidity;
                    float vindretning = classes.properties.timeseries[0].data.instant.details.wind_from_direction;
                    float vindhastighet = classes.properties.timeseries[0].data.instant.details.wind_speed;
                    float vindkasthastighet = classes.properties.timeseries[0].data.instant.details.wind_speed_of_gust;

                    //call bl
                    var DBL = new DBL();
                    DBL.Insert(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, temperatur, millimeter, luftfuktighet, vindretning, vindhastighet, vindkasthastighet);
                }
            }
            catch(Exception ex) 
            {
                File.AppendAllText("C:\\Harvester\\Log.txt",DateTime.Now.ToString() + " " + ex.Message + " - " + ex.InnerException + "\n");
                return 0; 
            }
            return 1;
        }
    }
}