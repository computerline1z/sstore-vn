<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="company.ascx.cs" Inherits="SoftStore.admin.controls.company" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<table cellpadding="0" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Thông tin công ty</td>
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
                        Tên công ty</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="500px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                        <span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Nhập tên công ty"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Tên giao dịch tiếng anh</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNameEn" runat="server" CssClass="txt" Width="500px" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Địa chỉ</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="500px" Height="40px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <%--<tr>
                    <td class="bg_left" style="width: 15%">
                        Address</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtAddressEn" runat="server" CssClass="txt" Height="40px" TextMode="MultiLine"
                            Width="500px"></asp:TextBox></td>
                </tr>--%>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Số điện thoại</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Hotline</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtHotLine" runat="server" CssClass="txt" Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Fax</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtFax" runat="server" CssClass="txt" Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Email</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Website</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="txt" Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 15%; text-align:right">
                        <em><span style="text-decoration: underline">Chú ý:</span></em></td>
                    <td colspan="3">
                        <em>Các email, website cách nhau bởi dấu ";". Ví dụ: www.abc.com; www.abc.com.vn...</em></td>
                </tr>
                <tr>
                    <td colspan="4" class="bg_left" align="left" style="text-align:left">Chi tiết liên hệ</td>
                </tr>
                <tr>
                    <td colspan="4">
                    <CKEditor:CKEditorControl ID="txtContent" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;" class="bg_left">
                        Bản đồ</td>
                    <td colspan="3">
                    <input id="imgAdv" runat="server" name="imgAdv" style="width: 300px; height: 22px;" type="file" class="txt" />
                    <asp:Label ID="lblMap" runat="server" Font-Bold="true"></asp:Label>    
                        </td>
                </tr>
                <tr>
                    <td style="width: 15%">
                    </td>
                    <td colspan="3">
                    <img id="imgpic" runat="server" alt="" src="" width="500" style="border:1px solid #dadada" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton ID="btnOK" runat="server" BorderWidth="1px" ImageUrl="../styles/update.gif" OnClick="btnOK_Click" /></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
