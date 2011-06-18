<%@ Control Language="C#" AutoEventWireup="true" Codebehind="master_left_group.ascx.cs"
    Inherits="SoftStore.controls.master_left_group" %>
<%@ Register Src="master_supportonline.ascx" TagName="master_supportonline" TagPrefix="uc2" %>
<%@ Register Src="onl_statistics.ascx" TagName="onl_statistics" TagPrefix="uc1" %>
<div id="sidebar-bgbtm">
    <ul>
        <asp:Literal ID="ltMenuLeft" runat="server"></asp:Literal>
    </ul>
    <div style="border:solid 1px #dadada">
    <div class="titleleft">
        LỢI ÍCH CỦA BẠN TẠI SSTORE</div>
    <div style="background-color: #fff;">
    <img alt="LỢI ÍCH CỦA BẠN TẠI SSTORE" src="/images/customer-care.jpg" width="218px" />
    </div>
</div>
<div style="height:10px;"></div>
    <div>
    <uc2:master_supportonline id="Master_supportonline1" runat="server"></uc2:master_supportonline>
    </div>
    <div style="height:10px;"></div>
    <div>
    <uc1:onl_statistics ID="Onl_statistics1" runat="server" />
    </div>
    <div style="height:10px;"></div>
</div>
