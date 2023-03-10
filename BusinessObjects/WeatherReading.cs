namespace BusinessObjects
{
    public class WeatherReading
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public string Temperature { get; set; }
        public string Precipitation { get; set; }
        public string Humidity { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string WindSpeedOfGust { get; set; }
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
