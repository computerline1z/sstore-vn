<%@ Import namespace="DataAccessLayer"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="products.ascx.cs" Inherits="SoftStore.admin.controls.products" %>
<%@ Register TagPrefix="pc" Namespace="Pyco.Web.UI.WebControls" Assembly="Pyco.Web" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<script type="text/javascript" language="javascript">
 
    function imgUpload(values)
    {
  	    var item = document.getElementById('div_img');
  	    if(item)
  	    {	 
  	        var img = document.getElementById('<%=imgpic.ClientID %>');	   	     
  	        img.src=values;
  	        item.style.display='inline';  
  	    } 
    }
</script>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            danh sách sản phẩm</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
            <tr class="header">
                <th style="width:4%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:8%" class="table-sortable:default">
                    Mã SP</th>
                <th style="width:20%" class="table-sortable:default">
                    Tên sản phẩm</th>
                <th style="width:10%" class="table-sortable:default">
                    Phiên bản</th>
                <th style="width:15%" class="table-sortable:default">
                    Nhà cung cấp</th>
                <th style="width:8%" class="table-sortable:numeric">
                    Giá bán</th>
                <th style="width:10%" class="table-sortable:default">
                    Tình trạng</th>
                <th style="width:8%" class="table-sortable:numeric">
                    Số lần xem</th>
                <th style="width:7%">
                    BestSale</th>
                <th style="width:7%">
                    Published</th>
                <th style="width:4%">
                    Xóa</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server">
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT")%>
                        <asp:Label ID="lblProductID" Text='<%# Eval("ProductID") %>' runat="server" Visible="false"></asp:Label>
                        </td>
                        <td align="center"><a href="default.aspx?n=products&id=<%# Eval("ProductID") %>" ><%# Eval("ProductID")%></a></td>
                        <td><a href="default.aspx?n=products&id=<%# Eval("ProductID") %>" ><%# Eval("ProductName")%> </a></td>
                        <td align="center"><%#Eval("Version") %></td>
                        <td align="left"><%#GetSupplier(Eval("SupplierID"))%></td>
                        <td align="right"><%#long.Parse(Eval("Price").ToString()).ToString("#,##0")%></td>
                        <td align="center">
                        <%#GetStatus(Eval("Status"))%>
                        </td>
                        <td align="center">
                        <%#Eval("ViewCount") %>
                        </td>
                        <td align="center">
                        <asp:CheckBox ID="cbkIsSetHot" runat="server" Checked='<%#Eval("IsHot") %>' />
                        </td>
                        <td align="center">
                        <asp:CheckBox ID="cbkIsPublished" runat="server" Checked='<%#Eval("IsPublish") %>' />
                        </td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ProductID")%>' /> </td>
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
                    PageNumberStyle="padding:2px" PageSize="30" ResultsFormat="Hiển thị từ {0} đến {1} (trong tổng số {2} sản phẩm)"
                    ShowFirstLast="True" MaxPages="100" BackNextLinkSeparator="-">
                </cc1:CollectionPager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton OnClientClick="return confirm('Xác nhận xóa sản phẩm đã chọn')" ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
                <%--<asp:ImageButton OnClientClick="return confirm('Xác nhận chuyển sản phẩm mới')" ID="btnSetNew" runat="server" BorderWidth="1px" ImageUrl="../styles/setnew.gif" OnClick="btnSetNew_Click" />--%>
                <asp:ImageButton OnClientClick="return confirm('Xác nhận chuyển sản phẩm bán chạy')" ID="btnSetHot" runat="server" BorderWidth="1px" ImageUrl="../styles/sethot.gif" OnClick="btnSetHot_Click" />
                <%--<asp:ImageButton OnClientClick="return confirm('Xác nhận chuyển sản phẩm khuyến mãi')" ID="btnSetBigSale" runat="server" BorderWidth="1px" ImageUrl="../styles/setbigsale.gif" OnClick="btnSetBig_Click" />--%>
                <asp:ImageButton OnClientClick="return confirm('Xác nhận publish sản phẩm đã chọn')" ID="btnPublished" runat="server" BorderWidth="1px" ImageUrl="../styles/published.gif" OnClick="btnPublished_Click" />
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
                    <td class="bg_left" style="width: 15%">
                        Category</td>
                    <td colspan="3" style="width:85%">
                    <asp:DropDownList ID="drlCategory" runat="server"  Width="500px">
                    </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Mã sản phẩm</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtProductID" runat="server" CssClass="txt" Width="80px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductID"
                                ErrorMessage="Nhập mã sản phẩm"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Tên sản phẩm</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtProductName" runat="server" CssClass="txt" Width="500px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName"
                                ErrorMessage="Nhập tên sản phẩm"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Nhà cung cấp</td>
                    <td colspan="3" style="width: 85%">
                    <asp:DropDownList ID="drlSupplierID" runat="server" Width="200px">
                        
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Phiên bản</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtVersion" runat="server" CssClass="txt" Width="150px">1.0</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Giá bán</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="txt" Width="150px">0</asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Tặng</td>
                    <td colspan="3" style="width: 85%">
                    <asp:TextBox ID="txtPromotionRate" runat="server" CssClass="txt" Width="33px" style="text-align:right">0</asp:TextBox>
                        %
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPromotionRate"
                            ErrorMessage="?"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPromotionRate"
                            ErrorMessage="Từ 0->100" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Tình trạng</td>
                    <td colspan="3" style="width: 85%; height: 26px;">
                        <asp:RadioButton ID="rdbStatusYes" runat="server" Checked="True" GroupName="Status" Text="Còn hàng" />
                        <asp:RadioButton ID="rdbStatusNo" runat="server" GroupName="Status"
                            Text="Hết hàng" /></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Giá tốt nhất</td>
                    <td colspan="3" style="width: 85%">
                        <asp:CheckBox ID="cbkIsBest" runat="server" /></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Sản phẩm bán chạy</td>
                    <td colspan="3" style="width: 85%">
                        <asp:CheckBox ID="cbkIsBestSale" runat="server" /></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Sản phẩm khuyến mãi</td>
                    <td colspan="3" style="width: 85%">
                        <asp:CheckBox ID="cbkKM" runat="server" /></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Hình thức đóng gói</td>
                    <td colspan="3" style="width: 85%">
                        <asp:CheckBoxList ID="drlProdcuctPack" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%;">
                        Ngày phát hành</td>
                    <td colspan="3" style="width: 85%;">
                    <input id="txtReleaseDate"  runat="server" style="width:80px" readonly="readonly" type="text" />
                     <img src="styles/ico_calender.gif" alt="Click here to select date" style="cursor:pointer" onclick="scwShow(scwID('<%=txtReleaseDate.ClientID %>'),event);"/>
                   <%-- <pc:calendar id="txtReleaseDate" runat="server" supportfolder="~/styles/JSCalendar" datetimeformat="dd/MM/yyyy" Size="8">
                    <SelectTemplate>
                                        <img src="styles/ico_calender.gif" />
                                    </SelectTemplate>
                    </pc:calendar>--%>
                        </td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Ngày cập nhật</td>
                    <td colspan="3" style="width: 85%">
                    <input id="txtUpdateDate"  runat="server" style="width:80px" readonly="readonly" type="text" />
                     <img src="styles/ico_calender.gif" alt="Click here to select date" style="cursor:pointer" onclick="scwShow(scwID('<%=txtUpdateDate.ClientID %>'),event);"/>
                    <%--<pc:calendar id="txtUpdateDate" runat="server" supportfolder="~/styles/JSCalendar" datetimeformat="dd/MM/yyyy" Size="8">
                    <SelectTemplate>
                                        <img src="styles/ico_calender.gif" />
                                    </SelectTemplate>
                    </pc:calendar>--%>
                        </td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Link Download</td>
                    <td colspan="3" style="width: 85%">
                    <asp:TextBox ID="txtLinkDownload" runat="server" CssClass="txt" Width="500px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Hình ảnh</td>
                    <td colspan="3" style="width: 85%">
                        <input id="imgAdv" runat="server" name="imgAdv" onchange="imgUpload(this.value);" style="width: 300px; height: 22px;" type="file" class="txt" />
                        
                        <br />
                        <div style="padding-top:5px;">
                        <div id="div_img" style="display:<%=Display %>;">
                            <img id="imgpic" runat="server" alt="" src="" width="120" style="border:1px solid #dadada" />
                            <asp:Label ID="lblPic" runat="server" Font-Bold="true"></asp:Label>
                        </div>
                        </div>
                    </td>
                </tr>
                
                
                
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Published</td>
                    <td colspan="3" style="width: 85%">
                        <asp:RadioButton ID="rdbPublishY" runat="server" GroupName="Publish" Text="Có" />
                        <asp:RadioButton ID="rdbIsPublishN" runat="server" Checked="True" GroupName="Publish"
                            Text="Không" /></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Tags</td>
                    <td colspan="3" style="width: 85%">
                    <asp:TextBox ID="txtTags" runat="server" CssClass="txt" Width="500px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="bg_left" colspan="3">
                        Keywords Content</td>
                    <td colspan="3" style="width: 85%"><asp:TextBox ID="txtKeywordsContent" runat="server" CssClass="txt" Width="500px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td class="bg_title" colspan="4">
                        <strong>Mô tả chi tiết</strong></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <CKEditor:CKEditorControl ID="txtDetailDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="bg_title">
                        <strong>Mô tả kỹ thuật</strong></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <CKEditor:CKEditorControl ID="txtTechDescription" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton id="btnSubmit" BorderWidth="1px" ImageUrl="../styles/submit.gif" runat="server" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/cancel.gif" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>