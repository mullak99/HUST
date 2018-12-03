<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="UniWebsite.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Add User</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sqlDbConnectionString %>" ProviderName="<%$ ConnectionStrings:sqlDbConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
            <asp:Table runat="server" Height="37px" Width="1322px"></asp:Table>
            <asp:Label ID="studentNameLabel" runat="server" Text="Student:" ForeColor="White"></asp:Label>
            <div></div>
            <asp:Label ID="studentLastNameLabel" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
            <asp:TextBox ID="studentLastName" runat="server"></asp:TextBox>
            <div></div>
            <asp:Label ID="studentFirstNameLabel" runat="server" Text="First Name: " ForeColor="White"></asp:Label>
            <asp:TextBox ID="studentFirstName" runat="server"></asp:TextBox>
            <div></div>
            <asp:Label ID="studentLocationLabel" runat="server" Text="Student Location: " ForeColor="White"></asp:Label>
            <asp:TextBox ID="studentLocation" runat="server"></asp:TextBox>
            <div></div>
            <asp:Button ID="addStudent" runat="server" Text="Add" OnClick="addStudent_Click" />
        </div>
    </form>
</body>
</html>
