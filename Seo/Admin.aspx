<%@ Page Language="C#" MasterPageFile="~/admin/admin1.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="seo_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <br />
<div class="settings">
    <h1><%=settings.Help%></h1>    
    
<div id="formContainer" style="padding-left: 50px;" runat="server">    
    
    <table>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_seo_hometitle" runat="server"><b>Home Title:</b></asp:Label>
            </td>
            <td style="height: 36px">
                <asp:TextBox ID="seo_hometitle" runat="server" MaxLength="250"></asp:TextBox>
            </td>            
            <td style="height: 36px">
                
            </td>            
        </tr>    
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="Label1" runat="server"><b>Home Description:</b></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="seo_home_description" runat="server" MaxLength="250"></asp:TextBox>
            </td>
            <td>
                
            </td>                        
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="Label2" runat="server"><b>Home Keywords:</b></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="seo_home_keywords" runat="server" MaxLength="250"></asp:TextBox>
            </td>
            <td>
                 (Comma separated. Example: "asp, asp.net, c#, vb")
            </td>                        
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_post_title_format" runat="server"><b>Post Title Format:</b></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="seo_post_title_format" runat="server" MaxLength="250"></asp:TextBox>
            </td>            
            <td>
                 [BlogTitle] = Blog Title [PostTitle] = Post Title | (Examples: "[BlogTitle] - [PostTitle]" or "Welcome to: [BlogTitle] || Post Title: [PostTitle]")
            </td>                                    
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_page_title_format" runat="server"><b>Page Title Format:</b></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="seo_page_title_format" runat="server" MaxLength="250"></asp:TextBox>
            </td>            
            <td>
                 [BlogTitle] = Blog Title [PageTitle] = Page Title | (Examples: "[BlogTitle] - [PageTitle]" or "Welcome to: [BlogTitle] || Title: [PageTitle]")
            </td>                                    
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_autogenerate_descriptions" runat="server"><b>Autogenerate Descriptions:</b></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="check_autogenerate_descriptions" runat="server" />&nbsp;Length:
                <asp:TextBox ID="seo_char_lemgth" runat="server" MaxLength="250" Width="42px"></asp:TextBox>
            </td>            
            <td>
                
            </td>                                    
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_use_categories_for_meta_keywords" runat="server"><b>Use Categories for META keywords:</b></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="check_use_categories_for_meta_keywords" runat="server" />
            </td>            
            <td>
                
            </td>                                    
        </tr>
        <tr>
            <td style="width: 125px; height: 36px;">
                <asp:Label ID="lbl_use_tags_for_meta_keywords" runat="server"><b>Use Tags for META keywords:</b></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="check_use_tags_for_meta_keywords" runat="server" />
            </td>            
            <td>
                
            </td>                                    
        </tr>                          
    </table>    
        <div style="margin-left:128px">
            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click"/>            
        </div>
</div>
</asp:Content>
