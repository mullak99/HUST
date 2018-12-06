<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentLocations.aspx.cs" Inherits="HUST.CurrentLocations" %>

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
    <title>HUST | All Locations</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><asp:ImageButton href="default.aspx" ID="homeImage" runat="server" Height="43px" ImageAlign="Left" ImageUrl="~/Images/HullUni.png" Width="72px" ForeColor="White" /></li>
                <li><a href="default.aspx">Home</a></li>
                <li><a href="AddStudent.aspx">Add Student</a></li>
                <li><a href="EditStudent.aspx">Edit Student</a></li>
                <li><a href="ChangeStudentLocation.aspx">Set Student Location</a></li>
                <li><a href="GetStudent.aspx">Show Student</a></li>
                <li><a class="active" href="GetAllStudents.aspx">Show All Students</a></li>
                <li><a href="CurrentLocations.aspx">All Locations</a></li>
            </ul>
        </div>
        <div>
            <p></p>
            <asp:Label ID="selectLocationLabel" runat="server" Text="Select Location:" ForeColor="White"></asp:Label>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div>
                <asp:DropDownList ID="selectLocationList" runat="server" Height="25px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="selectLocationList_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div><p></p></div>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="StudentGrid" runat="server" ForeColor="White"></asp:GridView>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="selectLocationList" EventName="SelectedIndexChanged" runat="server"/>
                </Triggers>
            </asp:UpdatePanel>
            <asp:Label ID="NoStudentsWarning" runat="server" Text="No Locations in the database." ForeColor="White" Visible="False"></asp:Label>
        </div>
    </form>
</body>
</html>
<footer>
    <p style="font-size:10px;color:#FFFFFF">Copyright © | mullak99 - 2018</p>
</footer>