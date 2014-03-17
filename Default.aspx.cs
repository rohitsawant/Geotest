using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Latitude"));
            dt.Columns.Add(new DataColumn("Longitude"));

            DataRow row = dt.NewRow();
            //19.1500° N, 73.2620° E Badlapur, Coordinates
            row = dt.NewRow();
            row["Latitude"] = 19.1500;
            row["Longitude"] = 73.2620;
            dt.Rows.Add(row);

            //19.1400° N, 73.1200° E Kalyan, India, Coordinates
            row = dt.NewRow();
            row["Latitude"] = 19.1400;
            row["Longitude"] = 73.1200;
            dt.Rows.Add(row);

            //19.1724° N, 72.9570° E Thane, Coordinates
            row = dt.NewRow();
            row["Latitude"] = 19.1724;
            row["Longitude"] = 72.9570;
            dt.Rows.Add(row);

            //18.9167° N, 73.3300° E Karjat, Coordinates
            row = dt.NewRow();
            row["Latitude"] = 18.9167;
            row["Longitude"] = 73.3300;
            dt.Rows.Add(row);


            js.Text = GPSLib.PlotGPSPoints(dt); ;
        }
    }
}