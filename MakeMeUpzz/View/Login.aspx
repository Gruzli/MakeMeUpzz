<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/Stylesheet/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3 class="titleslg">Login</h3>
        </header>
        <div id="input-box">
            <asp:Label ID="emailLog" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
        </div>
        <div id="input-box">
            <asp:Label ID="passLog" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div id="check-box">
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me"/>
        </div >
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <div id="loginnav">
            <asp:Label ID="Label1" runat="server" Text="Don't have an account yet? "></asp:Label><br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Register.aspx">register here </asp:HyperLink>
        </div>
    </form>
</body>
</html>
