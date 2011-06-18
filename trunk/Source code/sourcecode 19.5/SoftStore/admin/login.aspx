<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SoftStore.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SOFT STORE - Đăng nhập hệ thống</title>
    <link href="styles/css/default.css" title="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div><center><br /><br /><br />
        <table cellpadding="0" cellspacing="0" style="width: 800px; text-align:left; border:solid 1px #aaa">
            <tr>
                <td style="width: 100%;" class="banner">
                    <table cellpadding="2" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 100%">
                                <strong><span style="font-size: 12pt">
                            SOFT STORE</span></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 100%">
                                <strong><em>Hệ thống quản trị website</em></strong></td>
                        </tr>
                        <tr>
                            <td style="width: 100%">
                            </td>
                        </tr>
                    </table>
                
                </td>
            </tr>
            
            
            <tr>
                <td style="width: 100%; height:250px; text-align: center;" valign="middle">
                <center>
                    <table cellpadding="3" cellspacing="0" style="width: 400px; text-align: left">
                        <tr>
                            <td colspan="2" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px;
                                padding-top: 5px; text-align: center">
                                <strong><span style="font-size: 11pt">ĐĂNG NHẬP HỆ THỐNG</span></strong></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 20px; width: 30%">
                                Tên đăng nhập</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 20px; width: 30%">
                                Mật khẩu</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="txt" TextMode="Password" Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblErr" runat="server" ForeColor="#FF0033"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding-left: 20px; width: 30%">
                            </td>
                            <td style="width: 70%">
                                <asp:ImageButton ID="btnLogIn" runat="server" BorderWidth="1px" ImageUrl="styles/login.gif"
                                    OnClick="btnLogIn_Click" /></td>
                        </tr>
                    </table>
                </center>
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" class="footer">
                Admin Panel - Powered by <a class="linkfooter" target="_blank" href="http://www.lequangit.com">http://www.lequangit.com</a>
                </td>
            </tr>
        </table>
        </center>
    </div>
    </form>
</body>
</html>
