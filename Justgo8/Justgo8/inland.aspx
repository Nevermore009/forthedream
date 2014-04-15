<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="inland.aspx.cs" Inherits="Justgo8.inland" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/outland.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #outland_bottom_Right_content1
        {
            width: 785px;
            margin-right: 0px;
            margin-top: 0px;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1
        {
            width: 750px;
            float: left;
            margin-left: 20px;
            margin-top: 15px;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li
        {
            width: 180px;
            border: 0px;
            list-style: none;
            display: inline;
            float: left;
            margin-bottom: 10px;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li span
        {
            float: left;
            width: 167px;
            display: table-cell;
            text-align: left;
            border: 0px;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li .outland_bottom_Right_ul1_title
        {
            height: 38px;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li .outland_bottom_Right_ul1_title a
        {
            font-size: 12px;
            font-weight: 600;
            color: #333333;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li .outland_bottom_Right_ul1_title a:hover
        {
            color: #ff0000;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li .outland_bottom_Right_ul1_title a:active
        {
            color: #333333;
        }
        #outland_bottom_Right_content1 .outland_bottom_Right_ul1 li .outland_bottom_Right_ul1_price
        {
            font-weight: bold;
            color: #ff6600;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="outland">
        <div class="clear">
        </div>
        <div id="route">
            您当前所在位置：<a href="index.aspx">首页</a>&nbsp;->&nbsp;<a href="###" target="_parent"><font
                color="#cd0007">出境旅游</font></a></div>
        <div class="clear">
        </div>
        <div id="outland_bottom">
            <div id="outland_bottomTop">
                <div class="outland_bottomTop_left">
                    <img src="images/index/inland.png" width="200px" height="30px" alt="" /></div>
                <div class="outland_bottomTop_right">
                    <a href="#" target="_blank" class="more">更多>></a></div>
            </div>
            <div class="clear">
            </div>
            <div id="outland_bottomMain">
                <div id="outland_bottom_Left">
                    <ul class="outland_bottom_Left_ul1">
                        <asp:Repeater runat="server" ID="RepeaterInland">
                            <ItemTemplate>
                                <li class="li_x"><a href="#" target="_blank">
                                    <%#Eval("areaname") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="clear">
                    </div>
                    <ul class="outland_bottom_Left_ul2">
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="clear">
                    </div>
                    <div class="outland_bottom_Left_ul4Div">
                    </div>
                    <!--关注我们-->
                </div>
                <div id="outland_bottom_Right">
                    <div id="outland_bottom_Right_content1">
                        <ul class="outland_bottom_Right_ul1">
                            <asp:Repeater runat="server" ID="repeateritem">
                                <ItemTemplate>
                                    <li><a href='detail.aspx?id=<%#Eval("id") %>' target="_blank"><span>
                                        <img src='<%#Eval("pic") %>' width="167px" height="105px" alt='<%#Eval("title") %>'
                                            title="<%#Eval("title") %>" /></span><span style="text-align: center;"><%#Eval("title") %>(<%#Eval("description") %>)</span><span
                                                class="outland_bottom_Right_ul1_price"><%#Eval("adultprice") %>元</span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
