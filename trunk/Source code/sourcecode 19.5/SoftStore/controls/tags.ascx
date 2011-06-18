<%@ Import Namespace="Utilities" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="tags.ascx.cs" Inherits="SoftStore.controls.tags" %>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
                    <td id="frame-tl"/>
                    <td id="frame-t">
                    </td>
                    <td id="frame-tr"/>
                </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
                <div class="frame-top">
                           <b>KẾT QUẢ TÌM KIẾM</b>     
							</div>
                <div class="h-grid">
                    <table id="tblList" width="100%">
                        <tr style="height: 1px">
                            <td style="height: 1px">
                                <asp:Label ID="lblKQ" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="item">
                                            <div class="img">
                                                <img src="/resources/products/<%#Eval("ProductID") %>/<%#Eval("Picture") %>" width="88px" />
                                            </div>
                                            <a class="title" href="<%#Eval("CategoryPath") %>/san-pham/<%#Eval("ProductID") %>/<%#FriendlyURL.ConvertUrlFriendlyNoExt(Eval("ProductName")) %>.html">
                                                <h4>
                                                    <%#Eval("ProductName") %>
                                                </h4>
                                            </a><span class="bold">Giá: <span class="price">
                                                <%#long.Parse(Eval("Price").ToString()).ToString("#,##0") %>
                                            </span>VNĐ <%--&nbsp;&nbsp;<%#getPromotion(Eval("Price"),Eval("PromotionRate")) %>--%>
                                            </span>
                                            <div class="ratingStar">
                                                    <span class="Filled"/>
                                                    <span class="Filled"/>
                                                    <span class="Filled"/>
                                                    <span class="Filled"/>
                                                    <span class="empty"/>
                                                </a>
                                            </div>
                                            <%#Eval("ShortDescription") %>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="frame-bottom">
                    <div id="pagerList" class="paginator2">
                    </div>

                    <script type="text/javascript">
                        var pager = new Pager('tblList', 10); 
                        pager.init(); 
                        pager.showPageNav('pager', 'pagerList'); 
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
