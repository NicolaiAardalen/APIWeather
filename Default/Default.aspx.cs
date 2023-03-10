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
        protected void BindChart()
        {
            List<WeatherReading> tempsForLast24Hour = db.GetLast24hours();
            List<TempGraph> tempGraphs = new List<TempGraph>();
            for (int i = 0; i < tempsForLast24Hour.Count; i++)
            {
                TempGraph graph = new TempGraph();
                graph.Temperature = double.Parse(tempsForLast24Hour[i].Temperature.Replace("°C", ""));
                graph.Hour = tempsForLast24Hour[i].Hour;
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
    }
}
