<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="emailLog" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TbEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="passLog" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
