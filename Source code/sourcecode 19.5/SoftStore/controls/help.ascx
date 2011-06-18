<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="help.ascx.cs" Inherits="SoftStore.controls.help" %>
<table cellpadding="0" cellspacing="0" style="float: right; margin: -5px -5px 0px 0px;">
    <tr>
        <td id="frame-tl-s" />
        <td id="frame-t-s">
            <b><asp:Literal ID="ltTitle" runat="server"></asp:Literal></b></td>
        <td id="frame-tr-s" />
    </tr>
    <tr>
        <td id="frame-l" />
        <td>
            <div id="content">
            <div style="text-align:justify">
                <asp:Literal ID="ltContent" runat="server"></asp:Literal></div>
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