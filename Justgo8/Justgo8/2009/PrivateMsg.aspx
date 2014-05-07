<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrivateMsg.aspx.cs" Inherits="Justgo8._2009.PrivateMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".del_feed").remove();
            $(".splite").remove();
            $(".reply").remove();
            $(".qPager").remove();
            $(".avatar").remove();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Repeater runat="server" ID="RepeaterMsg">
        <ItemTemplate>
            <asp:Panel runat="server" ID="panelmsg" GroupingText='<%#Eval("remark") %>'>
                <%#Eval("content")%>
            </asp:Panel>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
