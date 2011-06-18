<%@ Control Language="C#" AutoEventWireup="true" Codebehind="product_detail.ascx.cs"
    Inherits="SoftStore.controls.product_detail" %>
<%@ Register Src="productcomments.ascx" TagName="productcomments" TagPrefix="uc1" %>
<script type="text/javascript">
$(document).ready(function() {
	//When page loads...
	$(".tab_content").hide(); //Hide all content
	$("ul.info-tabs li:first").addClass("active").show(); //Activate first tab
	$(".tab_content:first").show(); //Show first tab content
	//On Click Event
	$("ul.info-tabs li").click(function() {
		$("ul.info-tabs li").removeClass("active"); //Remove any "active" class
		$(this).addClass("active"); //Add "active" class to selected tab
		$(".tab_content").hide(); //Hide all tab content

		var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active ID content
		return false;
	});
});
</script>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl" />
        <td id="frame-t">
        </td>
        <td id="frame-tr" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td style="background: #fff;">
            <div id="product-title">
                <asp:Literal ID="ltProductName" runat="server"></asp:Literal>
            </div>
            <div id="content">
                <div class="text">
                    <asp:Literal ID="ltPic" runat="server"></asp:Literal>
                    <div class="bold">
                        Giá: <span class="price">
                            <asp:Literal ID="ltPrice" runat="server"></asp:Literal></span>VNĐ</div>
                    <asp:Literal ID="ltSaleOff" runat="server"></asp:Literal>
                    <div class="bold">
                        Hình thức đóng gói:
                        <asp:DropDownList ID="drlPackages" runat="server" AppendDataBoundItems="true" Width="150px">
                            <asp:ListItem Text="--------Chọn--------" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <%--<div class="bold">
                        Số máy:
                        <input id="txtLicense" type="text" style="margin-left: 71px;" value="1" />
                    </div>--%>
                    <div class="bold">
                        Số lượng:
                        <input id="txtAmount" type="text" style="margin-left: 60px;" value="1" />
                    </div>
                    <div class="bold">
                        Đánh giá:<span><ajaxToolkit:Rating ID="Rating1"
                                        CurrentRating="2"
                                        MaxRating="5"
                                        CssClass="ratingStar"
                                        StarCssClass="ratingItem"
                                        WaitingStarCssClass="Saved"
                                        FilledStarCssClass="Filled"
                                        EmptyStarCssClass="Empty" 
                                        runat="server">
                                        </ajaxToolkit:Rating></span>
                    </div>
                    <div class="bold">
                        Đánh giá của bạn:<span>
                            <!-- AddThis Button BEGIN -->
                            <div class="addthis_toolbox addthis_default_style " style="float: right; width: 160px;">
                                <a class="addthis_button_preferred_1"></a><a class="addthis_button_preferred_2"></a>
                                <a class="addthis_button_preferred_3"></a><a class="addthis_button_preferred_4"></a>
                                <a class="addthis_button_compact"></a>
                            </div>
                            <!-- AddThis Button END -->
                        </span>
                    </div>
                    <div class="button-container">
                    <script type="text/javascript">
                    function addToCart(){
                        var licenseType=document.getElementById('<%=drlPackages.ClientID %>').value;
                            if(licenseType=="0")
                            {
                                alert('Vui lòng chọn hình thức đóng gói');
                                return false;
                            }
                            else{
                                var aMount=document.getElementById('txtAmount').value;
                                //var license=document.getElementById('txtLicense').value;
                                var redirectUrl='/gio-hang/<%=Request["id"] %>-<%=price %>-' + aMount + '-' + licenseType + '.html';
                                //alert(redirectUrl);
                                window.location.href = redirectUrl;
                            }
                     }
                    </script>
                        <ul>
                            <li>
                                <input onclick="addToCart()" type="button" id="buynow-btn" class="yellow-button" value="MUA NGAY" />
                            </li>
                            <asp:Literal ID="ltLinkDownload" runat="server"></asp:Literal>
                            
                        </ul>
                    </div>
                    <br />
                    <br />
                    <div class="product-info">
                        <div class="bold">
                            THÔNG TIN SẢN PHẨM
                        </div>
                        <div class="info">
                            <ul class="info-tabs">
                                <li><a href="#tab_detail">CHI TIẾT</a></li>
                                <li><a href="#tab_tech">THÔNG TIN KĨ THUẬT</a></li>
                                <li><a href="#tab_comment">BÌNH LUẬN (<asp:Literal ID="ltCountComments" runat="server"></asp:Literal>)</a></li>
                            </ul>
                        </div>
                        <div class="tab_container">
                            <div id="tab_detail" class="tab_content">
                                <asp:Literal ID="ltDetailDes" runat="server"></asp:Literal>
                            </div>
                            <div id="tab_tech" class="tab_content">
                                <asp:Literal ID="ltTechDes" runat="server"></asp:Literal>
                            </div>
                            <div id="tab_comment" class="tab_content">
                                <uc1:productcomments id="Productcomments1" runat="server">
                                </uc1:productcomments>
                            </div>
                        </div>
                    </div>
                    <div class="frame-bottom" style="line-height: 12px;">
                        <span class="bold">
                            Tìm thêm :</span>
                            <asp:Literal ID="ltTags" runat="server"></asp:Literal>
                    </div>

                </div>
                <!--End div class=text-->
            </div>
            <!--End content-->
        </td>
        <td id="frame-r" />
    </tr>
    <tr>
        <td id="frame-bl" />
        <td id="frame-b" />
        <td id="frame-br" />
    </tr>
</table>
