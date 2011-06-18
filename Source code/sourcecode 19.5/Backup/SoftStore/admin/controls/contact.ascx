<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="contact.ascx.cs" Inherits="SoftStore.admin.controls.contact" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            liên lạc khách hàng</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
            <tr class="header">
               <th style="width:5%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:50%" class="table-sortable:default">
                    Họ tên</th>
                <th style="width:15%">
                    Điện thoại</th>
                <th style="width:15%" class="table-sortable:date">
                    Ngày đăng</th>
                <th style="width:10%">
                    Trạng thái</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT")%> </td>
                        <td><a href="default.aspx?n=contact&id=<%# Eval("ID") %>" ><%# Eval("Fullname")%> </a></td>
                        <td> <%# Eval("Phone")%></td>
                        <td align="center"><%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("dd/MM/yyyy HH:mm")%></td>
                        <td> <%#getStatus(Eval("StatusID"))%></td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        <tr>
            <td align="right">
                <cc1:CollectionPager ID="pagerList" runat="server" BackText="trang trước" FirstText="trang đầu"
                    LabelStyle="" LabelText="Trang:" LastText="trang cuối" NextText="trang kế" PageNumbersStyle="padding:2px"
                    PageNumberStyle="padding:2px" PageSize="30" ResultsFormat="Hiển thị từ {0} đến {1} (trong tổng số {2} tin)"
                    ShowFirstLast="True" MaxPages="100" BackNextLinkSeparator="-">
                </cc1:CollectionPager>
            </td>
        </tr>
        <tr>
            <td align="center">
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
                        <td style="width: 20%" class="bg_left">
                            Họ tên khách hàng</td>
                        <td style="width: 25%">
                            <asp:Label ID="lblFullName" runat="server" Font-Bold="True"></asp:Label></td>
                        <td style="width: 15%" class="bg_left">
                            Email</td>
                        <td style="width: 35%">
                            <asp:Label ID="lblEmail" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 20%" class="bg_left">
                            Công ty</td>
                        <td style="width: 25%">
                            <asp:Label ID="lblCompany" runat="server" Font-Bold="True"></asp:Label></td>
                        <td style="width: 15%" class="bg_left">
                            Điện thoại</td>
                        <td style="width: 35%">
                            <asp:Label ID="lblTel" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 20%" class="bg_left">
                            Địa chỉ</td>
                        <td style="width: 25%">
                            <asp:Label ID="lblAddress" runat="server" Font-Bold="True"></asp:Label></td>
                        <td style="width: 15%" class="bg_left">
                            Fax</td>
                        <td style="width: 35%">
                            <asp:Label ID="lblMobile" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 20%" class="bg_left">
                            </td>
                        <td style="width: 25%">
                        </td>
                        <td style="width: 15%" class="bg_left">
                            Ngày gửi</td>
                        <td style="width: 35%">
                            <asp:Label ID="lblEdate" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                <tr>
                    <td class="bg_left" style="width: 20%">
                            Nội dung liên hệ</td>
                    <td colspan="3">
                            <asp:Label ID="lblContent" runat="server" Font-Bold="False" ForeColor="#3333CC"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton ID="btnBack" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/back.gif" OnClick="btnBack_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>