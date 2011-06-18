<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="change_password.ascx.cs" Inherits="SoftStore.controls.change_password" %>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>THAY ĐỔI MẬT KHẨU</b></td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="right" style="width: 20%">
                                Mật khẩu hiện tại&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtCurentPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Mật khẩu mới&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Xác nhận mật khẩu mới&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                
                        <tr>
                            <td align="right" style="width: 20%">
                                </td>
                            <td align="left" style="width: 50%">
                                <asp:Button ID="btnChange" CssClass="small-button" runat="server" Text="Đồng ý"
                                    OnClick="btnChange_Click" /></td>
                        </tr>
                    </table>
            </div>
        </td>
        <td id="frame-r" />
    </tr>
    <tr>
        <td id="frame-bl" />
        <td id="frame-b" />
        <td id="frame-br" />
    </tr>
</table>