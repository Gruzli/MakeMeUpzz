<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeMeUpzz.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lvlUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblEMail" runat="server" Text="Email" TextMode="email"></asp:Label>
            <asp:TextBox ID="TbEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="gender"/>
            <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="gender"/>
        </div>
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmation Password"></asp:Label>
            <asp:TextBox ID="TbConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblDob" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="TbDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <div>
            <asp:Label ID="lblLogin" runat="server" Text="Already have account? "></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Login.aspx">login here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
