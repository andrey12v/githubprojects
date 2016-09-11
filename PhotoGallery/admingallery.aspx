<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="admingallery.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/Admin.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span style="font-weight:bold;font-size:larger;">Admin Gallery</span>
	<br />
    <span style="color:Red; font-size: 20px;"><asp:Literal ID="Feedback" runat="server"></asp:Literal></span>
	<br />
	
	<table valign="center" style="font-size: 12px;">
	<tr>
	<td>
	Gallery
	</td>
	<td>&nbsp;&nbsp;<asp:DropDownList ID="ddGallery" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddGallery_SelectedIndexChanged" ></asp:DropDownList></td>
	<td>&nbsp;&nbsp;Title
	</td>
	<td>&nbsp;&nbsp;<asp:TextBox ID="txtGallery" runat="server" Width="400px"></asp:TextBox> 
	</td>
	</tr>
    <tr>
	   <td colspan="2"><br/>
			<asp:Button ID="btnAddGallery" runat="server" Text="Add" 
                OnClick="btnAddGallery_Click" />&nbsp; &nbsp;
			<asp:Button ID="btnUpdateGallery" runat="server" Text="Update" 
                OnClick="btnUpdateGallery_Click" />&nbsp; &nbsp;
			<asp:Button ID="btnDelete1" runat="server" Text="Delete" 
                OnClick="btnDeleteGallery_Click" />
		</td>			
	</tr>
	</table>
	
	<br />	
    
    <table style="font-size: 12px">
    <tr>
    <td>Picture</td>
    <td>&nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="ddPictures" runat="server" OnSelectedIndexChanged="ddPictures_SelectedIndexChanged" AutoPostBack="True"> 
        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbFrontImage" 
            runat="server" Text="Front Image" />
                                    </td>
    </tr>
   		<tr>
			<td>Title Of Image</td>
			<td>
                &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txtPicture" runat="server" Width="569px"></asp:TextBox></td>
		</tr>
	    <tr>
	    <td>Description of image
	    </td>
	    <td>&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="txtDescription" runat="server" Height="94px" TextMode="MultiLine" Width="565px"></asp:TextBox></td>
	    </tr>
	    <tr>
            <td>One Image Upload</td>
            <td>
               &nbsp; &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" />&nbsp; &nbsp;
                <asp:Button ID="btnAddImage" runat="server" Text="Add Image" 
                    OnClick="btnAddImage_Click" />&nbsp; &nbsp;
				<asp:Button ID="btnUpdateImage" runat="server" Text="Update" 
                    OnClick="btnUpdateImage_Click" />&nbsp; &nbsp;
                <asp:Button ID="btnDeleteImage" runat="server" Text="Delete Image" 
                    OnClick="btnDeleteImage_Click"/>
             </td>
        </tr>
	   </table>

	   <br /><br />
	   <asp:Literal ID="PicturesPlaceholder" runat="server"></asp:Literal>
    <br />
    <br />
    <div style="vertical-align:middle">
    </div>
</asp:Content>

