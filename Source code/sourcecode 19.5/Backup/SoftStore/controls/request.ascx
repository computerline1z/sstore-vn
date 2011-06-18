<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="request.ascx.cs" Inherits="SoftStore.controls.request" %>
<%@ Register TagPrefix="cc1" Namespace="WebControlCaptcha" Assembly="WebControlCaptcha" %>
<script type="text/javascript">
    function checkNull()
    {
        var fullname=document.getElementById('<%=txtFullName.ClientID %>');
        var soft=document.getElementById('<%=txtSoft.ClientID %>');
        var phone=document.getElementById('<%=txtPhone.ClientID %>');
        var email=document.getElementById('<%=txtEmail.ClientID %>');
        
        if(fullname.value==""||soft.value==""||phone.value==""||email.value=="")
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

</script>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>YÊU CẦU PHẦN MỀM</b>
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
                           
                        </tr>
                        
                        <tr>
                            <td align="right" style="width: 20%">
                               Công ty: &nbsp; <span style="color: #FF0000;"></span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtCompany" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Điện thoại:<span style="color: #ff0000">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
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
                                Tên phần mềm:<span style="color: #ff0000">*</span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtSoft" runat="server" CssClass="txt" Width="450px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Chức năng:<span style="color: #ff0000">*</span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtCN" runat="server" CssClass="txt" TextMode="MultiLine" Height="100px" Width="450px"></asp:TextBox></td>
                        </tr>
                
                        <tr>
                            <td align="right" style="width: 20%">
                                Mã an toàn: &nbsp;
                            </td>
                            <td align="left" style="width: 50%">
                                <cc1:CaptchaControl ID="captchaCode" runat="server" CaptchaHeight="40" CaptchaWidth="150"
                                    Text="Nhập mã:" CaptchaLength="4"></cc1:CaptchaControl>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 20%">
                                &nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:Button ID="btnRegister" OnClientClick="return checkNull()" CssClass="small-button" runat="server" Text="Gửi yêu cầu"
                                    OnClick="btnRegister_Click" />
                                <input type="reset" value="Hủy" class="small-button" /></td>

                        </tr>
                        <tr>
                            <td colspan="2" align="center">
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
