<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatrolPlanView.aspx.cs" Inherits="Admin_PatrolPlanView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>督巡计划查看</title>
    <link href="../css/Controls.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.1.3.1.pack.js" type="text/javascript"></script>
    <script src="../js/thickbox-compressed.js" type="text/javascript"></script>
    <link href="../css/thickbox.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .list
        {
            width: 900px;
            list-style-type: none;
        }
        .list li
        {
            float: left;
            margin: 5px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="script1" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <asp:Panel ID="panel2" runat="server" GroupingText="督巡计划查看">
            <center>
                巡检员：<asp:DropDownList ID="dropStaff" runat="server" Width="85px">
                </asp:DropDownList>
                路线类型：<asp:DropDownList ID="droprouteType" runat="server" Width="85px">
                </asp:DropDownList>
                路线名：<asp:DropDownList ID="dropRouteName" runat="server" Width="85px">
                </asp:DropDownList>
                巡检月份：<asp:DropDownList ID="dropMonth" runat="server" Width="85px">
                </asp:DropDownList>
                <asp:Button ID="btnselect" runat="server" Text="查询" OnClick="btnselect_Click" Width="80px"
                    Height="25px" />
                <asp:GridView runat="server" ID="grvPatrolPlan" CssClass="gridview" EmptyDataText="暂无督巡计划"
                    AllowPaging="True" AutoGenerateColumns="False" OnRowDeleting="grvPatrolPlan_RowDeleting"
                    DataKeyNames="planid,state,finishcount" PageSize="5" OnRowCancelingEdit="grvPatrolPlan_RowCancelingEdit"
                    OnRowEditing="grvPatrolPlan_RowEditing" OnRowUpdating="grvPatrolPlan_RowUpdating"
                    Style="margin: 10px 10px;" OnRowCommand="grvPatrolPlan_RowCommand" OnPageIndexChanging="grvPatrolPlan_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle Width="70px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="StaffName" HeaderText="巡检员" ReadOnly="true">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RouteTypeName" HeaderText="路线类型" ControlStyle-Width="100px"
                            ReadOnly="true" />
                        <asp:BoundField DataField="RouteName" HeaderText="路线名" ControlStyle-Width="100px"
                            ReadOnly="true" />
                        <asp:TemplateField HeaderText="计划年月">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbplantime" Text='<%#DataBinder.Eval(Container.DataItem,"planyear")+"年"+DataBinder.Eval(Container.DataItem,"planmonth")+"月"%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="计划次数">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lbstate" Text='<%#Eval("PatrolCount")%>'></asp:Label></ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="hdTrukunum" Style="display: none" Text='<%# Eval("PatrolCount") %>'
                                    runat="server" Font-Size="8" Width="55px" />
                                <asp:DropDownList ID="dropPatrolCount" runat="server" Width="100px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="finishcount" HeaderText="已巡次数" ReadOnly="true" />
                        <asp:TemplateField HeaderText="详细">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnviewdetail" Text="详细" CommandName="detail" CommandArgument='<%#Container.DataItemIndex %>'
                                    runat="server"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" Text="编辑"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" Text="删除" OnClientClick="return confirm('确定要删除吗')"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="update" Text="更新" ValidationGroup="sss"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="cancel" Text="取消"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" GroupingText="巡检详情" Visible="false">
            <center>
                <asp:GridView ID="grvrouteinfo" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="80%" CssClass="gridview" OnPageIndexChanging="grvrouteinfo_PageIndexChanging"
                    OnRowCommand="grvrouteinfo_RowCommand" EnableModelValidation="True"   OnRowDataBound="grvrouteinfo_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="巡检次号">
                            <ItemTemplate>
                                <asp:Label ID="lbcount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Orderno") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="计划巡检日期">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%#Bind("plandate","{0:yyyy-MM-dd}")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="实际巡检日期">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("starttime","{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完成时间">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FinishTime","{0:yyyy-MM-dd}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="说明" DataField="Remark" />
                        <asp:TemplateField HeaderText="按时巡检">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"plandate","{0:yyyy-MM-dd}").ToString()==DataBinder.Eval(Container.DataItem,"starttime","{0:yyyy-MM-dd}").ToString()?"是":"否"%>'>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="巡检状态">
                            <ItemTemplate>
                                <asp:Label ID="lbpatrolname" runat="server" Text='<%#ReturnString(Convert.ToString(DataBinder.Eval(Container.DataItem,"State")))%>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="图片浏览">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPic" runat="server" CommandName="Pictu" CommandArgument='<%#Eval("ID") %>'>查看</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </center>
            <br />
        </asp:Panel>
        <asp:Panel ID="Pic" runat="server" GroupingText="图片查看" Visible="false">
            <center>
                <br />
                <ul class="list">
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <li>
                                <div>
                                    <asp:HyperLink ID="HyperLink1" class="thickbox" runat="server" NavigateUrl='<%#Eval("Photo") %>'
                                        ToolTip='<%#Eval("Description").ToString()==""?"点击查看大图":DataBinder.Eval(Container.DataItem,"Description").ToString() %>'>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Photo")%>' Width="170px"
                                            Height="200px" />
                                    </asp:HyperLink>
                                </div>
                                <div>
                                    <asp:LinkButton ID="lbDel" runat="server" Text="删除" OnClientClick='return confirm("确定要删除吗？")'
                                        CommandName="Del" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
