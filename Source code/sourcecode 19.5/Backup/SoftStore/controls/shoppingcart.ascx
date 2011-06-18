<%@ Control Language="C#" AutoEventWireup="true" Codebehind="shoppingcart.ascx.cs"
    Inherits="SoftStore.controls.shoppingcart" %>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>GIỎ HÀNG</b>
        </td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="center">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-style01">
                                <tr class="bg">
                                    <td width="5%" align="center">
                                        STT</td>
                                    <td width="50%">
                                        Tên sản phẩm
                                    </td>
                                    <td width="10%">
                                        Giá</td>
                                    <td width="10%">
                                        Số lượng
                                    </td>
                                    <td width="10%">
                                        Thành tiền</td>
                                    <td width="7%">
                                        Xóa</td>
                                </tr>
                                <asp:Repeater ID="rptBasket" runat="server" OnItemCommand="rptBasket_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <%#Eval("STT") %>
                                                <asp:Label ID="p_id" runat="server" Text='<%#Eval("ProductID")%>' Visible="false"></asp:Label></td>
                                            <td align="left">
                                                <%#Eval("ProductName")%>
                                            </td>
                                            <td align="right">
                                                <%#long.Parse(Eval("Price").ToString()).ToString("#,##0") %>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtAmount" Style="text-align: center" Text='<%#Eval("Amount") %>'
                                                    Width="40px" CssClass="txt" /></td>
                                            <td align="right">
                                                <%#long.Parse((long.Parse(Eval("Price").ToString()) * int.Parse(Eval("Amount").ToString())).ToString()).ToString("#,#0")%>
                                            </td>
                                            <td>
                                                <asp:ImageButton CausesValidation="false" ID="imgDelete" runat="server" ToolTip='<%#Eval("ProductID")%>'
                                                    ImageUrl="/images/delete.png" Width="24" Height="24" OnClientClick="return confirm('Bạn muốn xóa sản phẩm này khỏi giỏ hàng?')" /></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr bgcolor="#F2F9FF" style="line-height: 25px;">
                                    <td colspan="4" align="right">
                                        <b>Tổng tiền:</b>
                                    </td>
                                    <td colspan="2" align="right" style="color: #FF0000">
                                        <b>
                                            <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                                            VNĐ</b></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding: 5px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center" class="text">
                                <tr>
                                    <td align="center" style="padding: 5px;">
                                        <asp:Button ID="btnUpdate" CssClass="small-button" runat="server" OnClick="btnUpdate_Click"
                                            Text="Cập nhật" />
                                        <asp:Button ID="btnContinue" CssClass="small-button" runat="server" OnClick="btnContinue_Click"
                                            Text="Mua tiếp" />
                                        <asp:Button ID="btnPayment" CssClass="small-button" runat="server" OnClick="btnPayment_Click"
                                            Text="Thanh toán" />
                                    </td>
                                </tr>
                            </table>
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
