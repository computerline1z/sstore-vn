<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="productcategory.ascx.cs" Inherits="SoftStore.admin.controls.productcategory" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            danh mục sản phẩm</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        <asp:TreeView ID="TreeView1" runat="server" NodeIndent="40" ShowLines="True">
                            
                            <RootNodeStyle Font-Bold="True" Font-Size="17pt" />                            
                        </asp:TreeView>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                </td>
        </tr>
        </table>
        </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paEdit" runat="server" Width="100%" Visible="false">
            <table class="tableEdit" cellpadding="3" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Category</td>
                    <td colspan="3" style="width:85%">
                    <asp:DropDownList ID="drlParrentNode" runat="server"  Width="500px">
                    </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Tên danh mục</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="350px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="??"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Thứ tự</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtIndex" runat="server" CssClass="txt" Width="60px">1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="?"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="Thứ tự >=1" MaximumValue="9999999" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Published</td>
                    <td colspan="3" style="width: 35%">
                        <asp:RadioButton ID="rdbYes" runat="server" GroupName="publish" Text="Có" />&nbsp;<asp:RadioButton
                            ID="rdbNo" runat="server" Checked="True" GroupName="publish" Text="Không" /></td>
                </tr>
                
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton OnClientClick="return confirm('Bạn chắc chắn muốn xóa danh mục đang xem?')" ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
                        <asp:ImageButton id="btnSubmit" BorderWidth="1px" ImageUrl="../styles/submit.gif" runat="server" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnBack" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/back.gif" OnClick="btnBack_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>