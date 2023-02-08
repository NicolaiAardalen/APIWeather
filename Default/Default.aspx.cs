using BusinessLayer;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Default
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tabell();
                BindChart();
            }
        }
        protected BLayer db = new BLayer();
        public void Tabell()
        {
            List<WeatherReading> wrs = db.GetLast24hours();
            var maxTemp = wrs.Max(m => m.Temperature);
            LabelMaxTemp.Text = maxTemp.ToString();
            MaxTempHour.Text = wrs.Where(m => m.Temperature == maxTemp).Select(m => m.Hour).ToList()[0].ToString();
            var minTemp = wrs.Min(m => m.Temperature);
            LabelMinTemp.Text = minTemp.ToString();
            MinTempHour.Text = wrs.Where(m => m.Temperature == minTemp).Select(m => m.Hour).ToList()[0].ToString();
            LabelAvgTemp.Text = Math.Round(wrs.Average(m => m.Temperature), 1).ToString();
            int tempCount = wrs.Where(wr => wr.Temperature > 5).ToList().Count();
            GridView1.DataSource = wrs;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tabell();
        }
        protected void DaySite_Click(object sender, EventArgs e)
        {
            Response.Redirect("DaySite.aspx?");
        }
        protected void MonthSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonthSite.aspx?");
        }
        protected void YearSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("YearSite.aspx?");
        }
        protected void BindChart()
        {
            var series = new Series();

            List<WeatherReading> tempsForLast24Hour = db.GetLast24hours();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < tempsForLast24Hour.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = tempsForLast24Hour[i].Temperature;
                graph.Hour = tempsForLast24Hour[i].Hour;
                tempGraphs.Add(graph);
            }

            if (tempGraphs == null)
            {
                return;
            };

            series.XValueMember = "Hour";

            tempGraphs.Reverse();

            foreach (TempGraph t in tempGraphs)
            {
                series.Points.AddXY(t.Hour, t.Temperature);
            }
            
            series.IsXValueIndexed = true;

            if (ChartTemp.Series.Count == 0)
            {
                ChartTemp.Series.Add(series);
            }

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
            ChartTemp.DataBindTable(tempGraphs,"Hour");
        }
    }
}