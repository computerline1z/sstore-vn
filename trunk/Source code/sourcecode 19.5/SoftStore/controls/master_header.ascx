<%@ Control Language="C#" AutoEventWireup="true" Codebehind="master_header.ascx.cs"
    Inherits="SoftStore.controls.master_header" %>

<div id="divPanel" style="display:none;"></div>
<!--Verify again-->
<div id="header">
    <a href="/" title="Trang chủ - sstore.vn">
          <span id="logo"></span>
    </a>
   <div id="header-top">
        <ul id="header-right">
            <li id="call">
                <span><font color="#ffc600">08&nbsp;625&nbsp;79208</font>
                </span>
            </li>
                <li>
                <a href='ymsgr:sendim?dinhkhanh01' title="Hỗ trợ mua hàng 1">
                    <span class="yahoo"></span>
                </a>
            </li>
                <li>
                <a href='ymsgr:sendim?dinhkhanh01' title="Hỗ trợ mua hàng 2">
                    <span class="yahoo"></span>
                </a>
            </li>
            <li>
                <a href='ymsgr:sendim?dinhkhanh01' title="Hỗ trợ mua hàng 3">
                    <span class="yahoo"></span>
                </a>
            </li>
            <li>
                <a href="skype:dinhkhanhinfo?chat" title="Hỗ trợ mua hàng">
                    <span class="skype"></span>
                </a>
            </li>
            <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
            <asp:Literal ID="ltLoginPanel" runat="server"></asp:Literal>
            <li class="text">
                <a href="/giup-do.html" title="Giúp đỡ">Giúp đỡ</a>
            </li>
            <li class="text" style="border:none;">
                <a href="/lien-he.html">Liên hệ</a>
            </li>
            </ul>
            <!-- end #header-right -->
    </div>
    <!-- end #header-top -->
    <div id="header-bottom">
        <div id="search-form">
            <asp:TextBox ID="txtKey" CssClass="search-input" runat="server" value="Tìm là thấy...!" onfocus="if(this.value == 'Tìm là thấy...!') this.value='';"
                            onblur="if(this.value == '') this.value='Tìm là thấy...!';"></asp:TextBox>
            <input type="submit" value="Tìm kiếm" id="search-button" onclick="return check()" title="Tìm kiếm" />
        </div>
        <div id="nav">
            <ul id="jsddm">
                <asp:Literal ID="ltMenu" runat="server"></asp:Literal>                       
            </ul>
        </div>
    </div>
    <!-- end #header-bottom -->
    <script type="text/javascript">
        function check(){
            var key=document.getElementById('<%=txtKey.ClientID %>');
            if (key.value == 'Tìm là thấy...!' || key.value == '')
            {
                alert("Vui lòng nhập từ khóa tìm kiếm");
                return false;
            }
            else
            {
                var url = '/tag/' + key.value.replace(/ /gi, '+') + '.html';
                window.location.href = url;
                return true;
            }
        }
    </script>
        <!--<div class="carts">
        <a href="/gio-hang.html" title="Xem giỏ hàng"><asp:Literal ID="ltCart" runat="server"></asp:Literal></a>
    </div>-->
</div>
    <!--end #header-->