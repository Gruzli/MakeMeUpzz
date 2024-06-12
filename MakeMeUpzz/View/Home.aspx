<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MakeMeUpzz.View.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Stylesheet/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <div>
                <a href="Login.aspx">Order Makeup</a>
                <a href="Login.aspx">History</a>
                
            </div>
            <div>
                <asp:Button ID="profileBtn" runat="server" Text="Profile" />
                <asp:Button ID="logoutBtn" runat="server" Text="Logout" OnClick="logoutBtn_Click"/>
            </div>

        </div>
        <div>
            <asp:Label ID="roleLbl" runat="server" Text="Role"></asp:Label>
            <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
        </div>
        <div>
            <asp:Label ID="customerDataLbl" runat="server" Text="Customer Data"></asp:Label>
            <asp:GridView ID="customerGrid" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
