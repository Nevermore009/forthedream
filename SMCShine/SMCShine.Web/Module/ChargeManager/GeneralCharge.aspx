<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneralCharge.aspx.cs" Inherits="Module_ChargeManager_GeneralCharge" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../js/Common.js"></script>
    <%--<script type="text/javascript" src="../../js/webPrint.js"></script>--%>
    <script type="text/javascript">
        function printBill(billnumber, campuGuid) {
            //debugger;
            var requestUrl = "../PrintHandler/BillPrint.aspx?billNumber=" + billnumber + "&campusGuid=" + campuGuid;
            //?action=GetServerBillPrint&keyName=Print_IncreaseCount&billNumber=00"; //JC20110802000007
            //window.open(url,'a','height=280, width=250');

            PrintHtml(requestUrl);
            return false;
        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="panel1" runat="server" GroupingText="缴费收银">
            <br />
            <asp:Panel ID="pnlAddCharge" runat="server" GroupingText="添加缴费信息">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lbSchool" Text="学校（学院）：" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSchoolName" Width="150px" runat="server" 
                                AutoPostBack="true" onselectedindexchanged="ddlSchoolName_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ToolTip="请选择学校（学院）" runat="server"
                                ErrorMessage="*" ValidationGroup="ss" ControlToValidate="ddlSchoolName" InitialValue="--请选择--" ></asp:RequiredFieldValidator>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ToolTip="请选择学校（学院）" runat="server"
                                ErrorMessage="*" ValidationGroup="tt" ControlToValidate="ddlSchoolName" InitialValue="--请选择--"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="身份证号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" Width="130px"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtID"
                                ToolTip="请填写身份证号码" ValidationGroup="ss" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtID"
                                ValidationExpression="^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$" ValidationGroup="ss"
                                ErrorMessage="*" ToolTip="身份证号码有误"></asp:RegularExpressionValidator>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text="姓名："></asp:Label>
                            <asp:TextBox ID="txtStudent" runat="server" Width="130px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtStudent"
                                ToolTip="请填写姓名" ValidationGroup="ss" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnCheck" runat="server" Text="验证学员" ValidationGroup="ss" OnClick="btnCheck_Click" />
                            <asp:Image ID="imgCheckFlag" runat="server" Visible="false" />
                            <asp:Label ID="lbWarn" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="缴费项目类别："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGoodsType" Width="150px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlGoodsType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlGoodsType" ValidationGroup="tt" ToolTip="请选择缴费类别"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlGoodsType" InitialValue="--请选择--" ValidationGroup="tt"
                                ToolTip="请选择缴费类别"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="缴费项目："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGoodsName" Width="180px" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlGoodsName_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlGoodsName" ValidationGroup="tt" ToolTip="请选择缴费项目"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="ddlGoodsName" InitialValue="--请选择--" ValidationGroup="tt"
                                ToolTip="请选择缴费项目"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label15" runat="server" Text="应付金额："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalMoney" runat="server" ReadOnly="true" BackColor="LightGray"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="实付金额："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPaidMoney" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPaidMoney"
                                ToolTip="请填写实付金额！" ValidationGroup="tt" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*"
                                ToolTip="只能填写非负实数" ValidationExpression="^\d+(\.\d+)?$" ControlToValidate="txtPaidMoney"
                                ValidationGroup="tt"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="减免：" ForeColor="Red"></asp:Label>
                            <asp:TextBox ID="txtSpecialPrice" runat="server" Text="0" ForeColor="Red" Width="80px"></asp:TextBox>
                            <asp:Label ID="lbUnit" runat="server" Text="（元）" ForeColor="Gray"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"
                                ToolTip="只能填写非负实数" ValidationExpression="^\d+(\.\d+)?$" ControlToValidate="txtSpecialPrice"
                                ValidationGroup="tt"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="收款方式："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChargeWay" runat="server" Width="130px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlChargeWay_SelectedIndexChanged">
                                <asp:ListItem Text="现金支付" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="银联支付" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Pos机票号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPosNumber" runat="server" Width="140px" Enabled="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdvPosNumber" runat="server" Enabled="false" ErrorMessage="*"
                                ControlToValidate="txtPosNumber" ValidationGroup="tt" ToolTip="请填写Pos机票号"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="btnAddCharge" Text="确    定" runat="server" Width="80px" ValidationGroup="tt"
                                OnClick="btnAddCharge_Click" />
                        </td>
                        <%--      <td>
                            <asp:Button ID="btnPrintTest" Text="打    印" runat="server" Width="80px" OnClick="btnPrintTest_Click" />
                        </td>--%>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label14" Text="备　　　　注：" runat="server"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMeno" TextMode="MultiLine" Width="300px" Height="50px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="pnlShowChargeInfo" GroupingText="单据信息" runat="server" ForeColor="Gray"
                Visible="false" BackColor="LightGray">
                <div>
                <asp:Label runat="server" ID="lbcampusGuid" Visible="false"></asp:Label>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="校　　　　区："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCampus" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="单 据 号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBillNumber" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="收  款  人："></asp:Label>
                            </td>
                            <td style="width:400px">
                                <asp:TextBox ID="txtUserAccount" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:Button ID="btnprint" runat="server" Text="打印" onclick="btnprint_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="学校（学院）："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSchool" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="年　　级："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGrade" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="专　　业："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtClassType" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="学　　　　号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentID" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="姓　　名："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStudentName" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="身份证号："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStuID" Width="130px" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="缴费项目类别："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGoodsTypeName" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="缴费项目："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGoodsName" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="减　　免："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReduceMoney" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="缴费方式："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCheckWay" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="应付金额："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTMoney" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="实付金额："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPMoney" runat="server" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </asp:Panel>
        <%--   <rsweb:ReportViewer ID="printViewer" runat="server" Width="690px" Height="235px">
            <LocalReport ReportPath="Module\PrintHandler\RDLC\Print_Charge.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource Name="ChargeNotePrintDS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>--%>
        <iframe id="printFrame" width="0" height="0"></iframe>
    </div>
    </form>
</body>
</html>
