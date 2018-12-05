<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeStudentLocation.aspx.cs" Inherits="UniWebsite.ChangeStudentLocation" %>

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
    <title>RDE Website | Change Student Location</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="default.aspx">Home</a></li>
                <li><a href="AddStudent.aspx">Add Student</a></li>
                <li><a href="EditStudent.aspx">Edit Student</a></li>
                <li><a class="active" href="ChangeStudentLocation.aspx">Set Student Location</a></li>
                <li><a href="GetStudent.aspx">Show Student</a></li>
                <li><a href="GetAllStudents.aspx">Show All Students</a></li>
                <li><a href="CurrentLocations.aspx">All Locations</a></li>
            </ul>
        </div>
        <div>
            <p></p>
            <asp:Label ID="selectStudentLabel" runat="server" Text="Select Student:" ForeColor="White"></asp:Label>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div>
                <asp:DropDownList ID="selectStudentList" runat="server" Height="25px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="selectStudentList_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div>
                <asp:Label ID="currentLocLabel" runat="server" Text="Current Location: " ForeColor="White"></asp:Label><asp:Label ID="currentLoc" runat="server" Text="PLACEHOLDER" ForeColor="White"></asp:Label>
            </div>
            <div>
                <asp:Label ID="currentLocTimeLabel" runat="server" Text="Check-In Time: " ForeColor="White"></asp:Label><asp:Label ID="checkinTime" runat="server" Text="00/00/00 00:00:00 XX" ForeColor="White"></asp:Label>
                <div><p></p></div>
            </div>
            <div>
                <asp:Label ID="changeStudentLocLabel" runat="server" Text="Change Student Location: " ForeColor="White"></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="changeStudentLoc" runat="server" Height="18px" MaxLength="64" Width="250px"></asp:TextBox>
            </div>
                <p></p>
                <asp:Button ID="changeLocButton" runat="server" Text="Change Location" OnClick="editStudentLocButton_Click" />
            </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="selectStudentList" EventName="SelectedIndexChanged" runat="server"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<footer>
    <p style="font-size:10px;color:#FFFFFF">Copyright © | mullak99 - 2018</p>
</footer>