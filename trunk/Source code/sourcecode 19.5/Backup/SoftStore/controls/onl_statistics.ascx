<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="onl_statistics.ascx.cs" Inherits="SoftStore.controls.onl_statistics" %>
<div style="border:solid 1px #dadada">
    <div class="titleleft">
        THỐNG KÊ TRUY CẬP</div>
    <div style="padding:5px;background-color: #fff;">
    <table cellpadding="4">
        <tr>    
            <td>Đang online: <asp:Label ID="lblNow" runat="server"></asp:Label></td>
        </tr>
        <tr>    
            <td>Tổng số lượt: 
                    <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
        </tr>
    </table>
    </div>
</div>