<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="brands.ascx.cs" Inherits="SoftStore.admin.controls.brands" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="Pyco.Web" Namespace="Pyco.Web.UI.WebControls" TagPrefix="cc2" %>
<script type="text/javascript" language="javascript">
 
    function imgUpload(values)
    {
  	    var item = document.getElementById('div_img');
  	    if(item)
  	    {	 
  	        var img = document.getElementById('ctl00_ContentPlaceHolder1_ctl00_imgpic');	   	     
  	        img.src=values;
  	        item.style.display='inline';  
  	    } 
    }
</script>
<table cellpadding="3" cellspacing="0" style="width: 100%">
    <tr>
        <td class="title" style="width: 100%">
            Danh sách logo đối tác
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
                <th style="width:35%" class="table-sortable:default">
                    Logo</th>
                <th style="width:30%" class="table-sortable:default">
                    Url</th>
                <th style="width:10%" class="table-sortable:numeric">
                    Thứ tự</th>
                <th style="width:5%">
                    Chọn</th>
            </tr> 
            </thead>
            <tbody>
            <asp:repeater id="rptList" runat="Server" >
                <itemtemplate>
                    <tr>
                        <td align="center"><%# Eval("ID") %> </td>
                        <td><a href="default.aspx?n=brands&id=<%# Eval("ID") %>" ><%# Eval("Name")%> </a></td>
                        <td align="center"><%# Eval("Url")%> </td>
                        <td align="center"><%# Eval("SortOrder") %> </td>
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
                    <td style="width: 15%" class="bg_left">
                        Tên logo</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="366px"></asp:TextBox><span style="color: #ff0033">*
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="?"></asp:RequiredFieldValidator></span></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Link - http://</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtUrl" runat="server" CssClass="txt" Width="366px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Thứ tự hiển thị</td>
                    <td colspan="3" style="width: 85%">
                        <asp:TextBox ID="txtIndex" runat="server" CssClass="txt" Width="60px">1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="?"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtIndex"
                            ErrorMessage="Thứ tự >=1" MaximumValue="9999999" MinimumValue="1" Type="Integer"></asp:RangeValidator></td>
                </tr>
                
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Ghi chú</td>
                    <td colspan="3" style="width: 85%;">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" Height="100px" TextMode="MultiLine"
                            Width="500px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="bg_left" style="width: 15%">
                        Hình ảnh (100 x 75 px)</td>
                    <td colspan="3" style="width: 85%">
                        <input id="imgAdv" runat="server" name="imgAdv" onchange="imgUpload(this.value);" style="width: 200px; height: 22px;" type="file" class="txt" />
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