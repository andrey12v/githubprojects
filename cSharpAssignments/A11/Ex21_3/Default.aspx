<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <h2>Current time on the Web server:</h2>
            <p>
               <asp:Label ID="timeLabel" runat="server" BackColor="Black"
                  Font-Size="XX-Large" ForeColor="Yellow"
                  EnableViewState="False"></asp:Label>
            </p>
        <p>
            <table style="width: 920px">
                <tr>
                    <td style="font-size: x-large" align="center">
                        Change back color</td>
                    <td style="font-size: x-large" align="center">
                        Change fore color</td>
                    <td style="font-size: x-large" align="center">
                        Change font size</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DropDownList ID="ddBackColor" runat="server" AutoPostBack="True">
                            <asp:ListItem>Black</asp:ListItem>
                            <asp:ListItem>Green</asp:ListItem>
                            <asp:ListItem>Yellow</asp:ListItem>
                            <asp:ListItem>Red</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="center">
                        <asp:DropDownList ID="ddForeColor" runat="server" AutoPostBack="True">
                            <asp:ListItem>White</asp:ListItem>
                            <asp:ListItem>Black</asp:ListItem>
                            <asp:ListItem>Green</asp:ListItem>
                            <asp:ListItem>Blue</asp:ListItem>
                        </asp:DropDownList></td>
                    <td align="center">
                        <asp:DropDownList ID="ddFontSize" runat="server" AutoPostBack="True">
                            <asp:ListItem>25 pixel</asp:ListItem>
                            <asp:ListItem>30 pixel</asp:ListItem>
                            <asp:ListItem>35 pixel</asp:ListItem>
                            <asp:ListItem>40 pixel</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
        </p>
         </div>
    </form>
</body>
</html>
