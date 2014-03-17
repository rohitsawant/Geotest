<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
<title>Plot Path Demo Using Google Maps JavaScript API</title>
<link href="http://code.google.com/apis/maps/documentation/javascript/examples/default.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<asp:Literal ID="js" runat="server"></asp:Literal>
</head>
<body onload="initialize()">
  <form id="form1" runat="server" style ="width: 100%; height: 100%">
           <div id="map_canvas" style="width: 100%; height: 100%;"></div>
   </form>
</body> 
</html>
