<%@ Control Language="C#" AutoEventWireup="true" Codebehind="master_header.ascx.cs"
    Inherits="SoftStore.controls.master_header" %>

<div id="divPanel" style="display:none;"></div>
<div id="header">
    <div id="logo">
    </div>
    <div id="header-right">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td id="topbar">
                    <asp:Literal ID="ltLoginPanel" runat="server"></asp:Literal> <a href="/giup-do.html">
                        Giúp đỡ</a> <a href="/lien-he.html">Liên hệ</a>
                </td>
                <td id="search">
                <div style="float: left">
                        <asp:TextBox ID="txtKey" runat="server" value="Từ khóa tìm kiếm" onfocus="if(this.value == 'Từ khóa tìm kiếm') this.value='';"
                                        onblur="if(this.value == '') this.value='Từ khóa tìm kiếm';"></asp:TextBox>
                    </div>
                    <div>
                        <input type="button" id="search-button" onclick="return check()" title="Tìm kiếm" />
                    </div>
                    <script type="text/javascript">
                                function check(){
                                    var key=document.getElementById('<%=txtKey.ClientID %>');
                                    if(key.value=='Từ khóa tìm kiếm' || key.value=='')
                                    {
                                        alert("Vui lòng nhập từ khóa tìm kiếm");
                                        return false;
                                    }
                                    else
                                    {
                                        var url='/tag/' + key.value.replace(/ /gi,'+') + '.html';
                                        window.location.href = url;
                                        return true;
                                    }
                                }
                                
                                </script>
                </td>
                <td>
                    <div class="carts">
                        <a href="/gio-hang.html" title="Xem giỏ hàng"><asp:Literal ID="ltCart" runat="server"></asp:Literal></a>
                    </div>
                </td>
            </tr>
        </table>
        <!-- end #header-right -->
    </div>
</div>
<!-- end #logo -->
<div id="menu">
                        <ul id="jsddm">
                            
                            <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
							
                            
                            
                            
                        </ul>
                    </div>
<!-- end #menu -->
