<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddGoods.aspx.cs" Inherits="Module_GoodsManager_AddGoods" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/Controls.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlGoodsItem" runat="server" GroupingText="缴费项目" Width="100%">
            <table>
                <tr>
                    <td class="lefttd">
                        <asp:Label ID="Label2" runat="server" Text="校区:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropcampus" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                            OnSelectedIndexChanged="dropcampus_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="dropcampus" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            ControlToValidate="dropcampus" ValidationGroup="goodsItem" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        <asp:Label ID="Label3" runat="server" Text="学校:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropschool" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                            OnSelectedIndexChanged="dropschool_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                            ControlToValidate="dropschool" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                            ControlToValidate="dropschool" ValidationGroup="goodsItem" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        <asp:Label ID="Label4" runat="server" Text="年级:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropgrade" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                            OnSelectedIndexChanged="dropgrade_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                            ControlToValidate="dropgrade" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                            ControlToValidate="dropgrade" ValidationGroup="goodsItem" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="lefttd">
                        <asp:Label ID="Label5" runat="server" Text="专业:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="dropprofession" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                            ControlToValidate="dropprofession" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                            ControlToValidate="dropprofession" ValidationGroup="goodsItem" InitialValue="--请选择--"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        <asp:Label ID="lbGoodsTypeName" runat="server" Text="所属类别:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:DropDownList ID="ddlGoodsType" runat="server" CssClass="dropdownlist">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlGoodsType" ValidationGroup="goodsItem">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        <asp:Label ID="lbGoodsItem" runat="server" Text="缴费项目:"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:TextBox ID="txtGoodsItem" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGoodsItem"
                            ErrorMessage="*" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="lefttd">
                        <asp:Label ID="Label1" runat="server" Text="价格(元):"></asp:Label>
                    </td>
                    <td class="righttd">
                        <asp:TextBox ID="txtprice" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:CompareValidator ID="compare1" runat="server" ControlToValidate="txtprice" ErrorMessage="*"
                            ValidationGroup="goodsItem" Type="Double" Operator="DataTypeCheck"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="txtprice" ValidationGroup="goodsItem"></asp:RequiredFieldValidator>
                    </td>
                    <td class="lefttd">
                        <asp:Label ID="lbGoodsItemMemo" runat="server" Text="项目描述:"></asp:Label>
                    </td>
                    <td class="righttd" colspan="3">
                        <asp:TextBox ID="txtGoodsItemMemo" runat="server" TextMode="MultiLine" Height="48px"
                            Width="320px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="lefttd">
                    </td>
                    <td class="righttd" colspan="3">
                        <asp:Button ID="btnAddGoodsItem" runat="server" ValidationGroup="goodsItem" Text="添加"
                            CssClass="button" OnClick="btnAddGoodsItem_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="pnlGoodsType" runat="server" GroupingText="缴费类别" Width="100%">
            <div>
                <div>
                    <asp:Label ID="lbCampus" runat="server" Text="所属校区:"></asp:Label><asp:DropDownList
                        ID="ddlCampus" runat="server" CssClass="textbox">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="ddlCampus" ValidationGroup="goodsType"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lbGoodsType" runat="server" Text="缴费类别:"></asp:Label><asp:TextBox
                        ID="txtGoodsTypeName" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vGrade" runat="server" ErrorMessage="*" ControlToValidate="txtGoodsTypeName"
                        ValidationGroup="goodsType"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnAddGoodsType" runat="server" ValidationGroup="goodsType" Text="添加"
                        CssClass="button" OnClick="btnAddGoodsType_Click" />
                </div>
                <div>
                    <asp:Label ID="lbGradeMemo" runat="server" Text="类别描述:"></asp:Label><asp:TextBox
                        ID="txtGoodsTypeMemo" runat="server" TextMode="MultiLine" Height="48px" Width="320px"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
