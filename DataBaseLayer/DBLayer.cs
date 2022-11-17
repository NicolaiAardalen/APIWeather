

using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace dbllayer123
{
    public class DBL
    {
        public void Insert(int year, int month, int day, int hour, float temprature, float precipiation, float humidity, float windDirection, float windSpeed, float windSpeedOfGust)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            SqlParameter param;



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TemperaturCelsius values(@Hour, @Day, @Month, @Year, ROUND(@Temprature, 1), ROUND(@Precipiation, 1), ROUND(@Humidity, 1), ROUND(@WindDirection, 1), ROUND(@WindSpeed, 1), ROUND(@WindSpeedOfGust, 1))", conn);
                cmd.CommandType = CommandType.Text;



                param = new SqlParameter("@Year", SqlDbType.Float);
                param.Value = hour;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Month", SqlDbType.Float);
                param.Value = day;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Day", SqlDbType.Float);
                param.Value = month;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Hour", SqlDbType.Float);
                param.Value = year;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Temprature", SqlDbType.Float);
                param.Value = temprature;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Precipiation", SqlDbType.Float);
                param.Value = precipiation;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Humidity", SqlDbType.Float);
                param.Value = humidity;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindDirection", SqlDbType.Float);
                param.Value = windDirection;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindSpeed", SqlDbType.Float);
                param.Value = windSpeed;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindSpeedOfGust", SqlDbType.Float);
                param.Value = windSpeedOfGust;
                cmd.Parameters.Add(param);



                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public DataTable Search(string TextBoxS, string TextBoxS1, string TextBoxS2)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;


            DataTable NicoTemperatur = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select * From TemperaturCelsius WHERE Year = '{TextBoxS}' AND Month = '{TextBoxS1}' AND Day = '{TextBoxS2}' ORDER BY Hour desc", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                NicoTemperatur.Load(reader);
                reader.Close();
                conn.Close();
            }
            return NicoTemperatur;
        }

        public List<WeatherReading> GetWeatherReadingByYearMonthAndDay(string TextBoxS, string TextBoxS1, string TextBoxS2)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            List<WeatherReading> weatherReadings = new List<WeatherReading>();

            DataTable NicoTemperatur = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"Select * From TemperaturCelsius WHERE Year = '{TextBoxS}' AND Month = '{TextBoxS1}' AND Day = '{TextBoxS2}' ORDER BY Hour desc", conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    WeatherReading wr = new WeatherReading();
                    wr.Temperature = reader.GetDouble(5);
                    wr.Day= (int)reader["Day"];

                    weatherReadings.Add(wr);
                }



                NicoTemperatur.Load(reader);
                reader.Close();
                conn.Close();
            }
            return weatherReadings;
        }

        public DataTable Table()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

            DataTable NicoTemperatur = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))

            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT top(24)* FROM TemperaturCelsius ORDER BY Year, Month, Day desc, Hour desc", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                NicoTemperatur.Load(reader);

                reader.Close();

                conn.Close();
            }
            return NicoTemperatur;
        }
    }
}
