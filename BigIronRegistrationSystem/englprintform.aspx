<%@ Page Language="C#" AutoEventWireup="true" CodeFile="englprintform.aspx.cs" Inherits="englprintform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>


</head>
<body style="text-align: left; font-size: 12pt;">

<script type="text/javascript">
<!--
window.print();

//-->
</script>    
    
    <form id="form1" runat="server">
    
    <div style="text-align: center"><center>
        <asp:Image ID="Image1" runat="server" Height="86px" ImageUrl="~/images/bigiron.JPG" Width="411px" /><br />
        <span style="font-size: 12pt">
        <strong>Big Iron International Visitors Program Registration Form</strong><br />
        </span>
        <table style="font-size: 10pt">
            <tr>
                <td style="width: 64px; text-align: left">
                    First Name:</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    Last Name:</td>
                <td style="border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblLastName" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Job Title:</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblJobTitle" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    Company:</td>
                <td style="border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblCompany" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Address:</td>
                <td colspan="3" style="border-bottom: black 1px solid; text-align: left; margin-bottom: 1px; padding-bottom: 1px;">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    City:</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblCity" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    State/Province:</td>
                <td style="width: 288px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblState" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Country:</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblCountry" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    Postal Code:</td>
                <td style="width: 288px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Email:</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    Website:</td>
                <td style="width: 288px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblWebSite" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Phone</td>
                <td style="width: 302px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblPhone" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 79px; text-align: left">
                    Fax:</td>
                <td style="width: 288px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblFax" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
        </table>
                  
                        <table style="font-size: 10pt; width: 747px;">
                            <tr>
                                <td style="text-align: left">
                                    <strong><span style="font-size: 12pt">Product Interest:<br />
                                    </span></strong>Please mark the products you are most interested in seeing at the show:</td>
                            </tr>
                            <tr style="font-size: 10pt">
                                <td style="height: 50px; text-align: left;  border-bottom: black 1px solid; width: 747px;">
                                    <asp:CheckBoxList ID="cblProductInterest" runat="server" EnableTheming="True" Font-Size="10pt"
                                        ForeColor="Black" RepeatColumns="3" ValidationGroup="0" Width="746px">
                                        <asp:ListItem Value="1">Tractors</asp:ListItem>
                                        <asp:ListItem Value="2">Seeders/Planters</asp:ListItem>
                                        <asp:ListItem Value="3">Trucks/Trailers</asp:ListItem>
                                        <asp:ListItem Value="4">Seeds/Chemicals/Fertilizers/Pesticides</asp:ListItem>
                                        <asp:ListItem Value="5">Combines/Harvesters</asp:ListItem>
                                        <asp:ListItem Value="6">Haying Equipment</asp:ListItem>
                                        <asp:ListItem Value="7">Sprayers/Fertilizer Applicators</asp:ListItem>
                                        <asp:ListItem Value="8">Material Handling</asp:ListItem>
                                        <asp:ListItem Value="9">Grain Handling (augers, conveyors, bins, Dryers)</asp:ListItem>
                                        <asp:ListItem Value="10">Tillage Equipment</asp:ListItem>
                                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherProductInterest" runat="server" Text="Other:" />&nbsp;
                                    <asp:Label ID="lblOtherProductInterest" runat="server" Font-Underline="False"></asp:Label></td>
                           
                            </tr>
                        </table>
                    
        <table style="font-size: 10pt">
            <tr>
                <td style="width: 747px; text-align: left">
                    <strong><span style="font-size: 12pt">Visitor Status:<br />
                    </span>
                    </strong>Please check the box that best describes your operation:</td>
            </tr>
            <tr>
                <td style="width: 747px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblVisitorStatus" runat="server" RepeatColumns="3" Font-Size="10pt">
                        <asp:ListItem Value="1">Distributor/Wholesaler</asp:ListItem>
                        <asp:ListItem Value="2">Manufacturer Representative/Sale Agent</asp:ListItem>
                        <asp:ListItem Value="3">State Farm</asp:ListItem>
                        <asp:ListItem Value="4">Equipment Dealer</asp:ListItem>
                        <asp:ListItem Value="5">Manufacturer</asp:ListItem>
                        <asp:ListItem Value="6">Import/Export Organization</asp:ListItem>
                        <asp:ListItem Value="7">Corporate Farm</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherVisitorStatus" runat="server" Text="Other:" />&nbsp;
                    <asp:Label ID="lblOtherVisitorStatus" runat="server" Font-Underline="False" Font-Italic="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt">
            <tr>
                <td style="width: 747px; text-align: left">
                    <span style="font-size: 12pt">
                    <strong>Purpose of Visit:</strong><br />
                    </span>
                    Please check the box that indicates the purpose of you visit to the Big Iron IVP:</td>
            </tr>
            <tr>
                <td style="width: 747px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblPurposeVisit" runat="server" RepeatColumns="2" Font-Size="10pt">
                        <asp:ListItem Value="1">Purchase/ Place Orders</asp:ListItem>
                        <asp:ListItem Value="2">Gather Information</asp:ListItem>
                        <asp:ListItem Value="3">Evaluate show for future participation</asp:ListItem>
                        <asp:ListItem Value="4">Source new equipment suppliers/new products</asp:ListItem>
                        <asp:ListItem Value="5">Visit existing suppliers and business associates</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherPurposeVisit" runat="server" Text="Other:" />&nbsp;
                    <asp:Label ID="lblOtherPurposeVisit" runat="server" Font-Underline="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt">
            <tr>
                <td style="width: 749px; text-align: left">
                    <span style="font-size: 12pt">
                    <strong>Crop Interest:</strong><br />
                    </span>
                    Please indicate the major crops you or your clients produce:</td>
            </tr>
            <tr>
                <td style="width: 749px; text-align: left">
                    <asp:CheckBoxList ID="cblCropInterest" runat="server" RepeatColumns="5" Font-Size="10pt">
                        <asp:ListItem Value="1">Barley</asp:ListItem>
                        <asp:ListItem Value="2">Potatoes</asp:ListItem>
                        <asp:ListItem Value="3">Sugar Beets</asp:ListItem>
                        <asp:ListItem Value="4">Canola/Rapeseed</asp:ListItem>
                        <asp:ListItem Value="5">Soybeans</asp:ListItem>
                        <asp:ListItem Value="6">Winter Wheat</asp:ListItem>
                        <asp:ListItem Value="7">Corn</asp:ListItem>
                        <asp:ListItem Value="8">Spring Wheat</asp:ListItem>
                        <asp:ListItem Value="9">Oats</asp:ListItem>
                        <asp:ListItem Value="10">Sunflowers</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherCropInterest" runat="server" Text="Other:" />&nbsp;
                    <asp:Label ID="lblOtherCropInterest" runat="server" Font-Underline="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt">
            <tr>
                <td style="width: 161px; height: 24px; text-align: left">
                    Will you need an interpreter?</td>
                <td style="width: 584px; height: 24px; text-align: left">
                    <asp:RadioButtonList ID="rblInterpreter" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
            <td>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                If yes, what language?</td>
            <td style="border-bottom: black 1px solid; text-align:left;">
                    <asp:Label ID="lblLanguage" runat="server" Font-Underline="False"></asp:Label><span style="font-size: 1pt">.</span></td>
            
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;&nbsp;<br />
                    If you have questions please contact with the North Dakota Trade Office<br />
                    Phone: 701-235-3638<br />
                    Fax: &nbsp; &nbsp; &nbsp;701-235-0164<br />
                    112 University Dr. N. Ste. 260<br />
                    Fargo, ND 58102</td>
            </tr>
        </table>
        <asp:Image ID="Image2" runat="server" Height="43px" ImageUrl="~/images/logotradeoffice.JPG"
            Width="358px" /></center> </div>
    </form>
</body>
</html>
