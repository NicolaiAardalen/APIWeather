using System;
using System.Data.SqlClient;

public class DBLayer
{
	public void Insert()
	{
        SqlCommand = new Sqlcommand($"INSERT INTO TemperaturCelsius VALUES ({DateTime.Now.Year}, {DateTime.Now.Month}, {DateTime.Now.Day}, {DateTime.Now.Hour}, {temperatur}, {millimeter}, {luftfuktighet}, {vindretning}, {vindhastighet}, {vindkasthastighet}) ", conn);
    }
}
	
