<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="members.ascx.cs" Inherits="SoftStore.admin.controls.members" %>
<script type="text/javascript">
    function checkNull()
    {
        var fullname=document.getElementById('<%=txtFullName.ClientID %>');
        var phone=document.getElementById('<%=txtMobile.ClientID %>');
        var email=document.getElementById('<%=txtEmail.ClientID %>');
        
        if(fullname.value==""||phone.value==""||email.value=="")
        {
            alert('Bạn phải nhập đầy đủ các thông tin yêu cầu');
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
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Danh sách thành viên đăng ký
            </td>
    </tr>
    
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
                
            <tr class="header">
               <th style="width:5%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:20%" class="table-sortable:default">
                    Họ tên</th>
                <th style="width:20%" class="table-sortable:default">
                    Địa chỉ</th>
                <th style="width:10%" class="table-sortable:numeric">
                    Di động</th>
                <th style="width:15%" class="table-sortable:numeric">
                    Email</th>
                <th style="width:10%" class="table-sortable:numeric">
                    Ngày đăng ký</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT") %> </td>
                        <td><a href="default.aspx?n=members&id=<%# Eval("MemberID") %>" ><%# Eval("FullName")%> </a></td>
                        <td align="center"><%# Eval("Address")%> </td>
                        <td align="center"><%# Eval("Mobile") %> </td>
                        <td align="center"><%# Eval("Email") %> </td>
                        <td align="center"><%#DateTime.Parse(Eval("RegisteredDate").ToString()).ToString("dd/MM/yyyy") %> </td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("MemberID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
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
                            <td class="bg_left" style="width: 20%">
                                Họ tên:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                            <td align="center" style="width: 30%" rowspan="10" valign="top">
                                <br />
                                <img alt="avatar" id="imgAvatar" runat="server" src="/resources/avatars/avatar.jpg" style="width:150px" />
                                <br />(150x180px)
                            </td>
                        </tr>
                        <tr>
                            <td class="bg_left" style="width: 20%">
                                Tên đăng nhập:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr id="rowPass" runat="server">
                            <td class="bg_left" style="width: 20%">
                                Mật khẩu:<span style="color: #FF0000;">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txt" Width="200px"></asp:TextBox></td>
                        </tr>
                        <tr id="rowReset" runat="server">
                            <td class="bg_left" style="width: 20%">
                                Mật khẩu:&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <a href="default.aspx?n=resetpass&id=<%=Request["id"] %>">Reset Password</a></td>
                        </tr>
                        <tr>
                            <td class="bg_left" style="width: 20%">
                                Địa chỉ: &nbsp; <span style="color: #FF0000;"></span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bg_left" style="width: 20%">
                                Điện thoại:&nbsp;</td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bg_left" style="width: 20%">
                                Di động:<span style="color: #ff0000">*</span></td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="bg_left" style="width: 20%">
                                Email:<span style="color: #ff0000">*</span>
                            </td>
                            <td align="left" style="width: 50%">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                    <td class="bg_left" style="width: 15%">
                        Activate</td>
                    <td style="width: 50%">
                        <asp:RadioButton ID="rdbActivateY" runat="server" Checked="True" GroupName="Publish" Text="Có" />
                        <asp:RadioButton ID="rdbActivateN" runat="server" GroupName="Publish"
                            Text="Không" />
                        <asp:Label ID="lblAvatar" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 20%">
                         Avatar:&nbsp;
                    </td>
                    <td align="left" style="width: 50%">
                    <input id="flAvatar" runat="server" name="flAvatar" onchange="setImg(this.value);" style="width: 300px; height: 22px;" type="file" class="txt" />
                        </td>
                </tr>
               
                <tr>
                    <td colspan="3" style="text-align: center">
                        <asp:ImageButton id="btnSubmit" BorderWidth="1px" ImageUrl="../styles/submit.gif" runat="server" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/cancel.gif" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>