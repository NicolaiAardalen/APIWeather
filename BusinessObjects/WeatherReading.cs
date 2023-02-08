namespace BusinessObjects
{
    public class WeatherReading
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public double Temperature { get; set; }
        public double Precipitation { get; set; }
        public double Humidity { get; set; }
        public double WindDirection { get; set; }
        public double WindSpeed { get; set; }
        public double WindSpeedOfGust { get; set; }
        public string Sky { get; set; }

    }
    public class WeatherStats
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double AvgTemperature { get; set; }
        public double MaxTempHour { get; set; }
        public double MinTempHour { get; set; }
        public double MaxTempDay { get; set; }
        public double MinTempDay { get; set; }
    }
    public class TempGraph
    {
        public int Hour { get; set; }
        public double Temperature { get; set; }
    }
}
