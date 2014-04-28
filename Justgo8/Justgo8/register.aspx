<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="Justgo8.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #main
        {
            width: 1000px;
            height: 600px;
        }
        #content
        {
            border: 1px solid #ccc;
            height: 564px;
            background-image: url(images/login/login_bg.png);
        }
        #registerform
        {
            width: 95%;
            line-height: 70px;
            font-size: 16px;
        }
        #registerform td
        {
            padding-left: 60px;
            width: 180px;
        }
        #leftcontent
        {
            float: left;
            width: 600px;
            height: 500px;
            border-right: 1px solid #aaa;
            margin-top: 30px;
        }
        #rightcontent
        {
            float: left;
            width: 380px;
            padding-left: 15px;
        }
        .protocoltext
        {
            font-size: 14px;
            width: 375px;
            height: 400px;
            border: 1px solid #cccccc;
        }
        .textbox
        {
            border: 1px solid gray;
            font-size: 16px;
        }
        .lefttd
        {
            text-align: right;
        }
    </style>
    <script type="text/javascript">
        function protocolagree(cb) {
            $("#<%=btnregister.ClientID %>").attr("disabled", cb.checked ? "" : "disable");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div class="clear">
        </div>
        <div id="route">
            您当前所在位置：<a href="index.aspx">首页</a>&nbsp;->&nbsp;<a href="#" target="_parent"><font
                color="#cd0007">注册</font></a></div>
        <div id="content">
            <div id="leftcontent">
                <table id="registerform">
                    <tr>
                        <td class="lefttd">
                            用户名:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtusername" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="validate1" runat="server" ErrorMessage="*" ControlToValidate="txtusername"
                                ForeColor="Red" ValidationGroup="sss"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            密码:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtpassword" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="validate2" runat="server" ErrorMessage="*" ControlToValidate="txtpassword"
                                ForeColor="Red" ValidationGroup="sss"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            确认密码:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtensure" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="validate3" runat="server" ErrorMessage="*" ControlToValidate="txtensure"
                                ForeColor="Red" ValidationGroup="sss"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码不一致"
                                Operator="Equal" ControlToCompare="txtpassword" ControlToValidate="txtensure"
                                ValidationGroup="sss" ForeColor="Red"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            联系电话:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtphone" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td style="text-align: left; font-size: 10px; line-height: 10px; padding-left: 0px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="txtphone" ForeColor="Red" ValidationGroup="sss"></asp:RequiredFieldValidator>
                            请正确填写,以便预订后能及时联系您
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            Email:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtemail" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="lefttd">
                            验证码:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcode" CssClass="textbox"></asp:TextBox>
                        </td>
                        <td>
                            <img src="Manage/CheckCodeImg.aspx" onclick="this.src='Manage/CheckCodeImg.aspx?id='+Math.random()"
                                alt="验证码" style="border: 1px solid #ccc; width: 60px; height: 25px;" /><asp:RequiredFieldValidator
                                    ID="validate4" runat="server" ErrorMessage="*" ControlToValidate="txtcode" ValidationGroup="sss"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="padding-top: 20px">
                            <asp:Button runat="server" ID="btnregister" Height="28px" Width="100px" Text="注册"
                                ValidationGroup="sss" OnClick="btnregister_Click" />
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbresult" ForeColor="Red" Font-Size="10px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="rightcontent">
                <font style="font-size: 20px; font-weight: bold">服务协议</font><br />
                <asp:TextBox runat="server" ID="txtprotocol" TextMode="MultiLine" ReadOnly="true"
                    CssClass="protocoltext" Rows="20" Text=""></asp:TextBox><br />
                <input type="checkbox" checked="checked" onclick="protocolagree(this)" />我已阅读并接受《湖南中联国际旅行社服务协议》
            </div>
        </div>
    </div>
</asp:Content>
