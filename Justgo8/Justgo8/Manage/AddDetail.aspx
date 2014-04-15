<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddDetail.aspx.cs" Inherits="Justgo8.Manage.AddDetail" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="js/Calendar3.js" type="text/javascript"></script>
    <style type="text/css">
        .contentfield
        {
            border: 1px solid gray;
        }
        .parttitle
        {
            font-weight: bold;
            font-size: 18px;
        }
        .basicinfo
        {
            font-size: 14px;
            line-height: 35px;
            width: 95%;
        }
        .contentfield .textbox
        {
            border: 1px solid gray;
            font-size: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SmallTitle" runat="server">
    编辑旅游信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <div class="contentfield">
        <span class="parttitle">基本信息</span>
        <asp:Label runat="server" Visible="false" ID="lbid"></asp:Label>
        <div style="text-align: center;">
            <table class="basicinfo">
                <tr>
                    <td style="text-align: right">
                        标题
                    </td>
                    <td colspan="3" style="text-align: left">
                        <asp:TextBox ID="txttitle" runat="server" CssClass="textbox" Width="98%"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txttitle"
                            SetFocusOnError="true" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                    <td style="display: none;">
                        出发城市
                    </td>
                    <td style="display: none;">
                        长沙
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        类型:
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList runat="server" ID="droptraveltype" Height="28px" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        行程:
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList runat="server" ID="dropjourneydays" Height="28px" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right">
                        交通:
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox runat="server" ID="txttransportation" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        门市价格
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtgeneralprice" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtgeneralprice"
                            SetFocusOnError="true" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                    <td style="text-align: right">
                        成人价
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtadultprice" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtadultprice"
                            SetFocusOnError="true" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                    <td style="text-align: right">
                        儿童价
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtchildprice" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtchildprice"
                            SetFocusOnError="true" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        出发日期(用于搜索)
                    </td>
                    <td colspan="5" style="text-align: left">
                        <asp:TextBox ID="txtstartdate" runat="server" onclick="new Calendar().show(this);"
                            CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                runat="server" ErrorMessage="*" ControlToValidate="txtstartdate" ValidationGroup="sss"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>-&nbsp;<asp:TextBox ID="txtenddate"
                                    runat="server" onclick="new Calendar().show(this);" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="txtenddate"
                                        SetFocusOnError="true" ValidationGroup="sss"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        简述(图片下方文字)
                    </td>
                    <td colspan="5" style="text-align: left">
                        <asp:TextBox runat="server" ID="txtdescription" CssClass="textbox" Width="85%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        出发日期(用于显示)
                    </td>
                    <td colspan="5" style="text-align: left">
                        <asp:TextBox runat="server" ID="txttraveldate" CssClass="textbox" Width="85%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        目的地
                    </td>
                    <td colspan="5" style="text-align: right; border: 1px solid gray">
                        <div style="text-align: left; padding-left: 50px;">
                            类型<asp:DropDownList runat="server" ID="dropdestinationtraveltype" Height="28px" Width="200px"
                                OnSelectedIndexChanged="dropdestinationtraveltype_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            地区:<asp:DropDownList runat="server" ID="droparea" Height="28px" Width="200px" OnSelectedIndexChanged="droparea_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            城市:<asp:DropDownList runat="server" ID="dropcity" Height="28px" Width="200px">
                            </asp:DropDownList>
                            <asp:Button runat="server" ID="btnadddestination" Text="添加" Height="28px" Width="100px"
                                OnClick="btnadddestination_Click" />
                        </div>
                        <center>
                            <div class="pro_list">
                                <ul class="pro_show" style="margin-top: 5px">
                                    <asp:Repeater ID="repeaterdestination" runat="server" OnItemCommand="RPlank_ItemCommand">
                                        <ItemTemplate>
                                            <li style="height: 165px"><font style="font-weight: bold; font-size: 18px">
                                                <%#(Eval("cityName") == null ||String.IsNullOrEmpty(Eval("cityName").ToString()))? Eval("areaname").ToString() :Eval("cityName").ToString()%></font>
                                                <br />
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("id")%>'
                                                    OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        图片
                    </td>
                    <td colspan="5" style="margin-top: 10px;text-align: right; border: 1px solid gray">
                        <div style="text-align: left; padding-left: 30px;">
                            <asp:FileUpload ID="fileuploadpic" runat="server" Height="20px" Width="100px" />
                            <asp:Button runat="server" ID="btnaddpic" Text="上传" Height="28px" Width="100px" OnClick="btnaddpic_Click" />
                        </div>
                        <center>
                            <div class="pro_list">
                                <ul class="pro_show" style="margin-top: 5px">
                                    <asp:Repeater ID="repeaterpic" runat="server" OnItemCommand="Repeaterpic_ItemCommand">
                                        <ItemTemplate>
                                            <li style="height: 165px">
                                                <img src='<%#Eval("pic")%>' alt="" width="100px" height="100px" />
                                                <br />
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="del" CommandArgument='<%# Eval("picid")%>'
                                                    OnClientClick="javascript:return confirm('确认是否删除？')">删除</asp:LinkButton></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </center>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </div>
    <div class="contentfield">
        <span class="parttitle">行程特色</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckfeature" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">费用包含</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckbillinclude" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">费用不含</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckbillbeside" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">服务标准</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckservicestandard" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">友情提示</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckpresentation" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">具体行程</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckjourney" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <div class="contentfield">
        <span class="parttitle">预定流程</span>
        <div style="text-align: center;">
            <FCK:FCKeditor ID="fckcontact" Height="450" Width="98%" runat="server">
            </FCK:FCKeditor>
            <br />
        </div>
    </div>
    <center style="margin-top: 10px">
        <asp:Button runat="server" ID="btnsubmit" Text="保存" OnClick="btnsubmit_Click" Width="120px"
            Height="30px" BackColor="SkyBlue" ValidationGroup="sss" />
        <input type="button" value="返回" style="width: 120px; height: 30px; background-color: skyblue"
            onclick="if(confirm('您所作的修改将丢失,确定返回吗?')) history.go(-1);" /></center>
</asp:Content>
