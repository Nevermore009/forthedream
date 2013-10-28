<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatrolRemark.aspx.cs" Inherits="Admin_PatrolRemark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <table>
                <tr style="display: none">
                    <td colspan="2">
                        <asp:Label ID="lbid" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        备注:
                    </td>
                    <td>
                        <asp:TextBox ID="txtremark" runat="server" Enabled="false" Width="168px" Height="88px"
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnedit" runat="server" Text="编辑" Width="50px" OnClick="btnedit_Click" />
                        <asp:Button ID="btnsubmit" runat="server" Text="修改" Width="50px" Enabled="false"
                            OnClick="btnsubmit_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
