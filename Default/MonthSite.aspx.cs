using BusinessLayer;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Default
{
    public partial class MonthSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tabell();
                StartupDrowDownValues();
            }
        }
        private BLayer db = new BLayer();
        public void Tabell()
        {
            List<WeatherReading> wrs = db.GetSpecificMonth();
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var today = wrs.Where(x => x.Day == z.Day).ToList();
                if (ws.Where(x => x.Day == z.Day).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    weatherStats.Day = z.Day;
                    var maxtemp = today.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    var mintemp = today.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    var avgtemp = Math.Round(today.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnMonth = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnMonth = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnMonth = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnMonth.ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnMonth.ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnMonth.ToString();
                    ws.Add(weatherStats);
                }
            }
            GridView1.DataSource = ws;
            GridView1.DataBind();
        }
        protected void StartupDrowDownValues()
        {
            Month.SelectedIndex = DateTime.Now.Month - 1;
            Year.SelectedValue = DateTime.Now.Year + "";
        }
        protected void UpdateGridViewOnDropDownlList(object sender, EventArgs e)
        {
            List<WeatherReading> wrs = db.GetWeatherReadingByYearAndMonth(Year.Text, Month.Text);
            List<WeatherStats> ws = new List<WeatherStats>();
            foreach (var z in wrs)
            {
                var today = wrs.Where(x => x.Day == z.Day).ToList();
                if (ws.Where(x => x.Day == z.Day).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    weatherStats.Day = z.Day;
                    var maxtemp = today.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    var mintemp = today.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    var avgtemp = Math.Round(today.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnMonth = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnMonth = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnMonth = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnMonth.ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnMonth.ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnMonth.ToString();
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
        protected void YearSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("YearSite.aspx?");
        }
        protected void Left_Click(object sender, EventArgs e)
        {
            try
            {
                Month.SelectedIndex++;
            }
            catch (Exception) { }
            List<WeatherStats> ws = new List<WeatherStats>();
            List<WeatherReading> wrs = db.UpdateGridviewByButtonOnMonthSite(int.Parse(Year.SelectedValue), Month.SelectedIndex + 1);
            foreach (var z in wrs)
            {
                var today = wrs.Where(x => x.Day == z.Day).ToList();
                if (ws.Where(x => x.Day == z.Day).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    weatherStats.Day = z.Day;
                    var maxtemp = today.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    var mintemp = today.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    var avgtemp = Math.Round(today.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnMonth = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnMonth = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnMonth = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnMonth.ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m =>double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnMonth.ToString();
                    MinTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnMonth.ToString();
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
                Month.SelectedIndex--;
            }
            catch (ArgumentOutOfRangeException) { }
            List<WeatherStats> ws = new List<WeatherStats>();
            List<WeatherReading> wrs = db.UpdateGridviewByButtonOnMonthSite(int.Parse(Year.SelectedValue), Month.SelectedIndex + 1);

            foreach (var z in wrs)
            {
                var today = wrs.Where(x => x.Day == z.Day).ToList();
                if (ws.Where(x => x.Day == z.Day).ToList().Count == 0)
                {
                    WeatherStats weatherStats = new WeatherStats();
                    weatherStats.Year = z.Year;
                    weatherStats.Month = z.Month;
                    weatherStats.Day = z.Day;
                    var maxtemp = today.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MaxTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxtemp).Select(m => m.Hour).ToList()[0].ToString());
                    var mintemp = today.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    weatherStats.MinTempHour = int.Parse(today.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == mintemp).Select(m => m.Hour).ToList()[0].ToString());
                    var avgtemp = Math.Round(today.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    weatherStats.MaxTemperature = maxtemp;
                    weatherStats.MinTemperature = mintemp;
                    weatherStats.AvgTemperature = avgtemp;
                    var maxTempOnMonth = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var minTempOnMonth = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                    var avgTempOnMonth = Math.Round(wrs.Average(m =>double.Parse(m.Temperature.Replace("°C", ""))), 1);
                    LabelMaxTemp.Text = maxTempOnMonth.ToString();
                    MaxTempDay.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelMinTemp.Text = minTempOnMonth.ToString();
                    MinTempDay.Text = wrs.Where(m =>double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Day).ToList()[0].ToString();
                    MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTempOnMonth).Select(m => m.Hour).ToList()[0].ToString();
                    LabelAvgTemp.Text = avgTempOnMonth.ToString();
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