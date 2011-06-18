<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usergroup.ascx.cs" Inherits="SoftStore.admin.controls.usergroup" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            danh sách nhóm người dùng</td>
    </tr>
    <tr>
        <td style="width: 100%">
            <table cellpadding="0" cellspacing="0" style="width: 800px">
                <tr>
                    <td style="width: 250px; text-align: right;">
                        Thêm mới nhóm người dùng&nbsp;</td>
                    <td style="width: 320px">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                            ErrorMessage="?"></asp:RequiredFieldValidator></td>
                    <td style="width: 80px">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                        <asp:ImageButton ID="btnUpdate" runat="server" BorderWidth="1px" ImageUrl="../styles/update.gif" OnClick="btnUpdate_Click" Visible="False" /></td>
                    <td style="width: 100px">
                        <asp:ImageButton ID="btnBack" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/cancel.gif" OnClick="btnBack_Click" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
            <tr class="header">
               <th style="width:5%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:60%" class="table-sortable:default">
                    Tên nhóm</th>
                <th style="width:30%">
                    Phân quyền</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT")%> </td>
                        <td><a href="default.aspx?n=usergroup&id=<%# Eval("ID") %>" ><%# Eval("Name")%> </a></td>
                        <td align="center"><a href="default.aspx?n=roles&id=<%# Eval("ID") %>" >phân quyền</a></td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" CausesValidation="False" /></td>
        </tr>
        </table>
        </asp:Panel>
        </td>
    </tr>
    
</table>