<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="UniWebsite.EditStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Edit Student</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="selectStudentLabel" runat="server" Text="Select Student:" ForeColor="White"></asp:Label>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div>
                <asp:DropDownList ID="selectStudentList" runat="server" Height="25px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="selectStudentList_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div><p></p></div>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
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
                <p></p>
                <asp:Button ID="editStudentButton" runat="server" Text="Edit Student" OnClick="editStudentButton_Click" />
                <p></p><p style="color:#FFFFFF">This action is NOT reversable!</p>
                <asp:Button ID="deleteStudentButton" runat="server" Text="Delete Student" OnClick="deleteStudentButton_Click" BackColor="Red" BorderColor="#CC0000" ForeColor="White" />
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
