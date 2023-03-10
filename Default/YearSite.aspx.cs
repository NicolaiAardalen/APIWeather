using BusinessLayer;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Default
{
    public partial class YearSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tabell();
                BindYearDropDown();
            }
        }
        private BLayer db = new BLayer();
        public void Tabell()
        {
            List<WeatherReading> wrs = db.GetSpecificYear();
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var tomonth = wrs.Where(x => x.Month == z.Month).ToList();
                if (ws.Where(x => x.Month == z.Month).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    var maxtemp = tomonth.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MaxTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Day).ToList()[0].ToString());
                    var mintemp = tomonth.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MinTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Day).ToList()[0].ToString());
                    var avgtemp = Math.Round(tomonth.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnYear = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnYear = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnYear = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnYear.ToString();
                    MaxTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnYear.ToString();
                    MinTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnYear.ToString();
                    ws.Add(weatherStats);
                }
            }
            GridView1.DataSource = ws;
            GridView1.DataBind();
        }
        protected void BindYearDropDown()
        {
            Year.DataSource = db.GetYearsInDB();
            Year.DataBind();
            
        }
        protected void StartupDrowDownValues()
        {
            Year.SelectedValue = DateTime.Now.Year + "";
        }
        protected void UpdateGridViewOnDropDownlList(object sender, EventArgs e)
        {
            List<WeatherReading> wrs = db.GetWeatherReadingByYear(Year.Text);
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var tomonth = wrs.Where(x => x.Month == z.Month).ToList();
                if (ws.Where(x => x.Month == z.Month).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    var maxtemp = tomonth.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MaxTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Day).ToList()[0].ToString());
                    var mintemp = tomonth.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MinTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Day).ToList()[0].ToString());
                    var avgtemp = Math.Round(tomonth.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnYear = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnYear = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnYear = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnYear.ToString();
                    MaxTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnYear.ToString();
                    MinTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnYear.ToString();
                    ws.Add(weatherStats);
                }
            }
            if (ws.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            GridView1.DataSource = ws;
            GridView1.DataBind();
            ErrorMessage.Visible = false;
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabell();
        }
        protected void Last24Hours_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?");
        }
        protected void DaySite_Click(object sender, EventArgs e)
        {
            Response.Redirect("DaySite.aspx?");
        }
        protected void MonthSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthSite.aspx?");
        }
        protected void Left_Click(object sender, EventArgs e)
        {
            try
            {
                Year.SelectedIndex++;
            }
            catch (ArgumentOutOfRangeException) { }
            List<WeatherReading> wrs = db.GetWeatherReadingByYear(Year.Text);
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var tomonth = wrs.Where(x => x.Month == z.Month).ToList();
                if (ws.Where(x => x.Month == z.Month).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    var maxtemp = tomonth.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MaxTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Day).ToList()[0].ToString());
                    var mintemp = tomonth.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MinTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Day).ToList()[0].ToString());
                    var avgtemp = Math.Round(tomonth.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnYear = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnYear = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnYear = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnYear.ToString();
                    MaxTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnYear.ToString();
                    MinTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnYear.ToString();
                    ws.Add(weatherStats);
                }
            }
            if (ws.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            GridView1.DataSource = ws;
            GridView1.DataBind();
            ErrorMessage.Visible = false;
        }
        protected void Right_Click(object sender, EventArgs e)
        {
            try
            {
                Year.SelectedIndex--;
            }
            catch (ArgumentOutOfRangeException) { }
            List<WeatherReading> wrs = db.GetWeatherReadingByYear(Year.Text);
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var tomonth = wrs.Where(x => x.Month == z.Month).ToList();
                if (ws.Where(x => x.Month == z.Month).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    var maxtemp = tomonth.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MaxTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Day).ToList()[0].ToString());
                    var mintemp = tomonth.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    weatherStats.MinTempDay = int.Parse(tomonth.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Day).ToList()[0].ToString());
                    var avgtemp = Math.Round(tomonth.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnYear = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnYear = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnYear = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnYear.ToString();
                    MaxTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnYear.ToString();
                    MinTempMonth.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Month).ToList()[0].ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnYear).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnYear.ToString();
                    ws.Add(weatherStats);
                }
            }
            if (ws.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            GridView1.DataSource = ws;
            GridView1.DataBind();
            ErrorMessage.Visible = false;
        }
    }
}