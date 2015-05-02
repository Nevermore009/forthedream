<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Justgo8.FAQ1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>马上游-常见问题</title>
    <link href="css/question.css" rel="stylesheet" />
    <style type="text/css">
        .table1 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table2 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table3 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table4 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table5 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table6 td {
            border: #ccc solid 1px;
            padding: 5px;
        }

        .table2 .col1 {
            width: 74px;
        }

        .table4 .col1 {
            width: 74px;
        }

        .clause table {
            width: 100%;
        }

        .table3 td {
            width: 50%;
            text-align: center;
        }

        .table5 td {
            width: 50%;
            text-align: center;
        }

        .table6 td {
            width: 50%;
            text-align: center;
        }

        .jd_btn2 {
            background-image: url("theme/images/jinr.gif");
            background-repeat: no-repeat;
            color: #FFFFFF;
            display: block;
            font-weight: bold;
            height: 22px;
            line-height: 22px;
            margin-left: 180px;
            width: 104px;
        }

        .pubDiv_bg {
            display: none;
            width: 100%;
            height: 100%;
            background: #000;
            position: fixed;
            _position: absolute;
            left: 0;
            top: 0;
            z-index: 1999;
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(opacity=40)";
            filter: alpha(opacity=30);
            -moz-opacity: 0.3;
            -khtml-opacity: 0.3;
            opacity: 0.3;
        }

        .pubDiv {
            display: none;
            z-index: 2000;
            height: auto;
            position: fixed;
            top: 200px;
            left: 50%;
            border: 1px solid #CCCCCC;
            -moz-border-radius: 5px;
            -khtml-border-radius: 5px;
            -webkit-border-radius: 5px;
            border-radius: 5px;
            background: #FFF;
            padding: 5px 5px;
            overflow: hidden;
        }

        .pubDiv_title {
            background: url("theme/images/pub_tbg.gif") repeat-x scroll left -40px;
            clear: both;
            height: 30px;
            line-height: 30px;
            overflow: hidden;
            width: 100%;
            margin-bottom: 10px;
        }

            .pubDiv_title h2 {
                background: url("theme/images/pub_tbg.gif") no-repeat scroll left top;
                float: left;
                font-weight: bold;
                height: 30px;
                text-indent: 10px;
            }

            .pubDiv_title span {
                background: url("theme/images/pub_tbg.gif") no-repeat scroll right bottom;
                display: block;
                float: right;
                height: 30px;
                padding-right: 10px;
                width: 20px;
            }

        .pubDiv_content {
            width: 100%;
            height: auto;
            overflow: hidden;
            clear: both;
        }

        .ww {
            background: none repeat scroll 0 0 #FFFFFF;
            border: 1px solid #ccc;
            border-radius: 5px;
            height: auto;
            overflow: hidden;
            padding: 5px;
            position: fixed;
            z-index: 2000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contain">
        <p class="currentlocation">
            您当前所在位置：首页-><font color="#ca030a">常见问题</font>
        </p>
        <div class="qleft">

            <div>
                <asp:Repeater runat="server" ID="rpgroup" OnItemDataBound="rpgroup_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="lbgroupid" runat="server" Value='<%#Eval("groupid") %>' />
                        <p class="lefttitle"><%#Eval("groupname") %></p>
                        <ul class="ul0">
                            <asp:Repeater runat="server" ID="rpitem">
                                <ItemTemplate>
                                    <li class="<%#Request["id"]==Eval("id").ToString()?"li1":"li2" %>"><a title="<%#Eval("title") %>？" href="FAQ.aspx?id=<%#Eval("id") %>" alt="<%#Eval("title") %>"><%#Eval("title") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="qright">
            <h2><%=title %></h2>
           <%=content %>
        </div>
    </div>
    <div style="clear: both"></div>
    <br />
</asp:Content>
