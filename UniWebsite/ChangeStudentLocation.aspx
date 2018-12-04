<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeStudentLocation.aspx.cs" Inherits="UniWebsite.ChangeStudentLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Change Student Location</title>
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
