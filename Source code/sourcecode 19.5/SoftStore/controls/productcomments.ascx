<%@ Import namespace="BusinessObjects"%>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="productcomments.ascx.cs"
    Inherits="SoftStore.controls.productcomments" %>
<ul class="comment">
<asp:Repeater ID="rptListComment" runat="server">
<ItemTemplate>
    <li>
        <div class="avatar">
            <img src="/resources/avatars/<%#GetMember(Eval("MemberID"))[1]%>" />
        </div>
        <div class="comment-content">
            <div class="frame">
                <span><%#Eval("CommentContent") %></span>
                <div class="datetime">
                
                    <b><span style="text-decoration: none; color: #00aae2;"><%#GetMember(Eval("MemberID"))[0]%></span></b>
                    <span style="font-size: 11px; text-decoration: italic;">&nbsp;đã bình luận lúc</span>
                    <b><%#DateTime.Parse(Eval("CommentDate").ToString()).ToString("HH:mm - dd/MM/yyyy") %></b>
                    <br />
                </div>
            </div>
        </div>
    </li>
    
</ItemTemplate>
</asp:Repeater>
</ul>
<div class="your-comment">
    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="80px" CssClass="comment-text"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" CssClass="small-button" Text="BÌNH LUẬN" OnClick="btnSubmit_Click" />
</div>
