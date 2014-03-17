using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GPSLib
/// </summary>
public static class GPSLib
{
	public static String PlotGPSPoints(DataTable tblPoints)
    {
        try
        {
            String Locations = "";
            String sJScript = "";
            String FLocLat = Convert.ToString(tblPoints.Rows[0]["Latitude"]);
            String FLocLong = Convert.ToString(tblPoints.Rows[0]["Longitude"]);
            int i = 0;
            foreach (DataRow r in tblPoints.Rows)
            {
                // bypass empty rows 
                if (r["latitude"].ToString().Trim().Length == 0)
                    continue;

                string Latitude = r["latitude"].ToString();
                string Longitude = r["longitude"].ToString();

                // create a line of JavaScript for marker on map for this record 
                Locations += Environment.NewLine + @"
                path.push(new google.maps.LatLng(" + Latitude + ", " + Longitude + @"));

                var marker" + i.ToString() + @" = new google.maps.Marker({
                    position: new google.maps.LatLng(" + Latitude + ", " + Longitude + @"),
                    title: '#' + path.getLength(),
                    map: map
                });";
                i++;
            }

            // construct the final script
            sJScript = @"<script type='text/javascript'>

            var poly;
            var map;

            function initialize() {
                var cmloc = new google.maps.LatLng(lat, long);
                var myOptions = {
                    zoom: 11,
                    center: cmloc,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                map = new google.maps.Map(document.getElementById('map_canvas'), myOptions);

                var polyOptions = {
                    strokeColor: 'blue',
                    strokeOpacity: 0.5,
                    strokeWeight: 3
                }
                poly = new google.maps.Polyline(polyOptions);
                poly.setMap(map);

                var path = poly.getPath();

               " + Locations + @"

                    }
                </script>";
            sJScript = sJScript.Replace("lat", FLocLat);
            sJScript = sJScript.Replace("long", FLocLong);
            return sJScript;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}