<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MorseCode.CsJs.Examples.CalculatorsAndStopwatch.Server.Web.UI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/jquery-1.9.1.js") %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/mscorlib.js") %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/linq.js") %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.Common.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.Net.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.ViewModel.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.UI.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.Examples.CalculatorsAndStopwatch.ViewModel.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    <script src="<%= VirtualPathUtility.ToAbsolute("~/Scripts/SOAPClient.js") + "?bypassCache=" + DateTime.Now.ToBinary() %>" type="text/javascript"></script>
    
    <form runat="server">
    </form>
</body>
</html>
