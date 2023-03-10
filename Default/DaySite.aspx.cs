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
                BindChart();
            }
        }
        private BLayer db = new BLayer();
        public void Tabell()
        {
            List<WeatherReading> wrs = db.GetSpecificDay();
            var maxTemp = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1).ToString();
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
                var maxTemp = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
                LabelMaxTemp.Text = maxTemp.ToString();
                MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
                var minTemp = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
                LabelMinTemp.Text = minTemp.ToString();
                MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTemp).Select(m => m.Hour).ToList()[0].ToString();
                LabelAvgTemp.Text = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1).ToString();
                GridView1.DataSource = wrs;
                GridView1.DataBind();
                List<TempGraph> tempGraphs = new List<TempGraph>();
                for (int i = 0; i < wrs.Count; i++)
                {
                    TempGraph graph = new TempGraph();
                    graph.Temperature = double.Parse(wrs[i].Temperature.Replace("°C", ""));
                    graph.Hour = wrs[i].Hour;
                    tempGraphs.Add(graph);
                }

                if (tempGraphs == null)
                {
                    return;
                };

                tempGraphs.Reverse();

                ChartTemp.Series[0].IsXValueIndexed = true;
                ChartTemp.ChartAreas[0].AxisX.Interval = 1;
                ChartTemp.Series[0].XValueMember = "Hour";
                ChartTemp.Series[0].YValueMembers = "Temperature";
                ChartTemp.Series[0].ChartType = SeriesChartType.Line;

                ChartTemp.DataSource = tempGraphs;
                ChartTemp.DataBind();
                string zero = "";
                for (int i = 0; i < wrs.Count; i++)
                {
                    if (wrs[i].Hour.ToString().Count() < 2)
                    {
                        zero = "0";
                    }
                    else
                    {
                        zero = "";
                    }
                    ChartTemp.Series[0].Points[i].ToolTip = $"{wrs[i].Temperature}°C - {zero}{wrs[i].Hour}:00";
                    ChartTemp.Series[0].Points[i].Color = Color.FromArgb(56, 80, 93);
                }
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

            List<WeatherReading> wrs = db.UpdateGridviewByButtonOnDaySite(year, month, day);
            if (wrs.Count == 0)
            {
                ErrorMessage.Visible = true;
                return;
            }
            var maxTemp = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1).ToString();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < wrs.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = double.Parse(wrs[i].Temperature.Replace("°C", ""));
                graph.Hour = wrs[i].Hour;
                tempGraphs.Add(graph);
            }

            if (tempGraphs == null)
            {
                return;
            };

            tempGraphs.Reverse();

            ChartTemp.Series[0].IsXValueIndexed = true;
            ChartTemp.ChartAreas[0].AxisX.Interval = 1;
            ChartTemp.Series[0].XValueMember = "Hour";
            ChartTemp.Series[0].YValueMembers = "Temperature";
            ChartTemp.Series[0].ChartType = SeriesChartType.Line;

            ChartTemp.DataSource = tempGraphs;
            ChartTemp.DataBind();
            string zero = "";
            for (int i = 0; i < wrs.Count; i++)
            {
                if (wrs[i].Hour.ToString().Count() < 2)
                {
                    zero = "0";
                }
                else
                {
                    zero = "";
                }
                ChartTemp.Series[0].Points[i].ToolTip = $"{double.Parse(wrs[i].Temperature.Replace("°C", ""))}°C - {zero}{wrs[i].Hour}:00";
                ChartTemp.Series[0].Points[i].Color = Color.FromArgb(56, 80, 93);
            }
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
            var maxTemp = wrs.Max(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m =>double.Parse(m.Temperature.Replace("°C", "")) == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => double.Parse(m.Temperature.Replace("°C", "")));
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => double.Parse(m.Temperature.Replace("°C", "")) == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => double.Parse(m.Temperature.Replace("°C", ""))), 1).ToString();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < wrs.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = double.Parse(wrs[i].Temperature.Replace("°C", ""));
                graph.Hour = wrs[i].Hour;
                tempGraphs.Add(graph);
            }

            if (tempGraphs == null)
            {
                return;
            };

            tempGraphs.Reverse();

            ChartTemp.Series[0].IsXValueIndexed = true;
            ChartTemp.ChartAreas[0].AxisX.Interval = 1;
            ChartTemp.Series[0].XValueMember = "Hour";
            ChartTemp.Series[0].YValueMembers = "Temperature";
            ChartTemp.Series[0].ChartType = SeriesChartType.Line;

            ChartTemp.DataSource = tempGraphs;
            ChartTemp.DataBind();
            string zero = "";
            for (int i = 0; i < wrs.Count; i++)
            {
                if (wrs[i].Hour.ToString().Count() < 2)
                {
                    zero = "0";
                }
                else
                {
                    zero = "";
                }
                ChartTemp.Series[0].Points[i].ToolTip = $"{wrs[i].Temperature}°C - {zero}{wrs[i].Hour}:00";
                ChartTemp.Series[0].Points[i].Color = Color.FromArgb(56, 80, 93);
            }
            ErrorMessage.Visible = false;
        }
        protected void BindChart()
        {
            List<WeatherReading> tempsForSpecificDay = db.GetSpecificDay();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < tempsForSpecificDay.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = double.Parse(tempsForSpecificDay[i].Temperature.Replace("°C", ""));
                graph.Hour = tempsForSpecificDay[i].Hour;
                tempGraphs.Add(graph);
            }

            if (tempGraphs == null)
            {
                return;
            };

            tempGraphs.Reverse();

            ChartTemp.Series[0].IsXValueIndexed = true;
            ChartTemp.ChartAreas[0].AxisX.Interval = 1;
            ChartTemp.Series[0].XValueMember = "Hour";
            ChartTemp.Series[0].YValueMembers = "Temperature";
            ChartTemp.Series[0].ChartType = SeriesChartType.Line;

            ChartTemp.DataSource = tempGraphs;
            ChartTemp.DataBind();

            string zero = "";
            for (int i = 0; i < tempGraphs.Count; i++)
            {
                if (tempGraphs[i].Hour.ToString().Count() < 2)
                {
                    zero = "0";
                }
                else
                {
                    zero = "";
                }
                ChartTemp.Series[0].Points[i].ToolTip = $"{tempGraphs[i].Temperature}°C - {zero}{tempGraphs[i].Hour}:00";
                ChartTemp.Series[0].Points[i].Color = Color.FromArgb(56, 80, 93);
            }
        }
    }
}