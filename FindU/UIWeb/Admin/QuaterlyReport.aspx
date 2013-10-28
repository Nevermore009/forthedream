﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuaterlyReport.aspx.cs" Inherits="Admin_QuaterlyReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div align="center">
      年份：   <asp:DropDownList runat="server" ID="dropYear" Width="204px" Font-Size="Medium">
                        </asp:DropDownList>
                        季度： <asp:DropDownList runat="server" ID="dropQuater" Width="204px" Font-Size="Medium">
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSelect" runat="server" Text="查询" Width="65px" 
                onclick="btnSelect_Click" /><rsweb:ReportViewer ID="ReportViewer1" 
             runat="server" Font-Names="Verdana" Font-Size="8pt" 
             InteractiveDeviceInfos="(集合)" WaitMessageFont-Names="Verdana" 
             WaitMessageFont-Size="14pt"　Width="100%" Height="500px">
             <LocalReport ReportPath="Admin\RDLC\MonthlyReport.rdlc">
             </LocalReport>
                </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
