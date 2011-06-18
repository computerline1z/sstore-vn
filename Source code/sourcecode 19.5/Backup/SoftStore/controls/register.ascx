<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="register.ascx.cs" Inherits="SoftStore.controls.register" %>
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<script type="text/javascript">
    function checkNull()
    {
        var fullname=document.getElementById('<%=txtFullName.ClientID %>');
        var username=document.getElementById('<%=txtUserName.ClientID %>');
        var pass=document.getElementById('<%=txtPassword.ClientID %>');
        var phone=document.getElementById('<%=txtMobile.ClientID %>');
        var email=document.getElementById('<%=txtEmail.ClientID %>');
        
        if(fullname.value==""||username.value==""||pass.value==""||phone.value==""||email.value=="")
        {
            alert('Quý khách phải nhập đầy đủ các thông tin yêu cầu');
            return false;
        }  
        else
        {
            var value=email.value;
            if(value!="")
            {
                var AtPos = value.indexOf("@")
                var StopPos = value.lastIndexOf(".")
                if (AtPos == -1 || StopPos == -1) 
                {
                    alert("Địa chỉ email không hợp lệ, vui lòng kiểm tra lại");
                    return false;
                }
            }
        }
    }
    function setImg(path)
    {
  	    var imgAvatar = document.getElementById('<%=imgAvatar.ClientID %>');
  	    imgAvatar.src=null;	   	     
  	    imgAvatar.src=path; 
    }
</script>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>ĐĂNG KÝ THÀNH VIÊN</b>
        </td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
            <table width="100%" border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="right" style="width: 20%">
                                Họ tên:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                            <td align="center" style="width: 30%" rowspan="8" valign="middle">
                                <img alt="avatar" id="imgAvatar" runat="server" src="/resources/avatars/avatar.jpg" style="width:150px" />
                                (150x180px)
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Tên đăng nhập:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Mật khẩu:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Xác nhận mật khẩu:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Địa chỉ: &nbsp; <span style="color: #FF0000;"></span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Điện thoại:&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Di động:<span style="color: #ff0000">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Email:<span style="color: #ff0000">*</span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                <tr>
                    <td align="right" style="width: 20%">
                         Avatar:&nbsp;
                    </td>
                    <td align="left" style="width: 50%">
                    <input id="flAvatar" runat="server" name="flAvatar" onchange="setImg(this.value);" style="width: 300px; height: 22px;" type="file" class="txt" />
                        </td>
                    <td align="center" rowspan="1" style="width: 30%" valign="middle">
                        <asp:Label ID="lblAvatar" runat="server" Visible="False"></asp:Label></td>
                </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Mã an toàn: &nbsp;
                            </td>
                            <td align="left" style="width: 50%">
                                <cc1:CaptchaControl ID="captchaCode" runat="server" CaptchaHeight="40" CaptchaWidth="150"
                                    Text="Nhập mã:" CaptchaLength="4"></cc1:CaptchaControl>
                            </td>
                            <td align="right" style="width: 30%">
                                </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 20%">
                                &nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:Button ID="btnRegister" OnClientClick="return checkNull()" CssClass="small-button" runat="server" Text="Đăng ký"
                                    OnClick="btnRegister_Click" />
                                <input type="reset" value="Hủy" class="small-button" /></td>
                            <td align="right" style="width: 30%">
                                </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <span style="font-weight: bold; padding-left: 5px; text-decoration: underline">Ghi chú:</span>
                                Những phần có dấu (<span style="color: #FF0000;">*</span>) là những phần bắt buộc
                                Quý khách phải điền đầy đủ thông tin
                            </td>
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
