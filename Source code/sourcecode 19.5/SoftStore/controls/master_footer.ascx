<%@ Import namespace="Utilities"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="master_footer.ascx.cs" Inherits="SoftStore.controls.master_footer" %>
<table cellpadding="0" cellspacing="0" style="margin: 0 auto;">
            <tr>
                <td id="frame-tl" />
                <td id="frame-t" />
                <td id="frame-tr" />
            </tr>
            <tr>
                <td id="frame-l" />
                <td>
                    <div id="footer">
                        <div id="logo2">
                        </div>
                        <asp:Repeater ID="rptNewsCategory" runat="server" OnItemDataBound="rptNewsCategoryOnItemDataBound">
                        <ItemTemplate>
                        <div style="float: left; width: 250px;">
                            <ul>
                                <li><b><%#Eval("CategoryName") %></b></li>
                                <asp:Repeater ID="rptListNews" runat="server">
                                <ItemTemplate>
                                <li><a href="/tin-tuc/<%#Eval("ID") %>/<%#FriendlyURL.ConvertUrlFriendlyNoExt(Eval("Title")) %>.html" title="<%#Eval("Title") %>"> <%#Util.SplitString(Eval("Title").ToString(),30) %></a></li>
                                </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        </ItemTemplate>
                        </asp:Repeater>
                        
                        
                        <div id="footer-bottom">
                            <div>
                                Copyright © 2011 Obuut Technologies Co,.ltd. All rights reserved.</div>
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