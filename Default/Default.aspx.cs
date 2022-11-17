using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLayer;
using BusinessObjects;

namespace Default
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GridView1.DataSource = Tabell();
                //GridView1.DataBind();
                //Tabell();//gets data and bind
               

                BLayer bl = new BLayer();
                List<WeatherReading> wrs=bl.GetWeatherReadingByYearMonthAndDay(TextBoxS.Text, TextBoxS1.Text, TextBoxS2.Text);
                GridView1.DataSource = wrs;
                GridView1.DataBind();
            }
        }
        public DataTable Tabell()
        {
            var DBL = new DBL();

            var connect = DBL.Table();
            GridView1.DataSource = connect;
            GridView1.DataBind();

            //bind labels
            LabelMaxTemp.Text = "";//finne max temp for gitt dato

            return connect;
        }
        protected void Search(object sender, EventArgs e)
        {

            //var DBL = new DBL();

            //var connect = DBL.Search(TextBoxS.Text, TextBoxS1.Text, TextBoxS2.Text);
            //GridView1.DataSource = connect;
            //GridView1.DataBind();

            DBL db = new DBL();
            List<WeatherReading> wrs = db.GetWeatherReadingByYearMonthAndDay(TextBoxS.Text, TextBoxS1.Text, TextBoxS2.Text);
            
            LabelMaxTemp.Text=wrs.Max(m=>m.Temperature).ToString();
            int tempCount = wrs.Where(wr => wr.Temperature > 5).ToList().Count();
           


            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.DataSource = Tabell();
            //GridView1.DataBind();
            Tabell();
        }
    }
}