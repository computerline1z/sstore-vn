<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="package.ascx.cs" Inherits="SoftStore.admin.controls.package" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Hình thức đóng gói phần mềm</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
            <tr class="header">
               <th style="width:5%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:50%" class="table-sortable:default">
                    Hình thức đóng gói</th>
                <th style="width:15%" class="table-sortable:date">
                    Ngày tạo</th>
                 <th style="width:10%">
                    Published</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT")%> </td>
                        <td><a href="default.aspx?n=package&id=<%# Eval("PackageID") %>" ><%# Eval("PackageName")%> </a></td>
                        <td align="center"><%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("dd/MM/yyyy HH:mm")%></td>
                        <td align="center"><asp:CheckBox ID="cbkPublish" runat="server" Checked='<%#Eval("Status")%>' /></td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("PackageID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton OnClientClick="return confirm('Xác nhận xóa?')" ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" /></td>
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
                        Hình thức đóng gói</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="350px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="??"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Ghi chú</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Published</td>
                    <td colspan="3" style="width: 35%">
                        <asp:RadioButton ID="rdbYes" runat="server" GroupName="publish" Text="Có" />&nbsp;<asp:RadioButton
                            ID="rdbNo" runat="server" Checked="True" GroupName="publish" Text="Không" /></td>
                </tr>
                
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:ImageButton id="btnSubmit" BorderWidth="1px" ImageUrl="../styles/submit.gif" runat="server" OnClick="btnSubmit_Click" />
                        <asp:ImageButton ID="btnBack" runat="server" BorderWidth="1px" CausesValidation="False"
                            ImageUrl="../styles/back.gif" OnClick="btnBack_Click" /></td>
                </tr>
            </table>
        </asp:Panel>    
        </td>
    </tr>
</table>