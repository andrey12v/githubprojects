<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
   <head id="Head1" runat="server">
      <title>Guestbook</title>
   </head>
   <body>
      <form id="form1" runat="server">
         <div>
            <h2><span style="color: navy">
               Please leave a message in our guestbook:</span></h2>

            <table>
               <tr>
                  <td style="width: 130px; height: 21px;" valign="top">
                     Your name:<br />
                  </td>
                  <td style="width: 300px; height: 21px;" valign="top">
                     <asp:TextBox ID="nameTextBox" runat="server"
                         Width="300px"></asp:TextBox>
                  </td>
               <td> <asp:RequiredFieldValidator ID="nameInputValidator" 
                        runat="server" ControlToValidate="nameTextBox"
                        ErrorMessage="Please enter your name." 
                        Display="Dynamic"></asp:RequiredFieldValidator>
               </td>
               </tr>
               <tr>
                  <td style="width: 130px; height: 40px;" valign="top">
                     Your e-mail address:<br />
                  </td>
                  <td style="width: 300px; height: 40px;" valign="top">
                     <asp:TextBox ID="emailTextBox" runat="server"
                        Width="300px"></asp:TextBox></td>
               <td style="height: 40px"><asp:RequiredFieldValidator ID="emailInputValidator" 
                        runat="server" ControlToValidate="emailTextBox"
                        ErrorMessage="Please enter your e-mail address." 
                        Display="Dynamic"></asp:RequiredFieldValidator><br />
               
               <asp:RegularExpressionValidator 
                        ID="emailFormatValidator" runat="server" 
                        ControlToValidate="emailTextBox" 
                        ErrorMessage="Please enter an e-mail address in a 
                        valid format." Display="Dynamic" 
                        ValidationExpression=
                        "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                     </asp:RegularExpressionValidator>
               </td>
               </tr>
               <tr>
                  <td style="width: 130px;" valign="top">
                     Tell the world:<br />
                  </td>
                  <td style="width: 300px;" valign="top">
                     <asp:TextBox ID="messageTextBox" runat="server"
                        Height="100px" Rows="8" Width="300px">
                     </asp:TextBox>
                  </td>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="messageTextBox"
                       ErrorMessage="Please enter the text"></asp:RequiredFieldValidator></td>
               </tr>
               <tr>
                  <td style="width: 130px;" valign="top">
                  </td>
                  <td style="width: 300px;" valign="top">
                     <asp:Button ID="submitButton" runat="server"
                        Text="Submit" OnClick="submitButton_Click" />
                     <asp:Button ID="clearButton" runat="server"
                        Text="Clear" OnClick="clearButton_Click" />
                  </td>
               </tr>
            </table>
            <br />
            
            <asp:GridView ID="messagesGridView" runat="server" 
               AutoGenerateColumns="False" CellPadding="4"
               ForeColor="#333333" GridLines="None"
               DataSourceID="messagesSQLDataSource" Width="600px"
               DataKeyNames="MessageID">
               <FooterStyle BackColor="#1C5E55" Font-Bold="True" 
                  ForeColor="White" />
               <RowStyle BackColor="#E3EAEB" />
               <PagerStyle BackColor="#666666" ForeColor="White" 
                  HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" 
                  ForeColor="#333333" />
               <HeaderStyle BackColor="#1C5E55" Font-Bold="True" 
                  ForeColor="White" />
               <EditRowStyle BackColor="#7C6F57" />
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                  <asp:BoundField DataField="Date" HeaderText="Date" 
                     SortExpression="Date" />
                  <asp:BoundField DataField="Name" HeaderText="Name" 
                     SortExpression="Name" />
                  <asp:BoundField DataField="Email" HeaderText="Email" 
                     SortExpression="Email" />
                  <asp:BoundField DataField="Message" HeaderText="Message" 
                     SortExpression="Message" />
               </Columns>
            </asp:GridView>
            
            <asp:SqlDataSource ID="messagesSQLDataSource" runat="server" 
               ConnectionString=
                  "<%$ ConnectionStrings:GuestbookConnectionString %>"
               SelectCommand="SELECT * FROM [Messages]" 
               DeleteCommand="DELETE FROM [Messages] WHERE 
                  [MessageID] = @original_MessageID"
               InsertCommand="INSERT INTO [Messages] 
                  ([Date], [Name], [Email], [Message]) VALUES 
                  (@Date, @Name, @Email, @Message)"
               UpdateCommand="UPDATE [Messages] SET [Date] = @Date, 
                  [Name] = @Name, [Email] = @Email, [Message] = @Message 
                  WHERE [MessageID] = @original_MessageID">
               <DeleteParameters>
                  <asp:Parameter Name="original_MessageID" Type="Int32" />
               </DeleteParameters>
               <UpdateParameters>
                  <asp:Parameter Name="Date" Type="String" />
                  <asp:Parameter Name="Name" Type="String" />
                  <asp:Parameter Name="Email" Type="String" />
                  <asp:Parameter Name="Message" Type="String" />
                  <asp:Parameter Name="original_MessageID" Type="Int32" />
               </UpdateParameters>
               <InsertParameters>
                  <asp:Parameter Name="Date" Type="String" />
                  <asp:ControlParameter ControlID="nameTextBox" 
                     Name="Name" PropertyName="Text" Type="String" />
                  <asp:ControlParameter ControlID="emailTextBox" 
                     Name="Email" PropertyName="Text" Type="String" />
                  <asp:ControlParameter ControlID="messageTextBox" 
                     Name="Message" PropertyName="Text" Type="String" />
               </InsertParameters>
            </asp:SqlDataSource>
         </div>
      </form>
   </body>
</html>

