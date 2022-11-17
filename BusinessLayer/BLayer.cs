using BusinessObjects;
using dbllayer123;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// kalles fra web. BLayer kaller DBL
    /// </summary>
    public class BLayer
    {
        public List<WeatherReading> GetWeatherReadingByYearMonthAndDay(string TextBoxS, string TextBoxS1, string TextBoxS2)
        {
            DBL dbl = new DBL();
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetWeatherReadingByYearMonthAndDay(TextBoxS, TextBoxS1, TextBoxS2);
        }

        public void Insert(int year, int month, int day, int hour, float temprature, float precipiation, float humidity, float windDirection, float windSpeed, float windSpeedOfGust)
        {
            //call dbl
        }



    }
}
