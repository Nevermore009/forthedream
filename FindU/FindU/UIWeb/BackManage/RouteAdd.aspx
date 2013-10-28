<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RouteAdd.aspx.cs" Inherits="RouteAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加督巡线路</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="script1" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatepanel1">
        <ContentTemplate>
            <center>
                坐标导入方式：<asp:DropDownList runat="server" ID="dropimportmode" CssClass="dropdownlist"
                    AutoPostBack="true" OnSelectedIndexChanged="dropimportmode_SelectedIndexChanged">
                    <asp:ListItem Value="0">录入</asp:ListItem>
                    <asp:ListItem Value="1" Selected="True">从采集计划导入</asp:ListItem>
                </asp:DropDownList>
            </center>
            <asp:Panel ID="panelinput" GroupingText="添加基站坐标" Font-Size="Large" runat="server"
                Visible="false">
                <center>
                    <table>
                        <tr>
                            <td class="lefttd" style="width: 120px">
                                基站(井)名：
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txttitle" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="123"
                                    ControlToValidate="txttitle"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                经度：
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtlat" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    Display="Dynamic" ValidationGroup="123" ControlToValidate="txtlat"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                                    ValidationGroup="123" Display="Dynamic" Type="Double" ControlToValidate="txtlat"></asp:CompareValidator>
                            </td>
                            <td class="lefttd">
                                纬度：
                            </td>
                            <td class="righttd">
                                <asp:TextBox ID="txtlon" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    Display="Dynamic" ValidationGroup="123" ControlToValidate="txtlon"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Operator="DataTypeCheck"
                                    ValidationGroup="123" Display="Dynamic" Type="Double" ControlToValidate="txtlon"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="lefttd">
                                备注：
                            </td>
                            <td class="righttd" colspan="6">
                                <asp:TextBox ID="txtremark" runat="server" TextMode="MultiLine" Rows="3" Width="435px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="button" ValidationGroup="123"
                        OnClick="btnAdd_Click" />
                </center>
            </asp:Panel>
            <asp:Panel ID="panelimport" GroupingText="添加基站坐标" Font-Size="Large" runat="server">
                <center>
                    计划名称:<asp:DropDownList ID="dropplan" runat="server" AutoPostBack="true" CssClass="dropdownlist"
                        OnSelectedIndexChanged="dropplan_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnLook" runat="server" Text="在地图上查看" CssClass="button" Width="120px" />
                    <asp:GridView runat="server" ID="grvimport" AutoGenerateColumns="False" CssClass="gridview"
                        EmptyDataText="无数据" OnRowCommand="grvimport_RowCommand" OnRowDataBound="grvimport_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="定位时间">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="label1" Text='<%#Bind("locatetime","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="纬度">
                                <ItemTemplate>
                                    <asp:Label ID="lblat" runat="server" Text='<%# Bind("Lat") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="经度">
                                <ItemTemplate>
                                    <asp:Label ID="lblon" runat="server" Text='<%# Bind("Lon") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="基站">
                                <ItemTemplate>
                                    <asp:Label ID="lbisstation" runat="server" Text='<%#Eval("isautolocate").ToString()=="1"?"":"*" %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="地图查看">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lbmapview" Text="查看"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="基站(井)名">
                                <ItemTemplate>
                                    <asp:TextBox ID="txttitle" runat="server" Width="80%"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtremark" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="添加到路线">
                                <ItemTemplate>
                                    <asp:Button ID="btnadd" runat="server" Text="添加" CommandName="add" CommandArgument='<%#Container.DataItemIndex %>'
                                        CssClass="button" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </center>
            </asp:Panel>
            <asp:Panel ID="panelrouteinfo" GroupingText="线路信息" Font-Size="Large" runat="server">
                <center>
                    <asp:GridView runat="server" ID="grvrouteinfo" AllowPaging="false" AutoGenerateColumns="false"
                        EmptyDataText="还未添加基站" CssClass="gridview" OnRowCommand="grvrouteinfo_RowCommand"
                        OnRowDeleting="grvrouteinfo_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="title" HeaderText="基站名" />
                            <asp:BoundField DataField="lat" HeaderText="纬度" />
                            <asp:BoundField DataField="lon" HeaderText="经度" />
                            <asp:BoundField DataField="remark" HeaderText="备注" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="上移" ID="btnup" CommandName="up" CssClass="button"
                                        Width="50px" />
                                    <asp:Button runat="server" Text="下移" ID="btndown" CommandName="down" CssClass="button"
                                        Width="50px" />
                                    <asp:Button ID="Button1" runat="server" CommandName="delete" Text="删除" CssClass="button"
                                        OnClientClick="return confirm('确定删除吗?')" Width="50px" />
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <center>
                        线路名：<asp:TextBox runat="server" ID="txtroutename" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="save"
                            ControlToValidate="txtroutename"></asp:RequiredFieldValidator>备注：<asp:TextBox ID="txtdescription"
                                runat="server" CssClass="textbox"></asp:TextBox><br />
                        <asp:Button ID="btnSubmit" runat="server" Text="保存" OnClick="btnSubmit_Click" CssClass="button"
                            ValidationGroup="save" />
                    </center>
                </center>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
