<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderslist.ascx.cs" Inherits="SoftStore.admin.controls.orderslist" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Danh sách đơn hàng
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
                <th style="width:15%" class="table-sortable:numeric">
                    Mã đơn hàng</th>
                <th style="width:20%" class="table-sortable:default">
                    Khách hàng</th>
                <th style="width:15%" class="table-sortable:default">
                    Điện thoại</th>
                <th style="width:15%" class="table-sortable:numeric">
                    Email</th>
                <th style="width:15%" class="table-sortable:numeric">
                    Ngày đặt</th>
                <th style="width:10%" class="table-sortable:numeric">
                    Tổng tiền</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT") %> </td>
                        <td align="center"><a href="default.aspx?n=orderslist&id=<%# Eval("ID") %>" ><%# Eval("ID") %></a></td>
                        <td><a href="default.aspx?n=orderslist&id=<%# Eval("ID") %>" ><%# Eval("CustomerName")%> </a></td>
                        <td><%# Eval("CustomerPhone")%> </td>
                        <td><%# Eval("CustomerEmail")%> </td>
                        <td align="center"><%#DateTime.Parse(Eval("OrderDate").ToString()).ToString("dd/MM/yyyy HH:mm") %> </td>
                        <td align="right"><%#long.Parse(Eval("TotalPrice").ToString()).ToString("#,##0") %> </td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnDel" OnClientClick="return confirm('Bạn chắc chắn muốn xóa đơn hàng đã chọn?')" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
            </td>
        </tr>
        </table>
        </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paEdit" runat="server" Width="100%" Visible="false">
            <table cellpadding="3" cellspacing="0" style="width: 100%">
        <tr>
            <td style="width: 100%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px;">
                <strong><span style="color: #3366ff">THÔNG TIN KHÁCH HÀNG</span></strong></td>
        </tr>
        <tr>
            <td style="width: 100%">
                <table class="tableEdit" border="0" cellpadding="7" cellspacing="0" width="100%">
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Họ tên</td>
                        <td style="width: 75%">
                            <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Địa chỉ</td>
                        <td style="width: 75%">
                            <asp:Label ID="lblAddress" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                       <td class="bg_left" style="width: 25%;">
                            Số điện thoại</td>
                        <td style="width: 75%">
                            <asp:Label ID="lblPhone" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Email</td>
                        <td style="width: 75%;">
                            <asp:Label ID="lblEmail" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Địa chỉ giao hàng</td>
                        <td style="width: 75%">
                            <asp:Label ID="lblReceiveAddress" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Hình thức giao hàng</td>
                        <td style="width: 75%;">
                            <asp:Label ID="lblReceiveMethods" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%;">
                            Hình thức thanh toán</td>
                        <td style="width: 75%;">
                            <asp:Label ID="lblPaymentMethods" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="bg_left" style="width: 25%; border-bottom:solid 1px #dadada">
                            Ghi chú</td>
                        <td style="width: 75%; border-bottom:solid 1px #dadada">
                            <asp:Label ID="lblDes" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px;" class="htquanly1">
                <strong><span style="color: #0066ff">THÔNG TIN SẢN PHẨM</span></strong></td>
        </tr>
        <tr>
            <td style="width: 100%">
                <table border="1" cellpadding="0" cellspacing="0" class="bordergrid" width="100%">
                    <tr class="header">
                        <td style="width: 10%">
                            STT</td>
                        <td style="width: 30%">
                            Tên sản phẩm</td>
                        <td style="width: 20%">
                            Giá</td>
                        <td style="width: 20%">
                            Số lượng</td>
                        <td style="width: 20%">
                            Thành tiền</td>
                    </tr>
                    <asp:Repeater ID="rptBasket" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td align="center" style="width: 10%">
                                    <%#Eval("STT") %>
                                </td>
                                <td style="width: 30%">
                                    <%#getProduct(Eval("ProductID"))%>
                                </td>
                                <td align="right" style="width: 20%">
                                    <%#long.Parse(Eval("Price").ToString()).ToString("#,##0") %>
                                    
                                </td>
                                 <td align="center" style="width: 20%">
                                    <%#Eval("Amount") %>
                                </td>
                                <td align="right" style="width: 20%">
                                   <%#long.Parse((long.Parse(Eval("Price").ToString()) * int.Parse(Eval("Amount").ToString())).ToString()).ToString("#,#0")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-bottom:5px; width: 100%; padding-top: 7px; text-align: right">
                Tổng cộng:
                <asp:Label ID="lblTotal" runat="server" Font-Bold="True"></asp:Label> VNĐ</td>
        </tr>
        
        <tr>
            <td style="width: 100%; text-align: center">
                <%--<asp:Button ID="btnConfirm" runat="server" CssClass="btn" OnClick="btnConfirm_Click"
                    Text="Xác nhận đã giao hàng" />&nbsp;<asp:Button ID="btnNow" runat="server" CssClass="btn"
                        OnClick="btnNow_Click" Text="Xác nhận đang giao hàng" />--%>
                 <asp:ImageButton ID="btnBack" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/back.gif" OnClick="btnDone_Click" /></td>
        </tr>
    </table>
        </asp:Panel>    
        </td>
    </tr>
</table>