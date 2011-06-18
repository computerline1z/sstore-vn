<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paymentcart.ascx.cs" Inherits="SoftStore.controls.paymentcart" %>
<script type="text/javascript">
    function checkNull()
    {
        var fullname=document.getElementById('<%=txtCustomerName.ClientID %>');
        var address=document.getElementById('<%=txtPhone.ClientID %>');
        var phone=document.getElementById('<%=txtPhone.ClientID %>');
        var receiveaddress=document.getElementById('<%=txtReceiveAddress.ClientID %>');
        var email=document.getElementById('<%=txtEmail.ClientID %>');
        
        if(fullname.value==""||phone.value==""||address.value==""||email.value==""||receiveaddress.value=="")
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
            <b>XÁC NHẬN ĐƠN HÀNG</b></td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
            <asp:Literal ID="ltCartNull" runat="server"></asp:Literal>
                    <asp:Panel ID="paStep1" runat="server" Width="100%">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td colspan="2" style="border-bottom: solid 2px #dadada; width: 100%; text-align: center;
                                    padding-top: 5px; padding-bottom: 5px;">
                                    <span style="color: red"><b>Bước 1: Thông tin khách hàng</b></span> &nbsp;&nbsp;-->&nbsp;&nbsp;<span
                                        style="color: gray"><b>Bước 2: Hình thức giao hàng</b></span> &nbsp;&nbsp; -->&nbsp;&nbsp;<span
                                            style="color: gray"><b>Bước 3: Hình thức thanh toán</b></span> &nbsp;&nbsp;
                                    -->&nbsp;&nbsp;<span style="color: gray"><b>Bước 4: Hoàn tất</b></span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; vertical-align:middle">
                                    Họ tên khách hàng:<span style="color: #FF0000;">*</span></td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="txt" Width="310px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; vertical-align:middle">
                                    Nơi ở:<span style="color: #FF0000;">*</span>
                                </td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" Width="500px" Height="30px"
                                        TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; vertical-align:middle">
                                    Điện thoại:<span style="color: #ff0000">*</span></td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" Width="310px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%; vertical-align:middle">
                                    Email:<span style="color: #ff0000">*</span>
                                </td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" Width="310px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="width: 20%; vertical-align:middle">
                                    Địa chỉ giao hàng:<span style="color: #FF0000;">*</span><br />
                                    <input type="checkbox" id="cbkGetAddress" onclick="GetAddress()" /><label for="cbkGetAddress">Giống nơi ở&nbsp;&nbsp;</label>
                                    <script type="text/javascript">
                                    function GetAddress(){
                                        var diachi = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_txtAddress');
                                        var diachigh = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_txtReceiveAddress');
                                        if(diachi !=null&& diachigh !=null)
                                        {
                                            diachigh.innerHTML=diachi.value;
                                        }
                                    }
                                    </script>
                                    </td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtReceiveAddress" runat="server" CssClass="txt" Height="30px" TextMode="MultiLine"
                                        Width="500px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="width: 20%; vertical-align:middle">
                                    Ghi chú thêm:</td>
                                <td align="left" style="width: 80%">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" Height="100px" TextMode="MultiLine"
                                        Width="500px"></asp:TextBox></td>
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
                                    <asp:Button ID="btnContinue" CssClass="small-button" OnClientClick="return checkNull()" runat="server" Text="Tiếp tục"
                                        OnClick="btnContinue_Click" />
                                    <asp:Button ID="btnEditCart" CssClass="small-button" runat="server" Text="Sửa đơn hàng"
                                        OnClick="btnEditCart_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="paStep2" runat="server" Width="100%" Visible="false">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td style="border-bottom: solid 2px #dadada; width: 100%; text-align: center; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    <span style="color: gray"><b>Bước 1: Thông tin khách hàng</b></span> &nbsp;&nbsp;-->&nbsp;&nbsp;<span
                                        style="color: red"><b>Bước 2: Hình thức giao hàng</b></span> &nbsp;&nbsp; -->&nbsp;&nbsp;<span
                                            style="color: gray"><b>Bước 3: Hình thức thanh toán</b></span> &nbsp;&nbsp;
                                    -->&nbsp;&nbsp;<span style="color: gray"><b>Bước 4: Hoàn tất</b></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-style01">
                                        <tr class="bg">
                                            <td width="45%">
                                                Hình thức
                                            </td>
                                            <td width="40%">
                                                Thời gian dự kiến</td>
                                            <td width="15%">
                                                Phụ thu
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptReceiveMethod" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="left">
                                                        <input type="checkbox" name="cbkReceiveMethod" id="cbkReceiveMethod" value='<%#Eval("MethodID")%>' />
                                                        <label for="cbkReceiveMethod"><%#Eval("MethodName")%></label>
                                                    </td>
                                                    <td align="left">
                                                        <%#Eval("ReceiveTime")%>
                                                    </td>
                                                    <td align="right">
                                                        <%#long.Parse(Eval("Fee").ToString()).ToString("#,##0")%>
                                                        VND
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnBackToStep1" CssClass="small-button" runat="server" Text="Quay lại" OnClick="btnBackToStep1_Click" />
                                    <asp:Button ID="btnStep2Continue" CssClass="small-button" runat="server" Text="Tiếp tục" OnClick="btnStep2Continue_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="paStep3" runat="server" Width="100%" Visible="false">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td style="border-bottom: solid 2px #dadada; width: 100%; text-align: center; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    <span style="color: gray"><b>Bước 1: Thông tin khách hàng</b></span> &nbsp;&nbsp;-->&nbsp;&nbsp;<span
                                        style="color: gray"><b>Bước 2: Hình thức giao hàng</b></span> &nbsp;&nbsp; -->&nbsp;&nbsp;<span
                                            style="color: red"><b>Bước 3: Hình thức thanh toán</b></span> &nbsp;&nbsp;
                                    -->&nbsp;&nbsp;<span style="color: gray"><b>Bước 4: Hoàn tất</b></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-style01">
                                        <tr class="bg">
                                            <td width="45%">
                                                Hình thức
                                            </td>
                                            <td width="40%">
                                                Hướng dẫn</td>
                                            <td width="15%">
                                                Phí dịch vụ
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptPaymentMethod" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="left">
                                                       <input type="checkbox" name="cbkPaymentMethod" id="cbkPaymentMethod" value='<%#Eval("MethodID")%>' />
                                                        <label for="cbkPaymentMethod"><%#Eval("MethodName")%></label>
                                                    </td>
                                                    <td align="left">
                                                        <%#Eval("Guide")%>
                                                    </td>
                                                    <td align="right">
                                                        <%#long.Parse(Eval("Fee").ToString()).ToString("#,##0")%>
                                                        VND
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnBacktoStep2" CssClass="small-button" runat="server" Text="Quay lại" OnClick="btnBacktoStep2_Click" />
                                    <asp:Button ID="btnStep3Continue" CssClass="small-button" runat="server" Text="Tiếp tục" OnClick="btnStep3Continue_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="paStep4" runat="server" Width="100%" Visible="false">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td style="border-bottom: solid 2px #dadada; width: 100%; text-align: center; padding-top: 5px;
                                    padding-bottom: 5px;">
                                    <span style="color: gray"><b>Bước 1: Thông tin khách hàng</b></span> &nbsp;&nbsp;-->&nbsp;&nbsp;<span
                                        style="color: gray"><b>Bước 2: Hình thức giao hàng</b></span> &nbsp;&nbsp; -->&nbsp;&nbsp;<span
                                            style="color: gray"><b>Bước 3: Hình thức thanh toán</b></span> &nbsp;&nbsp;
                                    -->&nbsp;&nbsp;<span style="color: red"><b>Bước 4: Hoàn tất</b></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom:solid 1px #aaa">
                                <b>THÔNG TIN KHÁCH HÀNG</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" cellpadding="2">
                                        <tr>
                                            <td style="width:30%;">
                                            Họ tên khách hàng
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblCustomerName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Nơi ở
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblAddress" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Điện thoại
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblPhone" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Email
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblEmail" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Địa chỉ giao hàng
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblReceiveAddress" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Ghi chú
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblDescription" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                            Phương thức giao hàng
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblReceiveMethod" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%;">
                                           Phương thức thanh toán
                                            </td>
                                            <td style="width:70%;">
                                                <asp:Label ID="lblPaymentMethod" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom:solid 1px #aaa">
                                <b>THÔNG TIN SẢN PHẨM</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                                                        <td width="15%">
                                                            Thành tiền</td>
                                                    </tr>
                                                    <asp:Repeater ID="rptBasket" runat="server">
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
                                                                   <%#Eval("Amount") %></td>
                                                                <td align="right">
                                                                    <%#long.Parse((long.Parse(Eval("Price").ToString()) * int.Parse(Eval("Amount").ToString())).ToString()).ToString("#,#0")%> VNĐ
                                                                </td>
                                                                
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <tr bgcolor="#F2F9FF" style="line-height: 25px;">
                                                        <td colspan="4" align="right">
                                                            <b>Tổng tiền:</b>
                                                        </td>
                                                        <td align="right" style="color: #FF0000">
                                                            <b>
                                                                <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                                                                VNĐ</b></td>
                                                    </tr>
                                                </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnBackToStep3" CssClass="small-button" runat="server" Text="Quay lại" OnClick="btnBackToStep3_Click" />
                                    <asp:Button ID="btnFinish" CssClass="small-button" runat="server" Text="Hoàn tất" OnClick="btnFinish_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
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