<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UniWebsite._default" %>

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
    <title>RDE Website</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><asp:ImageButton href="default.aspx" ID="homeImage" runat="server" Height="43px" ImageAlign="Left" ImageUrl="~/Images/HullUni.png" Width="72px" /></li>
                <li><a class="active" href="default.aspx">Home</a></li>
                <li><a href="AddStudent.aspx">Add Student</a></li>
                <li><a href="EditStudent.aspx">Edit Student</a></li>
                <li><a href="ChangeStudentLocation.aspx">Set Student Location</a></li>
                <li><a href="GetStudent.aspx">Show Student</a></li>
                <li><a href="GetAllStudents.aspx">Show All Students</a></li>
                <li><a href="CurrentLocations.aspx">All Locations</a></li>
            </ul>
        </div>
        <div>
            <p></p>
            <p style="color:#FFFFFF">Welcome to the RDE Student Location Tracker!</p>
            <p style="color:#FFFFFF">Navigate to one of the pages above.</p>
        </div>
    </form>
</body>
</html>
<footer>
    <p style="font-size:10px;color:#FFFFFF">Copyright © | mullak99 - 2018</p>
</footer>