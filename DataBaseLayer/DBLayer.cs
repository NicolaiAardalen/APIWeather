using BusinessObjects;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace dbllayer123
{
    public class DBL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        public void Insert(int year, int month, int day, int hour, float temprature, float precipitation, float humidity, float windDirection, float windSpeed, float windSpeedOfGust, string sky)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TemperaturCelsius values(@Year, @Month, @Day, @Hour, ROUND(@Temprature, 1), ROUND(@Precipitation, 1), ROUND(@Humidity, 1), ROUND(@WindDirection, 1), ROUND(@WindSpeed, 1), ROUND(@WindSpeedOfGust, 1), @sky)", conn);

            cmd.Parameters.AddWithValue("Year", year);
            cmd.Parameters.AddWithValue("Month", month);
            cmd.Parameters.AddWithValue("Day", day);
            cmd.Parameters.AddWithValue("Hour", hour);
            cmd.Parameters.AddWithValue("Temprature", temprature);
            cmd.Parameters.AddWithValue("Precipitation", precipitation);
            cmd.Parameters.AddWithValue("Humidity", humidity);
            cmd.Parameters.AddWithValue("WindDirection", windDirection);
            cmd.Parameters.AddWithValue("WindSpeed", windSpeed);
            cmd.Parameters.AddWithValue("WindSpeedOfGust", windSpeedOfGust);
            cmd.Parameters.AddWithValue("Sky", sky);

            int rows = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<WeatherReading> GetWeatherReadingByYearMonthAndDay(string Year, string Month, string Day)
        {
            try
            {
                List<WeatherReading> weatherReadings = new List<WeatherReading>();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select * From TemperaturCelsius WHERE Year = @Year AND Month = @Month AND Day = @Day ORDER BY Hour desc", conn);

                cmd.Parameters.AddWithValue("Year", Year);
                cmd.Parameters.AddWithValue("Month", Month);
                cmd.Parameters.AddWithValue("Day", Day);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WeatherReading wr = new WeatherReading();
                    wr.Year = (int)reader["Year"];
                    wr.Month = (int)reader["Month"];
                    wr.Day = (int)reader["Day"];
                    wr.Hour = (int)reader["Hour"];
                    wr.Temperature = (string)reader["Temperature"] + "°C";
                    wr.Precipitation = (string)reader["Precipitation"] + "mm";
                    wr.Humidity = (string)reader["Humidity"] + "%";
                    wr.WindDirection = (string)reader["WindDirection"] + "°";
                    wr.WindSpeed = (string)reader["WindSpeed"] + "m/s";
                    wr.WindSpeedOfGust = (string)reader["WindSpeedOfGust"] + "m/s";
                    if (reader["Sky"].ToString().Length == 0)
                    {
                        wr.Sky = $@"~\Images\default.png";
                    }
                    else
                    {
                        wr.Sky = $@"~\Images\{reader["Sky"]}.png";
                    }
                    weatherReadings.Add(wr);
                }
                reader.Close();
                conn.Close();

                return weatherReadings;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        public List<WeatherReading> GetWeatherReadingByYearAndMonth(string Year, string Month)
        {
            try
            {
                List<WeatherReading> weatherReadings = new List<WeatherReading>();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = @Year and Month = @Month ORDER BY Year, Month, Day desc", conn);

                cmd.Parameters.AddWithValue("Year", Year);
                cmd.Parameters.AddWithValue("Month", Month);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WeatherReading wr = new WeatherReading();
                    wr.Year = (int)reader["Year"];
                    wr.Month = (int)reader["Month"];
                    wr.Day = (int)reader["Day"];
                    wr.Hour = (int)reader["Hour"];
                    wr.Temperature = (string)reader["Temperature"] + "°C";

                    weatherReadings.Add(wr);
                }
                reader.Close();
                conn.Close();

                return weatherReadings;
            }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        public List<WeatherReading> GetWeatherReadingByYear(string Year)
        {
            try
            {
                List<WeatherReading> weatherReadings = new List<WeatherReading>();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = @Year ORDER BY Year, Month desc", conn);

                cmd.Parameters.AddWithValue("Year", Year);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WeatherReading wr = new WeatherReading();
                    wr.Year = (int)reader["Year"];
                    wr.Month = (int)reader["Month"];
                    wr.Day = (int)reader["Day"];
                    wr.Hour = (int)reader["Hour"];
                    wr.Temperature = (string)reader["Temperature"] + "°C";
                    weatherReadings.Add(wr);
                }
                reader.Close();
                conn.Close();

                return weatherReadings;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        public List<WeatherReading> GetLast24hours()
        {
            List<WeatherReading> weatherReadings = new List<WeatherReading>();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT top(24) * FROM TemperaturCelsius ORDER BY Year desc, Month desc, Day desc, Hour desc", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WeatherReading wr = new WeatherReading();
                wr.Year = (int)reader["Year"];
                wr.Month = (int)reader["Month"];
                wr.Day = (int)reader["Day"];
                wr.Hour = (int)reader["Hour"];
                wr.Temperature = (string)reader["Temperature"] + "°C";
                wr.Precipitation = (string)reader["Precipitation"] + "mm";
                wr.Humidity = (string)reader["Humidity"] + "%";
                wr.WindDirection = (string)reader["WindDirection"] + "°";
                wr.WindSpeed = (string)reader["WindSpeed"] + "m/s";
                wr.WindSpeedOfGust = (string)reader["WindSpeedOfGust"] + "m/s";
                if (reader["Sky"].ToString().Length == 0)
                {
                    wr.Sky = $@"~\Images\default.png";
                }
                else
                {
                    wr.Sky = $@"~\Images\{reader["Sky"]}.png";
                }
                weatherReadings.Add(wr);
            }
            reader.Close();
            conn.Close();

            return weatherReadings;
        }
        public List<WeatherReading> GetSpecificDay()
        {
            List<WeatherReading> weatherReadings = new List<WeatherReading>();

            conn.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM TemperaturCelsius Where day = {DateTime.Now.Day} and month = {DateTime.Now.Month} and year = {DateTime.Now.Year} ORDER BY Year, Month, Day desc, Hour desc", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WeatherReading wr = new WeatherReading();
                wr.Year = (int)reader["Year"];
                wr.Month = (int)reader["Month"];
                wr.Day = (int)reader["Day"];
                wr.Hour = (int)reader["Hour"];
                wr.Temperature = (string)reader["Temperature"] + "°C";
                wr.Precipitation = (string)reader["Precipitation"] + "mm";
                wr.Humidity = (string)reader["Humidity"] + "%";
                wr.WindDirection = (string)reader["WindDirection"] + "°";
                wr.WindSpeed = (string)reader["WindSpeed"] + "m/s";
                wr.WindSpeedOfGust = (string)reader["WindSpeedOfGust"] + "m/s";
                if (reader["Sky"].ToString().Length == 0)
                {
                    wr.Sky = $@"~\Images\default.png";
                }
                else
                {
                    wr.Sky = $@"~\Images\{reader["Sky"]}.png";
                }
                weatherReadings.Add(wr);
            }
            reader.Close();
            conn.Close();

            return weatherReadings;
        }
        public List<WeatherReading> GetSpecificMonth()
        {
            List<WeatherReading> weatherReadings = new List<WeatherReading>();

            conn.Open();
            SqlCommand cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = {DateTime.Now.Year} and Month = {DateTime.Now.Month} ORDER BY Year, Month, Day desc", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WeatherReading wr = new WeatherReading();
                wr.Year = (int)reader["Year"];
                wr.Month = (int)reader["Month"];
                wr.Day = (int)reader["Day"];
                wr.Hour = (int)reader["Hour"];
                wr.Temperature = (string)reader["Temperature"] + "°C";
                weatherReadings.Add(wr);
            }
            reader.Close();
            conn.Close();

            return weatherReadings;
        }
        public List<WeatherReading> GetSpecificYear()
        {
            List<WeatherReading> weatherReadings = new List<WeatherReading>();

            conn.Open();
            SqlCommand cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = {DateTime.Now.Year} ORDER BY Year, Month desc", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WeatherReading wr = new WeatherReading();
                wr.Year = (int)reader["Year"];
                wr.Month = (int)reader["Month"];
                wr.Day = (int)reader["Day"];
                wr.Hour = (int)reader["Hour"];
                wr.Temperature = (string)reader["Temperature"] + "°C";
                weatherReadings.Add(wr);
            }
            reader.Close();
            conn.Close();

            return weatherReadings;
        }
        public List<WeatherReading> UpdateGridviewByButtonOnDaySite(int year,int month,int day)
        {
            var cmd = new SqlCommand($"Select * From TemperaturCelsius WHERE Year = @year AND Month = @month AND Day = @day ORDER BY Hour desc", conn);
            
            cmd.Parameters.AddWithValue("month", month);
            cmd.Parameters.AddWithValue("year", year);
            cmd.Parameters.AddWithValue("day", day);
            conn.Open();
            var list = new List<WeatherReading>();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WeatherReading wr = new WeatherReading();
                wr.Year = (int)reader["Year"];
                wr.Month = (int)reader["Month"];
                wr.Day = (int)reader["Day"];
                wr.Hour = (int)reader["Hour"];
                wr.Temperature = (string)reader["Temperature"] + "°C";
                wr.Precipitation = (string)reader["Precipitation"] + "mm";
                wr.Humidity = (string)reader["Humidity"] + "%";
                wr.WindDirection = (string)reader["WindDirection"] + "°";
                wr.WindSpeed = (string)reader["WindSpeed"] + "m/s";
                wr.WindSpeedOfGust = (string)reader["WindSpeedOfGust"] + "m/s";
                if (reader["Sky"].ToString().Length == 0)
                {
                    wr.Sky = $@"~\Images\default.png";
                }
                else
                {
                    wr.Sky = $@"~\Images\{reader["Sky"]}.png";
                }
                list.Add(wr);
            }
            reader.Close();
            conn.Close();
            return list;
        }
        public List<WeatherReading> UpdateGridviewByButtonOnMonthSite(int Year, int Month)
        {
            try
            {
                var months1 = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                var selectedmonth = Month;
                var selectedyear = Year;
                var cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = @Year and Month = @Month ORDER BY Year, Month, Day desc", conn);
                
                cmd.Parameters.AddWithValue("Year", selectedyear);
                cmd.Parameters.AddWithValue("Month", selectedmonth);
                
                conn.Open();
                var list = new List<WeatherReading>();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ws = new WeatherReading
                    {
                        Year = (int)reader["Year"],
                        Month = (int)reader["Month"],
                        Day = (int)reader["Day"],
                        Hour = (int)reader["Hour"],
                        Temperature = (string)reader["Temperature"] + "°C",
                    };
                    list.Add(ws);
                }
                reader.Close();
                conn.Close();
                return list;
            }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        public List<WeatherReading> UpdateGridviewByButtonOnYearSite(DropDownList Year)
        {
            var selectedyear = Year.SelectedItem.Text;
            var cmd = new SqlCommand($"SELECT Year, Month, Day, Hour, Temperature FROM TemperaturCelsius Where Year = @Year ORDER BY Year, Month desc", conn);
            cmd.Parameters.AddWithValue("Year", selectedyear);
            conn.Open();
            var list = new List<WeatherReading>();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var ws = new WeatherReading
                {
                    Year = (int)reader["Year"],
                    Month = (int)reader["Month"],
                    Day = (int)reader["Day"],
                    Hour = (int)reader["Hour"],
                    Temperature = (string)reader["Temperature"] + "°C",
                };
                list.Add(ws);
            }
            reader.Close();
            conn.Close();
            return list;
        }
        public List<int> GetYearsInDB()
        {
            List<int> years = new List<int>();

            conn.Open();
            SqlCommand cmd = new SqlCommand("select distinct year from TemperaturCelsius", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int year;
                year = (int)reader["Year"];
                years.Add(year);
            }
            reader.Close();
            conn.Close();

            return years;
        }
    }
}
