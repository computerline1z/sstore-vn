<%@ Import namespace="DataAccessLayer"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="salespolicy.ascx.cs" Inherits="SoftStore.admin.controls.salespolicy" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            chính sách bán hàng</td>
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
                    Tiêu đề</th>
                <th style="width:15%" class="table-sortable:date">
                    Ngày đăng</th>
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
                        <td align="center"><%# Eval("STT")%><asp:Label ID="lblID" Text='<%# Eval("ID") %>' runat="server" Visible="false"></asp:Label></td>
                        <td><a href="default.aspx?n=salespolicy&id=<%# Eval("ID") %>" ><%# Eval("Title")%> </a></td>
                        <td align="center"><%#DateTime.Parse(Eval("CreatedDate").ToString()).ToString("dd/MM/yyyy HH:mm")%></td>
                        <td align="center"><asp:CheckBox ID="cbkIsPublished" runat="server" Checked='<%#Eval("Status") %>' /></td>
                        <td align="center"><input type="checkbox" name="select" id="select" value='<%# Eval("ID")%>' /> </td>
                    </tr>
                </itemtemplate>
            </asp:repeater>
            </tbody>  
        </table>
        <table cellpadding="5" cellspacing="0" style="width: 100%">
        <tr>
            <td align="right">
                <cc1:CollectionPager ID="pagerList" runat="server" BackText="trang trước" FirstText="trang đầu"
                    LabelStyle="" LabelText="Trang:" LastText="trang cuối" NextText="trang kế" PageNumbersStyle="padding:2px"
                    PageNumberStyle="padding:2px" PageSize="30" ResultsFormat="Hiển thị từ {0} đến {1} (trong tổng số {2} tin)"
                    ShowFirstLast="True" MaxPages="100" BackNextLinkSeparator="-">
                </cc1:CollectionPager>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="btnNew" runat="server" BorderWidth="1px" ImageUrl="../styles/addnew.gif" OnClick="btnNew_Click" />
                <asp:ImageButton ID="btnDel" OnClientClick="return confirm('Xác nhận xóa tin đã chọn')" runat="server" BorderWidth="1px" ImageUrl="../styles/del.gif" OnClick="btnDel_Click" />
                <asp:ImageButton OnClientClick="return confirm('Xác nhận publish tin đã chọn')" ID="btnPublished" runat="server" BorderWidth="1px" ImageUrl="../styles/published.gif" OnClick="btnPublished_Click" />
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
                        Tiêu đề</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="txt" Width="500px" Height="30px" TextMode="MultiLine"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="Nhập tiêu đề tin tức"></asp:RequiredFieldValidator></span></td>
                </tr>
               
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Publish</td>
                    <td colspan="3" style="width: 85%">
                    <asp:RadioButton ID="rdbYes" runat="server" GroupName="publish" Text="Có" />&nbsp;<asp:RadioButton
                            ID="rdbNo" runat="server" Checked="True" GroupName="publish" Text="Không" />
                        </td>
                </tr>
                <tr>
                    <td colspan="4" class="bg_title">
                        <strong>Nội dung chi tiết</strong></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <CKEditor:CKEditorControl ID="txtContent" runat="server" Height="500px"></CKEditor:CKEditorControl>
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
