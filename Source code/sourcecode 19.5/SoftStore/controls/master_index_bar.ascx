<%@ Control Language="C#" AutoEventWireup="true" Codebehind="master_index_bar.ascx.cs"
    Inherits="SoftStore.controls.master_index_bar" %>
<div class="nav-bar">
     <asp:Literal ID="ltSiteMap" runat="server"></asp:Literal>
     <div class="carts">
         <a href="/gio-hang.html" title="Xem giỏ hàng"><asp:Literal ID="ltCart" runat="server"></asp:Literal></a>
     </div>
</div>
