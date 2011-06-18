<%@ Control Language="C#" AutoEventWireup="true" Codebehind="userlist.ascx.cs" Inherits="SoftStore.admin.controls.userlist" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            danh sách người dùng</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
            <table class="bordergrid" cellpadding="2" cellspacing="0" width="100%">
                <tr class="header">
                    <td style="width: 5%">
                        STT</td>
                    <td style="width: 25%">
                        Họ tên</td>
                    <td style="width: 15%">
                        Tên đăng nhập</td>
                    <td style="width: 25%">
                        Nhóm</td>
                    <td style="width: 15%">
                        Kích hoạt</td>
                    <td style="width: 5%">
                        Chọn</td>
                </tr>
                <asp:Repeater ID="rptListUser" runat="Server">
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%# Eval("STT")%>
                            </td>
                            <td>
                                <a href="default.aspx?n=userlist&id=<%# Eval("ID") %>">
                                    <%# Eval("FullName")%>
                                </a>
                            </td>
                            <td>
                                <%# Eval("UserName")%>
                            </td>
                            <td>
                                <%#GetGroup(Eval("GroupID"))%>
                            </td>
                            <td align="center">
                                <%# Eval("StatusID")%>
                            </td>
                            <td align="center">
                                <input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="center" style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px">
                        <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif"
                            OnClick="btnNew_Click" />&nbsp;<asp:ImageButton ID="btnDel" runat="server" BorderWidth="1px"
                                ImageUrl="../styles/del.gif" OnClick="btnDel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paEdit" runat="server" Width="100%" Visible="False">
        <table class="tableEdit" style="width: 100%;" cellpadding="3" cellspacing="0">
        
        <tr>
            <td style="width: 30%;" class="bg_left">
                Họ tên</td>
            <td style="width: 70%;" align="left" valign="middle"><asp:TextBox ID="txtFullName" runat="server" Width="200px" CssClass="txt"></asp:TextBox>
                (<span style="color: #ff0033">*</span>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFullName" ErrorMessage="Vui lòng nhập tên người dùng"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 30%;" class="bg_left">
                Tên đăng nhập</td>
            <td style="width: 70%;"><asp:TextBox ID="txtusename" runat="server" Width="200px" CssClass="txt"></asp:TextBox>
                (<span style="color: #ff0033">*</span>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusename" ErrorMessage="Vui lòng nhập tên đăng nhập"></asp:RequiredFieldValidator></td>
        </tr>
        <tr id="rowMK" runat="server">
            <td style="width: 30%" class="bg_left">
                Mật khẩu</td>
            <td style="width: 70%"><asp:TextBox ID="txtpass" runat="server" CssClass="txt" Width="200px" TextMode="Password"></asp:TextBox>
                (<span style="color: #ff0033">*</span>)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpass" ErrorMessage="Vui lòng nhập mật khẩu"></asp:RequiredFieldValidator></td>
        </tr>
        <tr id="rowConfirmMK" runat="server">
            <td style="width: 30%" class="bg_left">
                Xác nhận mật khẩu</td>
            <td style="width: 70%"><asp:TextBox ID="txtConfirmPass" runat="server" CssClass="txt" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpass" ControlToValidate="txtConfirmPass" ErrorMessage="Xác nhận mật khẩu không đúng"></asp:CompareValidator></td>
        </tr>
         <tr id="rowReset" runat="server">
            <td style="width: 30%" class="bg_left">
            </td>
            <td style="width: 70%">
                <span><a href="default.aspx?n=resetpass&id=<%=Request["id"]%>">Cấp lại mật khẩu</a></span></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Nhóm</td>
            <td style="width: 70%"><asp:DropDownList ID="drlGroup" runat="server" Width="204px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Trạng thái</td>
            <td style="width: 70%">
                <asp:DropDownList ID="drlStatus" runat="server" Width="204px">
                <asp:ListItem Text="Actived" Value="1"></asp:ListItem>
                <asp:ListItem Text="Inactived" Value="-1"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Địa chỉ</td>
            <td style="width: 70%">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Số điện thoại</td>
            <td style="width: 70%">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Di động</td>
            <td style="width: 70%">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="txt" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Email</td>
            <td style="width: 70%">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 30%" class="bg_left">
                Ghi chú</td>
            <td style="width: 70%">
                <asp:TextBox ID="txtDes" runat="server" CssClass="txt" Width="400px" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
       
        
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:ImageButton ID="btnSubmit" runat="server" BorderWidth="1px" ImageUrl="../styles/submit.gif"
                        OnClick="btnSubmit_Click" />&nbsp;<asp:ImageButton ID="btnCancel" runat="server"
                            BorderWidth="1px" CausesValidation="False" ImageUrl="../styles/cancel.gif" OnClick="btnCancel_Click" /></td>
            </tr>
        </table>
        </asp:Panel>
        </td>
    </tr>
</table>
