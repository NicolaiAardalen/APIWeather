using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbl
{
    public class dblayer
    {
        public void Insert(int year, int month, int day, int hour, float temprature, float precipiation, float humidity, float windDirection, float windSpeed, float windSpeedOfGust)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            SqlParameter param;



            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into WeatherData values(@Year,@Month,@Day,@Hour,@Temprature,@Precipiation,@Humidity,@WindDirection,@WindSpeed, @WindSpeedOfGust)", conn);
                cmd.CommandType = CommandType.Text;



                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = hour;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = day;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Day", SqlDbType.Int);
                param.Value = month;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Hour", SqlDbType.Int);
                param.Value = year;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Temprature", SqlDbType.Int);
                param.Value = temprature;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Precipiation", SqlDbType.Int);
                param.Value = precipiation;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@Humidity", SqlDbType.Int);
                param.Value = humidity;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindDirection", SqlDbType.Int);
                param.Value = windDirection;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindSpeed", SqlDbType.Int);
                param.Value = windSpeed;
                cmd.Parameters.Add(param);



                param = new SqlParameter("@WindSpeedOfGust", SqlDbType.Int);
                param.Value = windSpeedOfGust;
                cmd.Parameters.Add(param);



                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
