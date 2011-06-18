<%@ Import namespace="Utilities"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="products.ascx.cs" Inherits="SoftStore.controls.products" %>
<table cellpadding="0" cellspacing="0" style="float:right; margin:-5px -5px 0px 0px;">
               <tr>
                	<td colspan="3" style="text-transform:uppercase">
                    	<h4 style="display:none;"><asp:Literal ID="ltCategoryName" runat="server"></asp:Literal></h4>
                    </td>
                </tr>
                <tr>
                    <td id="frame-tl"/>
                    <td id="frame-t">
                    </td>
                    <td id="frame-tr"/>
                </tr>
                <tr>
                    <td id="frame-l"/>
                    <td>
                        <div id="content">
                        	<div class="frame-top">
                                <%--<span  id="filter">
                                	<div style="float:left">
                                 		 <input type="text" value="Từ khóa" width="100px"/>
                                    </div>
                                </span>
                                 <span>Phân loại : 
                                	<select>
                                    	<option value="tt">----chọn----</option>
                                        <option value="tt">Diệt virus & spam</option>
                                        <option value="tt">Internet</option>
                                        <option value="tt">Bảo mật mạng</option>
                                        <option value="tt">Bảo mật hệ thống</option>
                                	</select>
                                </span>	--%>
                       			<span style="float:right">Sắp xếp : 
                                	<asp:DropDownList ID="drlOrder" runat="server" OnSelectedIndexChanged="drlOrder_SelectedIndexChanged" AutoPostBack="true">
                                	    <asp:ListItem Text="Giá tăng dần" Value="0"></asp:ListItem>
                                	    <asp:ListItem Text="Giá giảm dần" Value="1"></asp:ListItem>
                                	    <asp:ListItem Text="Từ A -> Z" Value="2"></asp:ListItem>
                                	    <asp:ListItem Text="Đánh giá cao -> thấp" Value="3"></asp:ListItem>
                                	</asp:DropDownList>
                                </span>	
							</div>
                            <div class="h-grid">
                            <table id="tblList" width="100%">
                                <tr style="height:1px"><td style="height:1px"></td></tr>
                                <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                <tr><td>
                            	<div class="item">
                                	<div class="img">
                                	<a class="title" href="<%#Eval("CategoryPath")%>/san-pham/<%#Eval("ProductID") %>/<%#FriendlyURL.ConvertUrlFriendlyNoExt(Eval("ProductName")) %>.html">
                                    	<img src="/resources/products/<%#Eval("ProductID") %>/<%#Eval("Picture") %>" alt="<%#Eval("ProductID") %>/<%#Eval("Picture") %>" width="88px" /></a>
                                    </div>
                                    <a class="title" href="<%#Eval("CategoryPath") %>/san-pham/<%#Eval("ProductID") %>/<%#FriendlyURL.ConvertUrlFriendlyNoExt(Eval("ProductName")) %>.html">
                                       	<h4><%#Eval("ProductName") %></h4>
                                    </a>
                                    <span class="bold">
                                    	Giá: <span class="price"><%#long.Parse(Eval("Price").ToString()).ToString("#,##0") %></span>VNĐ
                                        &nbsp;&nbsp;
                                        <%--<%#getPromotion(Eval("Price"),Eval("PromotionRate")) %>--%>
                                    </span>
                                    <ajaxToolkit:Rating ID="Rating1"
                                            CurrentRating="2"
                                            MaxRating="5"
                                            CssClass="ratingStar"
                                            StarCssClass="ratingItem"
                                            WaitingStarCssClass="Saved"
                                            FilledStarCssClass="Filled"
                                            EmptyStarCssClass="Empty" 
                                            runat="server">
                                            </ajaxToolkit:Rating>
                                <div>
                                <%#Eval("ShortDescription") %>
                                </div>
                                </div>
                                      </td></tr>
                                </ItemTemplate>
                                </asp:Repeater>
                                </table>
                            </div>
                            <div class="frame-bottom">
                                <div id="pagerList" class="paginator2"></div>
                    <script type="text/javascript">
                        var pager = new Pager('tblList', 10); 
                        pager.init(); 
                        pager.showPageNav('pager', 'pagerList'); 
                        pager.showPage(1);
                    </script>
                       			<%--<span>Sắp xếp : 
                                	<asp:DropDownList ID="drlOrderBottom" runat="server" OnSelectedIndexChanged="drlOrder_SelectedIndexChanged" AutoPostBack="true">
                                	    <asp:ListItem Text="Giá tăng dần" Value="0"></asp:ListItem>
                                	    <asp:ListItem Text="Giá giảm dần" Value="1"></asp:ListItem>
                                	    <asp:ListItem Text="Từ A -> Z" Value="2"></asp:ListItem>
                                	    <asp:ListItem Text="Đánh giá cao -> thấp" Value="3"></asp:ListItem>
                                	</asp:DropDownList>
                                </span>	--%>
							</div>
                         </div>
                         <!-- end content -->
                    </td>
                    <td id="frame-r"/>
    			   </tr>
    	            <tr>
                    <td id="frame-bl"/>
                    <td id="frame-b"/>
                    <td id="frame-br"/>
                </tr>
            </table>  