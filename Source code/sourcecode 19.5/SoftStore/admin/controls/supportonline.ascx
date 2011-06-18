<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="supportonline.ascx.cs" Inherits="SoftStore.admin.controls.supportonline" %>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            hỗ trợ trực tuyến</td>
    </tr>
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
            <tr class="header">
               <th style="width:5%" class="table-sortable:numeric">
                    STT</th>
                <th style="width:20%" class="table-sortable:default">
                    Tên nhân viên</th>
                <th style="width:20%" class="table-sortable:default">
                    Nickname</th>
                <th style="width:15%" class="table-sortable:default">
                    Loại</th>
                <th style="width:15%" class="table-sortable:date">
                    Ngày đăng</th>
                <th style="width:15%" class="table-sortable:default">
                    Trạng thái</th>
                <th style="width:5%" class="table-sortable:numeric">
                    Thứ tự</th>
                <th style="width:5%">
                    <asp:CheckBox ID="cbkCheckAll" runat="server" onclick="checkUncheckAll(this);" ToolTip="Chọn xóa tất cả" /></th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("STT")%> </td>
                        <td><a href="default.aspx?n=supportonline&id=<%# Eval("ID") %>" ><%# Eval("Name")%> </a></td>
                        <td><%# Eval("Nick")%> </td>
                        <td align="center"><%#getType(Eval("TypeID"))%> </td>
                        <td align="center"><%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("dd/MM/yyyy HH:mm")%></td>
                        <td align="center"><%#getStatus(Eval("StatusID"))%> </td>
                        <td align="center"><%# Eval("IndexNumber")%> </td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton ID="btnDel" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" /></td>
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
                    <td class="bg_left" style="width: 15%">
                        Loại</td>
                    <td colspan="3" style="width: 35%">
                        <asp:DropDownList ID="drlType" runat="server" Width="150px">
                            <asp:ListItem Text="Yahoo" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Skype" Value="2"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Tên nhân viên</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="200px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Nhập Tên nhân viên"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Nickname</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtNick" runat="server" CssClass="txt" Width="200px"></asp:TextBox><span
                            style="color: #ff0033">* </span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNick"
                            ErrorMessage="Nhập nickname"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Thứ tự ưu tiên</td>
                    <td colspan="3" style="width: 35%">
                        <asp:TextBox ID="txtIndex" runat="server" CssClass="txt" Width="60px">1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="?"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="Thứ tự >=1" MaximumValue="9999999" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Trạng thái</td>
                    <td colspan="3" style="width: 35%">
                        <asp:DropDownList ID="drlStatus" runat="server" Width="150px">
                            <asp:ListItem Text="Kích hoạt" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Không kích hoạt" Value="0"></asp:ListItem>
                        </asp:DropDownList></td>
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