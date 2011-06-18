<%@ Import Namespace="Utilities" %>
<%@ Control Language="C#" AutoEventWireup="true" Codebehind="news.ascx.cs" Inherits="SoftStore.controls.news" %>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b>
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></b>
        </td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <asp:Panel ID="paList" runat="server" Width="100%">
                <div id="content">
                    <%--<div class="h-grid">--%>
                    <table>
                        <asp:Repeater ID="rptListNews" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="item">
                                            <div class="img" style="float: left; margin-right: 5px; display: <%#DisplayImg(Eval("Picture")) %>">
                                                <img src="/resources/news/<%#Eval("Picture") %>" width="100px" alt="<%#Eval("PicNote") %>" />
                                            </div>
                                            <a class="title" href="/tin-tuc/<%#Eval("ID") %>/<%#FriendlyURL.ConvertUrlFriendlyNoExt(Eval("Title")) %>.html">
                                                <b>
                                                    <%#Eval("Title") %>
                                                </b></a>
                                            <div>
                                                <i>Cập nhật ngày
                                                    <%#DateTime.Parse(Eval("PublishedDate").ToString()).ToString("dd/MM/yyyy HH:mm:ss")%>
                                                </i>
                                            </div>
                                            <div>
                                                <%#Eval("Intro") %>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="height: 5px; border-top: dotted 1px #aaa">
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <%--</div> --%>
                    <div class="frame-bottom">
                        <span><a href="page3" class="active">Trang đầu</a> <a href="page3" class="active">TrangTrước</a>
                            <a href="page1" class="active">1 </a><a href="page1">2 </a><a href="page1">3 </a>
                            <a href="page3">Trang sau</a> <a href="page3">Trang cuối</a> </span>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="paDetail" runat="server" Width="100%" Visible="false">
                <div id="content">
                    <asp:Repeater ID="rptDetail" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <%--<div class="title"><h4><%#Eval("Title") %></h4></div>--%>
                                <div class="img" style="float: left; margin-right: 5px; display: <%#DisplayImg(Eval("Picture")) %>">
                                    <img src="/resources/news/<%#Eval("Picture") %>" width="200px" alt="<%#Eval("PicNote") %>" />
                                </div>
                                <div>
                                    <i>Cập nhật ngày
                                        <%#DateTime.Parse(Eval("PublishedDate").ToString()).ToString("dd/MM/yyyy HH:mm:ss")%>
                                    </i>
                                </div>
                                <div>
                                    <b>
                                        <%#Eval("Intro") %>
                                    </b>
                                </div>
                                <div>
                                    <%#Eval("Content") %>
                                </div>
                            </div>
                            </div>
                            <div style="height: 5px; border-top: dotted 1px #aaa">
                        </ItemTemplate>
                    </asp:Repeater>
            </asp:Panel>
        </td>
        <td id="frame-r" />
    </tr>
    <tr>
        <td id="frame-bl" />
        <td id="frame-b" />
        <td id="frame-br" />
    </tr>
</table>
