<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="smtp.ascx.cs" Inherits="SoftStore.admin.controls.smtp" %>
<table cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            SMTP mail Server</td>
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
                        SMTP Server</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtSMTP" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                        <span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSMTP"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Mail Address</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtMail" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                        <span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMail"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Password</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                        <span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton ID="btnOK" runat="server" BorderWidth="1px" ImageUrl="../styles/update.gif" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>