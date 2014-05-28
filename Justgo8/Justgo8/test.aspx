<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Justgo8.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="API/Facebook/Facebook.ashx" style="height: 37px; width: 37px; display: inline-block;
            background-image: url(images/quicklog.png); background-position: 37px 0px;">
        </a><a href="API/Google/Google.ashx" style="height: 37px; width: 37px; display: inline-block;
            background-image: url(images/quicklog.png); background-position: 37px -37px;">
        </a><a href="API/Yahoo/Yahoo.ashx" style="height: 37px; width: 37px; display: inline-block;
            background-image: url(images/quicklog.png); background-position: 37px -111px;">
        </a>
    </div>
    </form>
</body>
</html>
