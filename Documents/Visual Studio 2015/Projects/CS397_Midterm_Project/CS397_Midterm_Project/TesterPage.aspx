<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TesterPage.aspx.cs" Inherits="CS397_Midterm_Project.TesterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome!</h1>
        <h3>Submit a bug report below:</h3>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell><p>Subject:</p></asp:TableCell>
                <asp:TableCell><asp:TextBox ID="SubjectTextBox" runat="server" Width="500px"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top"><p>Description:</p></asp:TableCell>
                <asp:TableCell VerticalAlign="Top"><asp:TextBox ID="DescriptionTextBox" runat="server" Width="300px" Height="100px" TextMode="MultiLine"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><p>Priority:</p></asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="PriorityDropDownList" runat="server" Width="150px">
                        <asp:ListItem>Low</asp:ListItem>
                        <asp:ListItem>Medium</asp:ListItem>
                        <asp:ListItem>High</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="ReportButton" runat="server" Text="File Report" OnClick="ReportButton_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
        <br /><br />
    <div>
        <asp:GridView ID="BugGridView" runat="server" AutoGenerateEditButton="true" OnRowEditing="BugGridView_RowEditing" OnRowUpdated="BugGridView_RowUpdated"></asp:GridView>
    </div>
    <div>
        <asp:Button ID="LogoffButton" runat="server" OnClick="LogoffButton_Click" Text ="Logoff"/>
    </div>
    </form>
</body>
</html>
