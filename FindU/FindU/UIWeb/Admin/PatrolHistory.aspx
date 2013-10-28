<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatrolHistory.aspx.cs" Inherits="PatrolHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>历史记录查看</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="巡线历史记录">
            <center>
                <asp:GridView runat="server" ID="grvhistory" CssClass="gridview" EmptyDataText="没有找到巡线历史记录"
                    AutoGenerateColumns="false" DataKeyNames="routeid,planid" OnRowDataBound="grvhistory_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="realname" HeaderText="人员" />
                        <asp:BoundField DataField="locatetime" HeaderText="日期" />
                        <asp:BoundField DataField="routename" HeaderText="线路名称" />
                        <asp:BoundField DataField="planname" HeaderText="计划名称" />
                        <asp:TemplateField HeaderText="计划报告">
                            <ItemTemplate>
                            <asp:LinkButton ID="btnviewresult" runat="server" Text="查看"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="地图中查看">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnview" runat="server" Text="查看"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
            <br />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
