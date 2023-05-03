using BusinessLayer;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading;
using static WeatherD.WeatherData;

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
                    var JsonHTTPRequest = classes.properties.timeseries[0].data.instant.details;
                    var JsonHTTPRequestSky = classes.properties.timeseries[0].data.next_1_hours.summary;

                    float temperatur = JsonHTTPRequest.air_temperature;
                    float millimeter = JsonHTTPRequest.precipitation_rate;
                    float luftfuktighet = JsonHTTPRequest.relative_humidity;
                    float vindretning = JsonHTTPRequest.wind_from_direction;
                    float vindhastighet = JsonHTTPRequest.wind_speed;
                    float vindkasthastighet = JsonHTTPRequest.wind_speed_of_gust;
                    string sky = JsonHTTPRequestSky.symbol_code;

                    var BLayer = new BLayer();
                    BLayer.Insert(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, temperatur, millimeter, luftfuktighet, vindretning, vindhastighet, vindkasthastighet, sky);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("C:\\Harvester\\Log.txt", DateTime.Now.ToString() + " " + ex.Message + " - " + ex.InnerException + "\n");
                return 0;
            }
            return 1;
        }
    }
}