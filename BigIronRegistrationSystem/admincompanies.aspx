<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="admincompanies.aspx.cs" Inherits="admincompanies" Title="Products of companies" %>
<%@ MasterType VirtualPath="~/Admin.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center><span style="font-weight:bold;font-size:larger;">The products of export companies</span></center>
    
<br />
    &nbsp;
    <table>
    <tr>
    <td>
    <asp:DropDownList ID="ddExporter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddExporter_SelectedIndexChanged">
	</asp:DropDownList>&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    </td>
    <td>
    <asp:Button ID="btnSaveData" runat="server" Text="Save data" OnClick="btnSaveData_Click" />&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    </td>
    <td>
    <a href="adminbiregistration.aspx" style="font-size: 11pt">Return to Big Iron Registration</a></td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
    </td>
    <td>
    <asp:Literal ID="LinkToReportPlaceHolder" runat="server"></asp:Literal></td>
    </tr>
    </table>
    &nbsp;<span style="font-size: 10pt">Location of the company on Big Iron Exhibition:<br />
        <br />
    </span> &nbsp;
    <asp:TextBox ID="txtLocation" runat="server" Height="42px" TextMode="MultiLine" Width="724px"></asp:TextBox><br />
    <br />
    <asp:Literal ID="ProductsPlaceHolder" runat="server"></asp:Literal><br />
    <br />
        <asp:CheckBoxList ID="cblProducts" runat="server" Font-Size="Larger">
    </asp:CheckBoxList><br />
    
</asp:Content>

