<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="adminbiregistration.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/Admin.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="MsoNormal" style="margin: 0in 0in 0pt; text-align: center">
        <span style="font-size: 12pt"><strong>Registered clients on the International
                Visitors Program</strong></span></p>
        <br /> 
        <span style="font-size: 10pt">&nbsp;<asp:Literal ID="linkPlaceHolder" runat="server"></asp:Literal>&nbsp;<br />
            &nbsp;<a href="admincompanies.aspx">Choose products of companies in check box list</a><br />
        </span>
        <br />
            <table>
            <tr>
            <td>
            <span style="font-size: 10pt"><b>&nbsp;Choose view of the report</b></span>
            </td>
            <td>
            <span style="font-size: 10pt"><b>&nbsp;Choose the language</b></span>
            </td>
            </tr>
            <tr>
            <td>
            <asp:RadioButtonList ID="rblReportView" runat="server" Font-Size="10pt" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">Company =&gt; Products</asp:ListItem>
                <asp:ListItem Value="1">Product =&gt; Companies</asp:ListItem>
            </asp:RadioButtonList>
            </td>
            <td>
            <asp:RadioButtonList ID="rblLanguage" runat="server" Font-Size="10pt" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">English & Russian</asp:ListItem>
                <asp:ListItem Value="1">Only English</asp:ListItem>
            </asp:RadioButtonList>
            
            
            </td>
            </tr>
          </table>  
              
        <center>
        
        <asp:Literal ID="VisitorsPlaceholder" runat="server"></asp:Literal>
                
        </center>
        <br />
        
        
        <br />


        
        
            
</asp:Content>



