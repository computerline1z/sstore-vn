<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="SoftStore.controls.login" %>
<script type="text/javascript">
    function checkNull()
    {
        var username=document.getElementById('<%=txtUserName.ClientID %>');
        var pass=document.getElementById('<%=txtPassword.ClientID %>');
        
        if(username.value=="")
        {
            alert('Vui lòng nhập tên đăng nhập');
            username.focus();
            return false;
        }  
        else
        {
            if(pass.value=="")
            {
                alert('Vui lòng nhập mật khẩu');
                pass.focus();
                return false;
            }
            return true;
        }
    }
</script>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>ĐĂNG NHẬP</b></td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="right" style="width: 20%">
                                Tên đăng nhập&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Mật khẩu&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                <tr>
                    <td align="right" style="width: 20%">
                    </td>
                    <td align="left" style="width: 50%">
                        <asp:CheckBox ID="cbkRemember" runat="server" Text="Ghi nhớ cho lần đăng nhập sau" /></td>
                </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                </td>
                            <td align="left" style="width: 50%">
                                <asp:Button ID="btnLogin" OnClientClick="return checkNull()" CssClass="small-button" runat="server" Text="Đăng nhập"
                                    OnClick="btnLogin_Click" /></td>
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