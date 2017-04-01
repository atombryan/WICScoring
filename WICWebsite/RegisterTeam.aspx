<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterTeam.aspx.cs" Inherits="WICWebsite.RegisterTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TeamNumber<br />
            <asp:TextBox ID="teamNumber" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            TeamName</div>
        <asp:TextBox ID="teamName" runat="server"></asp:TextBox>
        <br />
        <br />
        WAI Score<br />
        <asp:TextBox ID="waiScore" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        Submit<br />
        <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        <br />
        <asp:Label ID="returningCode" runat="server" Text="ReturnCode"></asp:Label>
        <br />
    </form>
</body>
</html>
