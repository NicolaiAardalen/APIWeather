using BusinessObjects;
using dbllayer123;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BusinessLayer
{
    public class BLayer
    {
        private DBL dbl = new DBL();
        public void Insert(int year, int month, int day, int hour, float temprature, float precipitation, float humidity, float windDirection, float windSpeed, float windSpeedOfGust, string sky)
        {
            dbl.Insert(year, month, day, hour, temprature, precipitation, humidity, windDirection, windSpeed, windSpeedOfGust, sky);
        }
        public List<WeatherReading> GetWeatherReadingByYearMonthAndDay(string Year, string Month, string Day)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetWeatherReadingByYearMonthAndDay(Year, Month, Day);
        }
        public List<WeatherReading> GetWeatherReadingByYearAndMonth(string Year, string Month)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetWeatherReadingByYearAndMonth(Year, Month);
        }
        public List<WeatherReading> GetWeatherReadingByYear(string Year)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetWeatherReadingByYear(Year);
        }
        public List<WeatherReading> GetLast24hours()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetLast24hours();
        }
        public List<WeatherReading> GetLast24hoursForGraph()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetLast24hoursForGraph();
        }
        public List<WeatherReading> GetSpecificDay()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetSpecificDay();
        }
        public List<WeatherReading> GetSpecificMonth()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetSpecificMonth();
        }
        public List<WeatherReading> GetSpecificYear()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.GetSpecificYear();
        }
        public List<WeatherReading> UpdateGridviewByButtonOnDaySite(int year,int month,int day)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.UpdateGridviewByButtonOnDaySite(year, month, day);
        }
        public List<WeatherReading> UpdateGridviewByButtonOnMonthSite(int Year, int Month)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.UpdateGridviewByButtonOnMonthSite(Year, Month);
        }
        public List<WeatherReading> UpdateGridviewByButtonOnYearSite(DropDownList Year)
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.UpdateGridviewByButtonOnYearSite(Year);
        }
        public List<WeatherReading> Last24HourGraph()
        {
            List<WeatherReading> list = new List<WeatherReading>();
            return dbl.Last24HourGraph();
        }

        public List<int> GetYearsInDB()
        {
            return dbl.GetYearsInDB();
        }
        //public List<int> GetMonthsInDB()
        //{
        //    return dbl.GetMonthsInDB();
        //}
        //public List<int> GetDaysInDB()
        //{
        //    return dbl.GetDaysInDB();
        //}
    }
}
