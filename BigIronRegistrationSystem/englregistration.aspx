<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="englregistration.aspx.cs" Inherits="Default2" Title="Big Iron Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" Runat="Server">
    <span style="font-size: 10pt">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/rusregistration.aspx">Rus</asp:HyperLink>
        | Engl</span><br />
    <br />
    <strong><span style="font-size: 11pt">
    Big Iron International Visitors Program Registration Form</span><br />
    </strong><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
    <span><span style="font-size: 10pt"><span>First Name:</span> </span>
        <asp:TextBox ID="txtFirstName" runat="server" Width="173px" MaxLength="89"></asp:TextBox><span style="font-size: 10pt">
        <span>Last Name:</span></span><asp:TextBox ID="txtLastName" runat="server" Width="225px"></asp:TextBox>&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
            ErrorMessage="please, eneter first name"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
            ErrorMessage="please, enter last name"></asp:RequiredFieldValidator><br />
    </span><span style="font-size: 10pt">
    Job Title: &nbsp;</span><asp:TextBox ID="txtJobTitle" runat="server" Width="187px"></asp:TextBox><span
        style="font-size: 10pt">&nbsp;
    Company:&nbsp; </span>
    <asp:TextBox ID="txtCompany" runat="server" Width="221px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtJobTitle"
            ErrorMessage="please, enter job title"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCompany"
            ErrorMessage="please, enter company name"></asp:RequiredFieldValidator><br />
    Address:&nbsp; </span>
    <asp:TextBox ID="txtAddress" runat="server" Width="485px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAddress"
            ErrorMessage="please, enter address"></asp:RequiredFieldValidator><br />
    City:&nbsp; </span>
    <asp:TextBox ID="txtCity" runat="server" Width="187px"></asp:TextBox><span style="font-size: 10pt">&nbsp; State/Province:&nbsp; </span>
    <asp:TextBox ID="txtState" runat="server" Width="216px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity"
            ErrorMessage="please, enter city"></asp:RequiredFieldValidator><br />
    Country:&nbsp; </span>
    <asp:TextBox ID="txtCountry" runat="server" Width="238px"></asp:TextBox><span style="font-size: 10pt">&nbsp; Postal Code:&nbsp; </span>
    <asp:TextBox ID="txtPostalCode" runat="server" Width="155px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry"
            ErrorMessage="please, enter country"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPostalCode"
            ErrorMessage="please, enter postal code"></asp:RequiredFieldValidator><br />
    Email:&nbsp; </span>
    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox><span style="font-size: 10pt">&nbsp; Website:&nbsp; </span>
    <asp:TextBox ID="txtWebSite" runat="server" Width="228px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="please, enter email"></asp:RequiredFieldValidator>&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="incorrect Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
    Phone: &nbsp;</span><asp:TextBox ID="txtPhone" runat="server" Width="194px"></asp:TextBox><span
        style="font-size: 10pt">&nbsp; Fax:&nbsp; </span>
    <asp:TextBox ID="txtFax" runat="server" Width="254px"></asp:TextBox><br />
    &nbsp;&nbsp; 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone"
        ErrorMessage="please, enter phone number"></asp:RequiredFieldValidator>&nbsp;
    <br />
    <strong>Product Interest:</strong><br />
    Please mark the products you are most interested in seeing at the show:<br />
    <asp:CheckBoxList ID="cblProductInterest" runat="server" RepeatColumns="2" ValidationGroup="0">
        <asp:ListItem Value="1">Tractors</asp:ListItem>
        <asp:ListItem Value="2">Seeders/Planters</asp:ListItem>
        <asp:ListItem Value="3">Trucks/Trailers</asp:ListItem>
        <asp:ListItem Value="4">Seeds/Chemicals/Fertilizers/Pesticides</asp:ListItem>
        <asp:ListItem Value="5">Combines/Harvesters</asp:ListItem>
        <asp:ListItem Value="6">Haying Equipment</asp:ListItem>
        <asp:ListItem Value="7">Sprayers/Fertilizer Applicators</asp:ListItem>
        <asp:ListItem Value="8">Material Handling</asp:ListItem>
        <asp:ListItem Value="9">Grain Handling (augers, conveyors, bins, dryers)</asp:ListItem>
        <asp:ListItem Value="10">Tillage Equipment</asp:ListItem>
    </asp:CheckBoxList><span style="font-size: 10pt"> &nbsp;&nbsp;Other:</span><span style="font-size: 10pt">
            &nbsp; &nbsp; </span>
    <asp:TextBox ID="txtProdInterest" runat="server" Width="445px"></asp:TextBox><span
        style="font-size: 10pt">
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <br />
    <strong>Visitor Status:</strong><br />
    Please check the box that best describes your operation<br />
    </span>
    <asp:CheckBoxList ID="cblVisitorStatus" runat="server" RepeatColumns="2">
        <asp:ListItem Value="1">Distributor/Wholesaler</asp:ListItem>
        <asp:ListItem Value="2">Manufacturer Representative/Sale Agent</asp:ListItem>
        <asp:ListItem Value="3">State Farm</asp:ListItem>
        <asp:ListItem Value="4">Equipment Dealer</asp:ListItem>
        <asp:ListItem Value="5">Manufacturer</asp:ListItem>
        <asp:ListItem Value="6">Import/Export Organization</asp:ListItem>
        <asp:ListItem Value="7">Corporate Farm</asp:ListItem>
    </asp:CheckBoxList><span style="font-size: 10pt">&nbsp; Other:&nbsp;</span><span style="font-size: 10pt"> </span>
    <asp:TextBox ID="txtVisitorStatus" runat="server" Width="230px"></asp:TextBox><br />
    <br />
    <span style="font-size: 10pt">
    <strong>Purpose of Visit:</strong><br />
    Please check the box that indicates the purpose of you visit to the Big Iron IVP:<br />
    </span>
    <asp:CheckBoxList ID="cblPurposeVisit" runat="server" RepeatColumns="2">
        <asp:ListItem Value="1">Purchase/Place Orders</asp:ListItem>
        <asp:ListItem Value="2">Gather Information</asp:ListItem>
        <asp:ListItem Value="3">Evaluate show for future participation</asp:ListItem>
        <asp:ListItem Value="4">Source new equipment suppliers/new products</asp:ListItem>
        <asp:ListItem Value="5">Visit exisiting suppliers and business associates</asp:ListItem>
    </asp:CheckBoxList><span style="font-size: 10pt"> &nbsp;&nbsp;Other:</span><span style="font-size: 10pt"> &nbsp; </span>
    <asp:TextBox ID="txtPurposeVisit" runat="server" Width="230px"></asp:TextBox><br />
    <br />
    <span style="font-size: 10pt">
    <strong>Crop Interest:</strong><br />
    Please indicate the major crops you or your clients produce:<br />
    </span>
    <asp:CheckBoxList ID="cblCropInterest" runat="server" RepeatColumns="5">
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
    </asp:CheckBoxList><span style="font-size: 10pt"> &nbsp;&nbsp;Other:</span><span style="font-size: 10pt"> &nbsp; </span>
    <asp:TextBox ID="txtCropInterest" runat="server" Width="236px"></asp:TextBox><br />
    <br />
    <span style="font-size: 10pt">
     Will you need an interpreter? 
        <asp:RadioButtonList ID="rblInterpreter" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
            <asp:ListItem Value="0">No</asp:ListItem>
        </asp:RadioButtonList></span><span style="font-size: 10pt">If &nbsp;yes, what language?&nbsp; &nbsp;</span><asp:TextBox
        ID="txtLanguage" runat="server" Width="272px"></asp:TextBox><br />
    <br />
    <span style="font-size: 10pt">Please submit your registration.<br />
    </span>
    <br />
    &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; <input id="Button1" type="button"
        value="Print the blank form"  onclick="window.open('englprintform.aspx?id=blank', '_blank');" /><br />
    <br />
    &nbsp;
    <asp:Literal ID="btnLiteral" runat="server"></asp:Literal><br />
    <br />
    <br />
    
</asp:Content>

