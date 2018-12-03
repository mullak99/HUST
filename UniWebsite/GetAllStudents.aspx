<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAllStudents.aspx.cs" Inherits="UniWebsite.GetAllStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Server | All Students</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="allStudentsTable" runat="server" ForeColor="White"></asp:GridView>
        </div>
    </form>
</body>
</html>
