<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="advproducts.ascx.cs" Inherits="SoftStore.admin.controls.advproducts" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="Pyco.Web" Namespace="Pyco.Web.UI.WebControls" TagPrefix="cc2" %>

<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Danh sách quảng cáo theo từng chuyên mục sản phẩm
            </td>
    </tr>
    
    <tr>
        <td style="width: 100%">
        <asp:Panel ID="paList" runat="server" Width="100%">
        
        <table class="bordergrid table-autosort sort01" cellpadding="0" cellspacing="0" width="100%"  border="1">  
            <thead>
                
            <tr class="header">
                <th style="width:45%" class="table-sortable:default">
                    Tên</th>
                <th style="width:40%" class="table-sortable:default">
                    Chuyên mục</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td><a href="default.aspx?n=advproducts&id=<%# Eval("ID") %>" ><%# Eval("AdvName")%> </a></td>
                        <td><%#GetCategoryname( Eval("CategoryID"))%> </td>
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
                    <td class="bg_left" style="width: 15%">
                        Chuyên mục</td>
                    <td colspan="3" style="width: 85%">
                        <asp:DropDownList ID="drlCategory" runat="server" Width="318px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 15%" class="bg_left">
                        Tên quảng cáo</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="366px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Width</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtWidth" runat="server" CssClass="txt" Width="60px">815</asp:TextBox>
                        px</td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Height</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtHeight" runat="server" CssClass="txt" Width="60px">150</asp:TextBox>
                        px</td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Hình ảnh </td>
                    <td colspan="3" style="width: 85%">
                        <input id="imgAdv" runat="server" name="imgAdv" style="width: 200px; height: 22px;" type="file" class="txt" />
                        <asp:Label ID="lblPic" runat="server" Visible="False"></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                    </td>
                    <td colspan="3" style="width: 85%">
                    <div>
                        <asp:Literal ID="ltImgFlash" runat="server"></asp:Literal></div>
                    <div id="div_img" style="display:<%=Display %>">
                            <img id="imgpic" runat="server" alt="" src="" width="100" style="border:1px solid #dadada" />
                        </div>
                    </td>
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