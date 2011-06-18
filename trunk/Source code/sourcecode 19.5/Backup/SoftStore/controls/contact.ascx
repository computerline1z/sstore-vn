<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact.ascx.cs" Inherits="SoftStore.controls.contact" %>
<script type="text/javascript">
    function checkNull()
    {
        var fullname=document.getElementById('<%=txtFullName.ClientID %>');
        var phone=document.getElementById('<%=txtPhone.ClientID %>');
        var content=document.getElementById('<%=txtContent.ClientID %>');
        var email=document.getElementById('<%=txtEmail.ClientID %>');
        
        if(fullname.value==""||phone.value==""||content.value==""||email.value=="")
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
            <b>LIÊN HỆ</b>
        </td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="line-height: 20px">
                                                    <tr>
                                                        <td colspan="4" height="20" style="color: #1191D5; font-weight: bold; text-transform: uppercase;
                                                            padding: 9px; font-size: 14px; text-align: center">
                                                            <asp:Literal ID="ltCompany" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="6" style="padding-left:30px; width: 24%;">
                                                            <img src="/images/logo.png" /></td>
                                                        <td width="12%">
                                                            Địa chỉ
                                                        </td>
                                                        <td width="2%">
                                                            :</td>
                                                        <td width="53%">
                                                            <asp:Literal ID="ltAddress" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Điện thoại
                                                        </td>
                                                        <td>
                                                            :</td>
                                                        <td>
                                                            <asp:Literal ID="ltPhone" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Fax</td>
                                                        <td>
                                                            :</td>
                                                        <td>
                                                            <asp:Literal ID="ltFax" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Hotline</td>
                                                        <td>
                                                            :</td>
                                                        <td>
                                                            <asp:Literal ID="ltHotMail" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Email</td>
                                                        <td>
                                                            :</td>
                                                        <td class="link">
                                                            <asp:Literal ID="ltEmail" runat="server"></asp:Literal></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Website</td>
                                                        <td>
                                                            :</td>
                                                        <td class="link">
                                                            <asp:Literal ID="ltWebsite" runat="server"></asp:Literal></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                        <tr>
                                            <td colspan="2" align="center" style="color: #333333; font-style: italic">
                                                Quý khách có thể liên hệ với chúng tôi theo biểu mẫu dưới đây.</td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                Họ tên:<span style="color: #FF0000;">*</span></td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtFullName" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                Địa chỉ: &nbsp; <span style="color: #FF0000;"></span>
                                            </td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                Điện thoại:<span style="color: #ff0000">*</span></td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                Fax: &nbsp;</td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtFax" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 20%">
                                                Email:<span style="color: #ff0000">*</span>
                                            </td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top" style="width: 20%">
                                                Nội dung:<span style="color: #FF0000;">*</span></td>
                                            <td align="left" style="width: 80%">
                                                <asp:TextBox ID="txtContent" runat="server" CssClass="txt" Height="100px" TextMode="MultiLine"
                                                    Width="350px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 20%">
                                                <span style="font-weight: bold; padding-left: 5px; text-decoration: underline">Ghi chú:</span>
                                                Những phần có dấu (<span style="color: #FF0000;">*</span>) là những phần bắt buộc
                                                Quý khách phải điền đầy đủ thông tin
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%">
                                                &nbsp;</td>
                                            <td align="left" style="width: 80%">
                                                <asp:Button ID="btnSend" CssClass="small-button" OnClientClick="return checkNull()" runat="server" Text="Gửi"
                                                    OnClick="btnSend_Click" />
                                                <input type="reset" value="Xóa" class="small-button" /></td>
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