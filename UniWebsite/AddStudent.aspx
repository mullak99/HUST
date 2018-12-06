<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="UniWebsite.AddStudent" %>

<!DOCTYPE html>
<style type="text/css">
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
    background-color: #333;
}

li {
    float: left;
}

li a {
    display: block;
    color: white;
    text-align: center;
    padding: 14px 16px;
    text-decoration: none;
}

li a:hover {
    background-color: green;
    color: black
}
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Add Student</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><asp:ImageButton href="default.aspx" ID="homeImage" runat="server" Height="43px" ImageAlign="Left" ImageUrl="~/Images/HullUni.png" Width="72px" /></li>
                <li><a href="default.aspx">Home</a></li>
                <li><a class="active" href="AddStudent.aspx">Add Student</a></li>
                <li><a href="EditStudent.aspx">Edit Student</a></li>
                <li><a href="ChangeStudentLocation.aspx">Set Student Location</a></li>
                <li><a href="GetStudent.aspx">Show Student</a></li>
                <li><a href="GetAllStudents.aspx">Show All Students</a></li>
                <li><a href="CurrentLocations.aspx">All Locations</a></li>
            </ul>
        </div>
        <div>
            <p></p>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:sqlDbConnectionString %>" ProviderName="<%$ ConnectionStrings:sqlDbConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [students]"></asp:SqlDataSource>
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
            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <p></p>
                        <asp:Label ID="messageLabel" runat="server" Text="" ForeColor="White"></asp:Label> 
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="addStudent" EventName="Click" runat="server"/>
                </Triggers>
            </asp:UpdatePanel>
            <div>
                <p></p>
                <asp:Button ID="addStudent" runat="server" Text="Add Student" OnClick="addStudent_Click" />
            </div>
        </div>
    </form>
</body>
</html>
<footer>
    <p style="font-size:10px;color:#FFFFFF">Copyright © | mullak99 - 2018</p>
</footer>