<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="UniWebsite.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Add Student</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sqlDbConnectionString %>" ProviderName="<%$ ConnectionStrings:sqlDbConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
            <asp:Table runat="server" Height="37px" Width="1322px"></asp:Table>
            <asp:Label ID="studentNameLabel" runat="server" Text="Add a new student to the database." ForeColor="White"></asp:Label>
            <p></p>
            <div>
                <asp:Label ID="studentFirstNameLabel" runat="server" Text="First Name: " ForeColor="White"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="studentFirstName" runat="server" Height="18px" MaxLength="64" Width="150px"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="studentLastNameLabel" runat="server" Text="Last Name: " ForeColor="White"></asp:Label>
            </div>
                <asp:TextBox ID="studentLastName" runat="server" Height="18px" MaxLength="64" Width="150px"></asp:TextBox>
            <div>
                <asp:Label ID="studentLocationLabel" runat="server" Text="Student Location: " ForeColor="White"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="studentLocation" runat="server" Height="18px" MaxLength="256" Width="150px"></asp:TextBox>
            </div>
            <div>
                <p></p>
                <asp:Button ID="addStudent" runat="server" Text="Add Student" OnClick="addStudent_Click" />
            </div>
        </div>
    </form>
</body>
</html>
