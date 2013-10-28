<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoftWareUpLoad.aspx.cs" Inherits="Admin_SoftWareUpLoad" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>终端软件</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="终端软件上传">
            <div align="center">
                <table style="margin-top: 30px;">
                    <tr>
                        <td class="td1">
                            软件上传：
                        </td>
                        <td class="td2">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*必填"
                                ControlToValidate="FileUpload1" ValidationGroup="group"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 40px;">
                        </td>
                    </tr>
                    <tr>
                        <td class="td1">
                            版本：
                        </td>
                        <td class="td2">
                            <asp:TextBox ID="txtVersion" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*数字"
                                ControlToValidate="txtVersion" ValidationExpression="[1-9]\d*\.?\d*" ValidationGroup="group"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*必填"
                                ControlToValidate="txtVersion" ValidationGroup="group"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 40px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td class="td2">
                            <asp:Label ID="LableMessage" runat="server" ForeColor="Red" Text="(提示：限上传apk格式而且大小低于30M的软件文件！)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td1">
                            备注：
                        </td>
                        <td class="td2">
                            <asp:TextBox ID="txtRemark" runat="server" Width="405px" Height="78px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td style="width: 40px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 60px; text-align: center;">
                            <div>
                                <asp:Button ID="btnSubmit" runat="server" Text="添加" Width="80px" ValidationGroup="group"
                                    CssClass="button" OnClick="btnSubmit_Click" />
                                <asp:Label ID="Label1" runat="server" Width="10px"></asp:Label>
                                <asp:Button ID="btnReset" runat="server" Text="取消" Width="80px" CssClass="button"
                                    OnClick="btnReset_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
