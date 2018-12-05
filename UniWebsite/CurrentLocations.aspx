<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentLocations.aspx.cs" Inherits="UniWebsite.CurrentLocations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RDE Website | Current Locations</title>
</head>
<body style="background-color:#282828">
    <form id="form1" runat="server">
        <div>
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
        </div>
    </form>
</body>
</html>
