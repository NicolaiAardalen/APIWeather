using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class WeatherReading
    {
        public int WeatherId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }  
        public int Day { get; set; }
        public int Hour { get; set; }
        public double Temperature { get; set; }
        public double Precipiation { get; set; }
        public double Humidity { get; set; }
        public double WindDirection { get; set; }
        public double WindSpeed { get; set; }
        public double WindSpeedOfGust { get; set; }

       

    }

   
}
