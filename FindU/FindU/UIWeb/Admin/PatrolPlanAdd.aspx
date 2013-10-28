<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatrolPlanAdd.aspx.cs" Inherits="Admin_PatrolPlanAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>巡检计划添加</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="script1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:Panel ID="paneladd" runat="server" GroupingText="下达巡检计划">
        <center>
            <table style="line-height: 150%">
                <tr>
                    <td style="width: 240px">
                        巡检员：
                        <asp:DropDownList runat="server" ID="dropstaff" CssClass="dropdownlist" Font-Size="Medium"
                            OnSelectedIndexChanged="dropstaff_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="lefttd">
                        线路类型：
                    </td>
                    <td class="righttd">
                        <asp:DropDownList runat="server" ID="droproutetype" Width="204px" Font-Size="Medium"
                            OnSelectedIndexChanged="droproutetype_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td class="lefttd">
                        中继段：
                    </td>
                    <td class="righttd">
                        <asp:DropDownList runat="server" ID="droproute" Width="204px" Font-Size="Medium">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="lefttd">
                        年份：
                    </td>
                    <td class="righttd" style="width: 250px">
                        <asp:DropDownList runat="server" ID="dropYear" Width="204px" Font-Size="Medium">
                        </asp:DropDownList>
                    </td>
                    <td class="lefttd">
                        月份：
                    </td>
                    <td class="righttd" style="width: 250px">
                        <asp:DropDownList runat="server" ID="dropMonth" Width="204px" Font-Size="Medium">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="lefttd" valign="top">
                        <asp:Button ID="btnAdd" runat="server" Text="增加巡检" CssClass="button" OnClick="btnAdd_Click" />
                    </td>
                    <td class="righttd" colspan="3">
                        <asp:GridView runat="server" ID="grvrouteinfo" AllowPaging="false" AutoGenerateColumns="false" Width="500px"
                            EmptyDataText="请添加至少一次巡检" CssClass="gridview" OnRowDeleting="grvrouteinfo_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="次序">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="巡检日期">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtplandate" runat="server" Text='<%#Bind("PlanDate") %>' Width="80%"></asp:TextBox>
                                        <cc1:CalendarExtender ID="calendar1" runat="server" TargetControlID="txtplandate"
                                            Format="yyyy-MM-dd">
                                        </cc1:CalendarExtender>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtplandate"
                                            ValidationGroup="sss" Operator="DataTypeCheck" Type="Date" ErrorMessage="*"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            ControlToValidate="txtplandate" ValidationGroup="sss"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" CommandName="delete" Text="删除" CssClass="button"
                                            OnClientClick="return confirm('确定删除吗?')" Width="50px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td class="righttd" colspan="3">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="lefttd" valign="top">
                        说明：
                    </td>
                    <td class="righttd" colspan="3">
                        <asp:TextBox runat="server" ID="txtdescription" CssClass="textbox" Width="500px"
                            Rows="4" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnsave" CssClass="button" Text="保存" OnClick="btnsave_Click"
                ValidationGroup="sss" />
        </center>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" GroupingText="计划查看">
        <center>
            <asp:GridView runat="server" ID="Gridview1" CssClass="gridview" EmptyDataText="本月暂无督巡计划" 
                AllowPaging="false" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StaffName" HeaderText="巡检员" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="RouteTypeName" HeaderText="线路类型" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="RouteName" HeaderText="线路段名称" ControlStyle-Width="100px" />
                    <asp:TemplateField HeaderText="计划时间">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lbplantime" Text='<%#DataBinder.Eval(Container.DataItem,"planyear")+"年"+DataBinder.Eval(Container.DataItem,"planmonth")+"月"%>'></asp:Label></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PatrolCount" HeaderText="计划巡检次数" />
                </Columns>
            </asp:GridView>
            <a href="PatrolPlanView.aspx" style="font-size: 16px; color: Green;">查看更多</a>
        </center>
        <br />
    </asp:Panel>
    </form>
</body>
</html>
