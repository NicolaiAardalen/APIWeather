using BusinessLayer;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Default
{
    public partial class DaySite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tabell();
                StartupDrowDownValues();
                BindYearsDropDown();
                //BindChart();
            }
        }
        private BLayer db = new BLayer();
        public void Tabell()
        {
            List<WeatherReading> wrs = db.GetSpecificDay();
            var maxTemp = wrs.Max(m => m.Temperature);
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => m.Temperature == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => m.Temperature);
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => m.Temperature == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => m.Temperature), 1).ToString();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
        }
        protected void BindYearsDropDown()
        {
            Year.DataSource = db.GetYearsInDB();
            Year.DataBind();
        }
        protected void StartupDrowDownValues()
        {
            Day.SelectedIndex = DateTime.Now.Day - 1;
            Month.SelectedIndex = DateTime.Now.Month - 1;
            Year.SelectedValue = DateTime.Now.Year.ToString();
        }
        protected void UpdateGridViewOnDropDownlList(object sender, EventArgs e)
        {
            List<WeatherReading> wrs = db.GetWeatherReadingByYearMonthAndDay(Year.Text, Month.Text, Day.Text);
            try
            {
                var maxTemp = wrs.Max(m => m.Temperature);
                LabelMaxTemp.Text = maxTemp.ToString();
                MaxTempHour.Text = wrs.Where(m => m.Temperature == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
                var minTemp = wrs.Min(m => m.Temperature);
                LabelMinTemp.Text = minTemp.ToString();
                MinTempHour.Text = wrs.Where(m => m.Temperature == minTemp).Select(m => m.Hour).ToList()[0].ToString();
                LabelAvgTemp.Text = Math.Round(wrs.Average(m => m.Temperature), 1).ToString();
                GridView1.DataSource = wrs;
                GridView1.DataBind();
                ErrorMessage.Visible = false;
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception) { ErrorMessage.Visible = true; }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabell();
        }
        protected void Last24Hours_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx?");
        }

        protected void MonthSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthSite.aspx?");
        }
        protected void YearSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("YearSite.aspx?");
        }

        protected void Left_Click(object sender, EventArgs e)
        {
            try
            {
                Day.SelectedIndex++;
            }

            catch (Exception) { }
            int year, month, day;
            year = int.Parse(Year.SelectedValue);
            month= Month.SelectedIndex+1;  
            day= Day.SelectedIndex+1;

            List<WeatherReading> wrs = db.UpdateGridviewByButtonOnDaySite(year, month, day);//(Year, Month, Day);
            if (wrs.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            var maxTemp = wrs.Max(m => m.Temperature);
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => m.Temperature == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => m.Temperature);
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => m.Temperature == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => m.Temperature), 1).ToString();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
            ErrorMessage.Visible = false;
        }
        protected void Right_Click(object sender, EventArgs e)
        {
            try
            {
                Day.SelectedIndex--;
            }
            catch (Exception) { }
            List<WeatherReading> wrs = db.UpdateGridviewByButtonOnDaySite(int.Parse(Year.SelectedValue), Month.SelectedIndex+1, Day.SelectedIndex+1);
            if (wrs.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            var maxTemp = wrs.Max(m => m.Temperature);
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => m.Temperature == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => m.Temperature);
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => m.Temperature == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => m.Temperature), 1).ToString();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
            ErrorMessage.Visible = false;
        }
        protected void BindChart()
        {
            var series = new Series();

            List<WeatherReading> tempsForSpecificDay = db.GetSpecificDay();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < tempsForSpecificDay.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = tempsForSpecificDay[i].Temperature;
                graph.Hour = tempsForSpecificDay[i].Hour;
                tempGraphs.Add(graph);
            }

            if (tempGraphs == null)
            {
                return;
            };

            series.XValueMember = "Hour";

            foreach (TempGraph t in tempGraphs)
            {
                series.Points.AddXY(t.Hour, t.Temperature);
            }

            ChartTemp.Series.Add(series);

            string zero = "";
            if (tempGraphs.Count > 0)
            {
                series.ChartType = SeriesChartType.Line;
                int pointCounter = 0;
                foreach (DataPoint p in series.Points)
                {
                    if (p.XValue < 10)
                        zero = "0";
                    else
                        zero = "";
                    series.Points[pointCounter].ToolTip = $"{p.YValues[0]}°C - {zero}{p.XValue}:00";
                    series.Points[pointCounter].Color = Color.FromArgb(56, 80, 93);

                    pointCounter++;
                }
            }
            ChartTemp.DataBindTable(tempGraphs, "Hour");
        }
    }
}