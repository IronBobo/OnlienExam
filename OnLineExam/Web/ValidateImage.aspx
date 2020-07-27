<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidateImage.aspx.cs" Inherits="ValidateImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
    body
    {
        topmargin="0";
        bottommargin="0"; 
        leftmargin="0"; 
        rightmargin="0";
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div onclick="confirm('确定要删除吗？')">删除</div>
    </form>
</body>
</html>
