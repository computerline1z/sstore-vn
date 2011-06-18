<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="onl_statistics.ascx.cs" Inherits="SoftStore.controls.onl_statistics" %>
<div style="border:solid 1px #dadada">
    <div class="titleleft">
        THỐNG KÊ TRUY CẬP</div>
    <div style="padding:5px;background-color: #fff;">
    <table cellpadding="4">
        <tr>
            <!--
            <td> Begin Users Online 
                <!-- URL: http://www.twospots.com/free-users-online-counter/ 
                <table width="76" border="0" cellspacing="0" cellpadding="0" style="padding:0px">
                <tr>
                <td width="39"><a href="http://www.twospots.com/free-users-online-counter/" target="_blank"><img src="http://www.tscounter.com/images/users-online/users-online6.gif" width="39" height="21" border="0"  alt="Users Online"/></a></td>
                <td width="37"><script type="text/javascript">//<![CDATA[
                                   document.write('<a href="http://www.twospots.com/free-users-online-counter/" target="_blank"><img src="http://www.tscounter.com/uow3c/?id=OXZUZQphK5H0CZjbGU6Ueg%3D%3D" width="37" height="21" border="0" alt="Users Online" title="Users Online"/></a>');//]]>
                </script><noscript>
                <a href="http://www.accomodationcalifornia.com/blog/" style="style: none;" title="Accomodation California"><img alt="Accomodation California" src="http://www.tscounter.com/uow3c/?id=OXZUZQphK5H0CZjbGU6Ueg%3D%3D" width="37" height="21" border="0"/></a></noscript></td>
                </tr>
                </table>
                <!-- End Users Online 
            </td>-->
            <td>Đang online: <asp:Label ID="lblNow" runat="server"></asp:Label></td>
        </tr>
        <tr>    
            <td>Tổng số lượt: 
                    <asp:Label ID="lblTotal" runat="server"></asp:Label></td>
        </tr>
    </table>
    </div>
</div>