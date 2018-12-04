<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetStudent.aspx.cs" Inherits="UniWebsite.GetStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Get Student</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="selectStudentLabel" runat="server" Text="Select Student:" ForeColor="White"></asp:Label>
        </div>
        <div>
            <div>
                <asp:DropDownList ID="selectStudentList" runat="server" Height="25px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="selectStudentList_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div><p></p></div>
            <asp:GridView ID="StudentGrid" runat="server" ForeColor="White"></asp:GridView>
        </div>
    </form>
</body>
</html>
