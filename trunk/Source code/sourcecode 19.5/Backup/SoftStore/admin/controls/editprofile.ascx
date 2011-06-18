<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="editprofile.ascx.cs" Inherits="SoftStore.admin.controls.editprofile" %>
<table cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Thay đổi mật khẩu</td>
    </tr>
    <tr>
        <td style="width: 100%">
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
            <table class="tableEdit" cellpadding="3" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Mật khẩu hiện tại</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCurrentPass" runat="server" CssClass="txt" Width="200px" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPass"
                            ErrorMessage="?"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Mật khẩu mới</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNewPass" runat="server" CssClass="txt" TextMode="Password" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPass"
                            ErrorMessage="?"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Xác nhận mật khẩu mới</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtComfirm" runat="server" CssClass="txt" TextMode="Password" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComfirm"
                            ErrorMessage="?"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass"
                            ControlToValidate="txtComfirm" ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td colspan="3">
                        <asp:Label ID="lblNote" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td colspan="3">
                        <asp:ImageButton ID="btnOK" runat="server" BorderWidth="1px" ImageUrl="../styles/update.gif" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
