<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeManage.aspx.cs" Inherits="Module_ChargeManager_ChargeManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Campus.ascx" TagName="dropcampus" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div>
        <center>
            时间:
            <asp:TextBox ID="txtstarttime" runat="server" CssClass="textbox"></asp:TextBox><cc1:CalendarExtender
                ID="calend1" Format="yyyy-MM-dd" runat="server" TargetControlID="txtstarttime"
                Enabled="True">
            </cc1:CalendarExtender>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" Type="Date"
                Operator="DataTypeCheck" ValidationGroup="sss" ControlToValidate="txtstarttime"></asp:CompareValidator>-&nbsp;&nbsp;<asp:TextBox
                    ID="txtendtime" runat="server" CssClass="textbox"></asp:TextBox><cc1:CalendarExtender
                        ID="calend2" Format="yyyy-MM-dd" runat="server" TargetControlID="txtendtime"
                        Enabled="True">
                    </cc1:CalendarExtender>
            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" Type="Date"
                Operator="GreaterThanEqual" ValidationGroup="sss" ControlToCompare="txtstarttime"
                ControlToValidate="txtendtime"></asp:CompareValidator>
            身份证号:<asp:TextBox ID="txtID" runat="server" CssClass="textbox"></asp:TextBox>
            缴费人:<asp:TextBox ID="txtstudent" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            单据号:<asp:TextBox ID="txtBillID" runat="server" CssClass="textbox"></asp:TextBox>
            <uc1:dropcampus runat="server" ID="mycampus"></uc1:dropcampus>
            <asp:Button runat="server" ID="btnsearch" CssClass="button" Text="查询" OnClick="btnsearch_Click" ValidationGroup="sss" />
        </center>
        <hr style="height: 1px; color: #444; width: 95%" />
        <center>
            共找到<asp:Label runat="server" ID="lbrecordcount" ForeColor="Blue" Font-Bold="true"></asp:Label>条记录&nbsp;&nbsp;&nbsp;&nbsp;金额合计:<asp:Label
                runat="server" ID="lbaccountsum"  ForeColor="Blue" Font-Bold="true"></asp:Label>元&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                runat="server" ID="btntoexcel" CssClass="button" onclick="btntoexcel_Click" Text="导出到excel" Visible="true" Width="100px" ValidationGroup="sss"/>
            <asp:GridView runat="server" ID="grvChargeList" CssClass="gridview" AutoGenerateColumns="False"
                EnableModelValidation="True" AllowPaging="True" OnPageIndexChanging="grvChargeList_PageIndexChanging"
                PageSize="15">
                <Columns>
                    <asp:TemplateField HeaderText="日期">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("OperateTime", "{0:yyyy-MM-dd}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="单据号">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("billnumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="缴费人">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("studentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="身份证号">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="金额">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("paidmoney") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="学校">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("schoolName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年级">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("gradeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="专业">
                        <ItemTemplate>
                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("classname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </center>
    </div>
    </form>
</body>
</html>
