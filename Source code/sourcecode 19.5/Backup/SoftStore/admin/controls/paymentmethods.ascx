<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paymentmethods.ascx.cs" Inherits="SoftStore.admin.controls.paymentmethods" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            phương thức thanh toán
            </td>
    </tr>
    
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
                
            <tr class="header">
                <th style="width:30%" class="table-sortable:default">
                    Phương thức</th>
                <th style="width:10%" class="table-sortable:numeric">
                    Phí dịch vụ</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td><a href="default.aspx?n=paymentmethods&id=<%# Eval("MethodID") %>" ><%# Eval("MethodName")%> </a></td>
                        <td align="right"><%# Eval("Fee") %> </td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("MethodID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
            </td>
        </tr>
        </table>
        </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paEdit" runat="server" Width="100%" Visible="false">
            <table class="tableEdit" cellpadding="3" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Tên phương thức</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtMethodName" runat="server" CssClass="txt" Width="500px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMethodName"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                
                
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Hướng dẫn</td>
                    <td colspan="3" style="width: 85%;">
                    <CKEditor:CKEditorControl ID="txtReceiveTime" runat="server"></CKEditor:CKEditorControl>
                        </td>
                </tr>
               <tr>
                    <td class="bg_left" style="width: 15%">
                        Phí dịch vụ</td>
                    <td colspan="3" style="width: 85%;">
                        <asp:TextBox ID="txtFee" runat="server" CssClass="txt" Text="0"
                            Width="100px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton id="btnSubmit" BorderWidth="1px" ImageUrl="../styles/submit.gif" runat="server" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnCancel" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/cancel.gif" OnClick="btnCancel_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>