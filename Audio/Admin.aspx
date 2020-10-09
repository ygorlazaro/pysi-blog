<%@ Page Language="C#" MasterPageFile="~/admin/admin1.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="audio_Admin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<br />
<div class="settings">
    <h1>Settings: Mp3 Flash Audio Player</h1>
    <div id="ErrorMsg" runat="server" style="color:Red; display:block;"></div>
    <div id="InfoMsg" runat="server" style="color:Green; display:block;"></div>
    
    <div style="margin-left:127px">
        <asp:Literal ID="litPlayer" runat="server"></asp:Literal>
    </div>
    
    <div id="formContainer" runat="server" class="mgr">
        <div ID="lblBgColor" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Contrlo_background" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label2" runat="server">Control background color</asp:Label>
        <br />
        <div ID="lblBg" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Player_background" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label14" runat="server">Player background color</asp:Label>
        <br />
        <div ID="lblLeftBg" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Left_background" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label15" runat="server">Left background color</asp:Label>
        <br />
        <div ID="lblRightBg" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Right_background" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label1" runat="server">Right background color</asp:Label>
        <br />
        
        <div ID="lblRightBgHvr" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Right_background_hover" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label3" runat="server">Right background (hover)</asp:Label>
        <br />
        <div ID="lblLeftIcon" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Left_icon" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label16" runat="server">Left icon color</asp:Label>
        <br />
        <div ID="lblRightIcon" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Right_icon" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label17" runat="server">Right icon color</asp:Label>
        <br />
        <div ID="lblRightIconHvr" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Right_icon_hover" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label18" runat="server">Right icon color (hover)</asp:Label>
        <br />
        <div ID="lblText" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Text_color" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label19" runat="server">Text color</asp:Label>
        <br />
        <div ID="lblSlider" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Slider" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label20" runat="server">Slider color</asp:Label>
        <br />
        <div ID="lblLoader" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Loader" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label21" runat="server">Loader bar color</asp:Label>
        <br />
        <div ID="lblTrack" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Track" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label22" runat="server">Progress track color</asp:Label>
        <br />
        <div ID="lblBoarder" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Border" runat="server" MaxLength="6"></asp:TextBox>
        <asp:Label ID="Label23" runat="server">Progress track border color</asp:Label>
        <br />
        <div ID="Label4" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Control_width" runat="server" MaxLength="4"></asp:TextBox>
        <asp:Label ID="Label5" runat="server">Control width</asp:Label>
        <br />
        <div ID="Label6" style="width:120px; height:20px; float:left;" runat="server"></div>&nbsp;
        <asp:TextBox ID="Control_height" runat="server" MaxLength="4"></asp:TextBox>
        <asp:Label ID="Label7" runat="server">Control height</asp:Label>
        <br />
            
        <br />
        <div style="margin-left:128px">
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" />
        </div>
    </div>
</div>
</asp:Content>


