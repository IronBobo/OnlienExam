<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exampaper.aspx.cs" Inherits="Exampaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <center>
      <h1> Banner </h1>
     </center>
     <span style="float:right"></span>
     <table border="0" cellspacing="0" cellpadding="0" width="100%">
     	<tr>
     		<td>
     		 <iframe id="left" name="left" src="./StudentIndex.aspx" width="188px" height="730" style="text-align:center" runat="Server"></iframe>
     		</td>
     		<td>
     		 <iframe id="right" name="right" src="" style="width:100%;height:100%;" runat="Server"></iframe>
     		</td>
     	</tr>
     </table>
    </div>
    </form>
</body>
</html>
