<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeMeUpzz.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="~/Stylesheet/Register.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3 class="titlesrg">Register</h3>
        </header>

        <div id="input-box">
            <asp:Label ID="lvlUsername" runat="server" Text="Username"></asp:Label><br />
            <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
        </div>
        <div id="input-box">
            <asp:Label ID="lblEMail" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TbEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div id="gender-box">
            <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label><br />
            <ul class="radio-group">
                <li>
                    <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="gender" />
                </li>
                <li>
                    <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="gender" />
                </li>
            </ul>
        </div>
        <div id="input-box">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div id="input-box">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmation Password"></asp:Label><br />
            <asp:TextBox ID="TbConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div id="input-box">
            <asp:Label ID="lblDob" runat="server" Text="Date of Birth"></asp:Label><br />
            <asp:TextBox ID="TbDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="Error" ForeColor="Red"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
        <div id="regisnav">
            <asp:Label ID="lblLogin" runat="server" Text="Already have an account? "></asp:Label><br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Login.aspx">Login here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
