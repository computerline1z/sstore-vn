<%@ Control Language="C#" AutoEventWireup="true" Codebehind="home.ascx.cs" Inherits="SoftStore.controls.home" %>
 <script language="javascript" type="text/javascript" src="/js/script.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/style-slideshow.css" media="screen" />
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
<div class="tab_container">
    <div id="gallery">
        <div id="slides">
            <div class="slide">
                <a href="/iphone.html" title="iphone4 white">
                    <img src="/images/iphone4.png" width="920" height="550" alt="side" />
                </a>
            </div>
            <div class="slide">
                <a href="/iphone.html" title="imac">
                <img src="/images/imac.png" width="920" height="550" alt="side" />
                </a>
            </div>
            <div class="slide">
                <a href="/iphone.html" title="imac">
                    <img src="/images/htc_sensation.png" width="920" height="550" alt="side" />
                </a>
            </div>
        </div>
        <div id="menu-gallery">
            <ul>
                <li class="menuItem"><a href=""><img src="/images/thumb_iphone4.png" alt="thumbnail" /></a></li>
                <li class="menuItem"><a href=""><img src="/images/thumb_imac.png" alt="thumbnail" /></a></li><li class="menuItem">
                <a href=""><img src="/images/thumb_htc.png" alt="thumbnail" /></a></li>
            </ul>
        </div>
    </div>
    <div id="tab-header">
        <ul class="tabs">
           <li><a href="#tab_bestsale" class="title_hot">HOT</a></li>
                <asp:Literal ID="ltTab" runat="server"></asp:Literal>
                <asp:Literal ID="ltTabContent" runat="server"></asp:Literal>
            <!--<li><a href="#tab_saleout">MUA NHIỀU NHẤT</a></li>
            <li><a href="#tab_lowprice">GIÁ RẺ HÔM NAY</a></li>
            <li><a href="#tab_newtech">CÔNG NGHỆ MỚI</a></li>
            <li><a href="#tab_newp">HÀNG MỚI</a></li>-->
        </ul>
    </div>	
    <div id="tab_hot" class="tab_content">
    </div>
</div>
<!--
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <div class="tab_container">
                    <div id="tab_bestsale" class="tab_content">
                        <%-- <asp:Literal ID="ltBestSaleProducts" runat="server"></asp:Literal>--%>
                    </div>
                    <%--<asp:Literal ID="ltTabContent" runat="server"></asp:Literal>--%>
                </div>
                <div class="frame-bottom">
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
-->