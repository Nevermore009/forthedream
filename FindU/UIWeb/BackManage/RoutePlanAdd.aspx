<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoutePlanAdd.aspx.cs" Inherits="Admin_RoutePlanAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加采集督巡线路计划</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <center style="margin-top:50px">
        <table>
            <tr>
                <td class="lefttd">
                    计划名称：
                </td>
                <td class="righttd">
                    <asp:TextBox runat="server" ID="txtplanname" CssClass="textbox" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                    执行者：
                </td>
                <td class="righttd">
                    <asp:DropDownList runat="server" ID="dropstaff" Width="204px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="lefttd" valign="top">
                    说明：
                </td>
                <td class="righttd">
                    <asp:TextBox runat="server" ID="txtdescription" CssClass="textbox" Width="200px"
                        Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="lefttd">
                </td>
                <td class="righttd">
                    <asp:Button runat="server" ID="btnsave" CssClass="button" Text="保存" 
                        onclick="btnsave_Click" />
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
