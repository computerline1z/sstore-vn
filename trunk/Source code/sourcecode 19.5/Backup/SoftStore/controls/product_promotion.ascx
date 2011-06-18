<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="product_promotion.ascx.cs" Inherits="SoftStore.controls.product_promotion" %>
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
                <div class="frame-bottom">
                    <div id="pagerListKM" class="paginator2"></div>
                    <script type="text/javascript">
                        var pager = new Pager('tblListKM', 3); 
                        pager.init(); 
                        pager.showPageNav('pager', 'pagerListKM'); 
                        pager.showPage(1);
                    </script>
                </div>
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