<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeMeUpzz.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="emailLog" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="passLog" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me"/>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Don't have account yet? "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Register.aspx">register here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
