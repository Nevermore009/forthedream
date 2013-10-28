<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInMap.aspx.cs" Inherits="Admin_ViewInMap" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 

"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/ControlStyle2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <!--Google Map API V3-->
    <script src="../js/MapHelper.js" type="text/javascript"></script>
    <!--google map操作函数-->
    <script src="../js/http.js" type="text/javascript"></script>
    <!--Ajax请求数据-->
    <script src="../js/jquery-1.4.js" type="text/javascript"></script>
    <link href="../css/floatpanel.css" rel="stylesheet" type="text/css" />
    <script src="../js/ViewInMap.js" type="text/javascript"></script>
    <!--地图数据函数-->
    <script src="../js/floatpanel.js" type="text/javascript"></script>
    <!--浮动菜单-->
</head>
<body>
    <div id="drag">
        <div class="title">
            <h2>
                地图查看</h2>
            <div>
                <a class="min" href="javascript:;" title="最小化"></a><a class="max" href="javascript:;"
                    title="最大化"></a><a class="revert" href="javascript:;" title="还原"></a><a class="close"
                        href="javascript:;" title="关闭"></a>
            </div>
        </div>
        <div class="resizeL">
        </div>
        <div class="resizeT">
        </div>
        <div class="resizeR">
        </div>
        <div class="resizeB">
        </div>
        <div class="resizeLT">
        </div>
        <div class="resizeTR">
        </div>
        <div class="resizeBR">
        </div>
        <div class="resizeLB">
        </div>
        <div class="content">
            <form id="form1" runat="server">
            <asp:ScriptManager ID="script1" runat="server" EnableScriptGlobalization="true">
            </asp:ScriptManager>
            <cc1:TabContainer runat="server" ID="tab1" TabIndex="0">
                <cc1:TabPanel ID="tabroute" runat="server" TabIndex="0">
                    <HeaderTemplate>
                        <div onclick="clearAllRoute();clearAllPatrol();clearOnlineUser();">
                            线路查看</div>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" GroupingText="线路信息" ScrollBars="auto" Height="260px">
                            <center>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                                    EmptyDataText="未查找到数据" EmptyDataRowStyle-ForeColor="Red" Width="100%" DataKeyNames="RouteID"
                                    EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="资源级别" ReadOnly="True" DataField="RouteTypeName" />
                                        <asp:TemplateField HeaderText="名称">
                                            <ItemTemplate>
                                                <asp:Label ID="lbroutename" runat="server" Text='<%#Bind("RouteName") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </asp:Panel>
                        <hr style="color: Gray; border: 1px double gray" />
                        <asp:Panel ID="Panel2" runat="server" GroupingText="基站点列表" ScrollBars="Auto" Height="240px">
                            <center>
                                <table class="gridview" width="100%" cellpadding="0px" cellspacing="0px" id="routeinfo">
                                    <tr>
                                        <th style="border-width: 0px 1px 0px 0px;">
                                            基站名称
                                        </th>
                                        <th style="border-width: 0px 1px 0px 0px;">
                                            纬度
                                        </th>
                                        <th style="border-width: 0px 0px 0px 0px;">
                                            经度
                                        </th>
                                    </tr>
                                </table>
                            </center>
                        </asp:Panel>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tabpatrol" runat="server" TabIndex="1">
                    <HeaderTemplate>
                        <div onclick="showAllRoute();clearOnlineUser();showCurrentPatrol();">
                            巡检查看</div>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="panelset" GroupingText="显示设置">
                            <table>
                                <tr>
                                    <td>
                                        显示照片:<input type="checkbox" id="cbshowphoto" onchange="showPhotoChanged(this)" />
                                    </td>
                                    <td style="padding-left:30px">
                                        动态显示轨迹<input type="checkbox" id="cbshowdynamic" onchange="showWayChanged(this)" checked="checked" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:UpdatePanel ID="uid" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel3" runat="server" GroupingText="查看" ScrollBars="auto" Height="160px"
                                    Font-Size="16px">
                                    <center>
                                        <table style="line-height: 150%">
                                            <tr>
                                                <td>
                                                    年份：
                                                </td>
                                                <td style="width: 130px">
                                                    <asp:DropDownList runat="server" ID="dropYear" Width="120px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    月份：
                                                </td>
                                                <td style="width: 130px">
                                                    <asp:DropDownList runat="server" ID="dropMonth" Width="120px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    巡检员：
                                                </td>
                                                <td style="width: 130px">
                                                    <asp:DropDownList runat="server" ID="dropstaff" Width="120px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSelect" runat="server" Text="查询" Width="80px" Height="25px" OnClick="btnSelect_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </asp:Panel>
                                <hr style="color: Gray; border: 1px double gray" />
                                <asp:Panel ID="Panel4" runat="server" GroupingText="巡检记录" ScrollBars="auto" Height="280px">
                                    <center>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                                            EmptyDataText="未查找到数据" EmptyDataRowStyle-ForeColor="Red" DataKeyNames="planinfoid"
                                            Width="100%" EnableModelValidation="True" OnRowDataBound="GridView2_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="中继段">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbpatrolname" runat="server" Text='<%#"["+DataBinder.Eval(Container.DataItem,"StaffName")+"]第"+DataBinder.Eval(Container.DataItem,"orderno")+"次巡检" %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="中继段">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbroutename" runat="server" Text='<%#Bind("RouteName") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </center>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSelect" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tabonline" runat="server" HeaderText="在线用户">
                    <ContentTemplate>
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                            EmptyDataText="当前未检测到在线用户" EmptyDataRowStyle-ForeColor="Red" Width="100%" EnableModelValidation="True"
                            OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="巡检员" ReadOnly="True" DataField="StaffName" />
                                <asp:TemplateField HeaderText="最近经度">
                                    <ItemTemplate>
                                        <asp:Label ID="lbLon" runat="server" Text='<%#Bind("Lon") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="最近纬度" ReadOnly="True" DataField="Lat" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
            </form>
        </div>
    </div>
    <div id="map" style="position: absolute; top: 0px; left: 0px; z-index: -1; height: 100%;
        min-height: 600px; min-width: 700px; width: 100%; background-image: url(../images/loading.jpg);
        background-position: center;">
    </div>
</body>
</html>
