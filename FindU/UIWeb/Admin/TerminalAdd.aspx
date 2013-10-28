<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TerminalAdd.aspx.cs" Inherits="TerminalAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>终端绑定</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .tb tr
    {
        height:30px
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" GroupingText="绑定新的终端" Font-Size="17px">
            <div align="center">
                <table class="tb">
                    <tr>
                        <td>
                            随机编号：
                        </td>
                        <td class="righttd">
                            <asp:TextBox ID="txtnumber" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnumber" ErrorMessage="*"
                                ValidationGroup="11"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            使用者：
                        </td>
                        <td class="righttd">
                            <asp:DropDownList runat="server" ID="dropstaff" CssClass="dropdownlist" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSubmit" runat="server" Text="添加" CssClass="button" ValidationGroup="11"
                                OnClick="btnSubmit_Click" />
                            <input type="reset" value="重填" class="button" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
