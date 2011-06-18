<%@ Control Language="C#" AutoEventWireup="true" Codebehind="home.ascx.cs" Inherits="SoftStore.controls.home" %>

<script type="text/javascript">
    $(document).ready(function() {
	//When page loads...
	$(".tab_content").hide(); //Hide all content
	$("ul.tabs li:first").addClass("active").show(); //Activate first tab
	$(".tab_content:first").show(); //Show first tab content

	//On Click Event
	$("ul.tabs li").click(function() {

		$("ul.tabs li").removeClass("active"); //Remove any "active" class
		$(this).addClass("active"); //Add "active" class to selected tab
		$(".tab_content").hide(); //Hide all tab content

		var activeTab = $(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active ID content
		return false;
	});
});
</script>

<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 20px 0px;">
    <tr>
        <td id="frame-tl" />
        <td id="frame-t">
        </td>
        <td id="frame-tr" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <div class="frame-top">
                    <h4 class="sale" style="margin-top: 2px; color: #00aae2">
                        <a href="/khuyen-mai.html">KHUYẾN MÃI</a></h4>
                </div>
                <asp:Literal ID="ltKM" runat="server"></asp:Literal>
            </div>
            <!-- end content -->
        </td>
        <td id="frame-r" />
    </tr>
    <tr>
        <td id="frame-bl" />
        <td id="frame-b" />
        <td id="frame-br" />
    </tr>
</table>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <ul class="tabs">
                <li><a href="#tab_bestsale">Phần mềm bán chạy</a></li>
                <asp:Literal ID="ltTab" runat="server"></asp:Literal>
            </ul>
        </td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <div class="tab_container">
                    <div id="tab_bestsale" class="tab_content">
                        <!--Table Content-->
                        <asp:Literal ID="ltBestSaleProducts" runat="server"></asp:Literal>
                    </div>
                    <asp:Literal ID="ltTabContent" runat="server"></asp:Literal>
                </div>
                <div class="frame-bottom">
                    

                    <%--<span>Sắp xếp :
                        <select style="font-size: 10px;">
                            <option value="tt">Giá tăng dần</option>
                            <option value="tt">Giá giảm dần</option>
                            <option value="tt">Từ A -> Z</option>
                        </select>
                    </span>--%>
                </div>
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
