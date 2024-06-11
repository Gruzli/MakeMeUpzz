<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Test.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox RequiredFieldValidator ID="TbUsername" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Email" TextMode="email"></asp:Label>
            <asp:TextBox RequiredFieldValidator ID="TbEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton RequiredFieldValidator ID="Male" runat="server" Text="Male" GroupName="gender" OnCheckedChanged="Male_CheckedChanged" />
            <asp:RadioButton RequiredFieldValidator ID="Female" runat="server" Text="Female" GroupName="gender"/>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <asp:TextBox RequiredFieldValidator ID="TbPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Confirmation Password"></asp:Label>
            <asp:TextBox RequiredFieldValidator ID="TbConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox RequiredFieldValidator ID="TbDOB" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        
    </form>
</body>
</html>
