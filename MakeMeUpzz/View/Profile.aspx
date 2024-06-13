<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MakeMeUpzz.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h2>Profile Information</h2>
    <div>
        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="TbUsername" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TbEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButton ID="Male" runat="server" Text="Male" GroupName="gender"/>
        <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="gender"/>
    </div>
    <div>
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="TbDOB" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Edit Profile" OnClick="btnSubmit_Click" />
    <div>
        <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
    </div>

    <h2>Change Password</h2>
    <div>
        <asp:Label ID="lblOldPass" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="TbOldPass" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblNewPass" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="TbNewPass" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <asp:Button ID="btnchangePass" runat="server" Text="Change Password" OnClick="btnchangePass_Click" />
    <div>
        <asp:Label ID="Err2" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
    </div>
</asp:Content>
