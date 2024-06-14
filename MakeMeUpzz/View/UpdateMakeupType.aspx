<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupType.aspx.cs" Inherits="MakeMeUpzz.View.UpdateMakeupType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Update Makeup Type</h1>
    <asp:Button ID="backBtn" runat="server" Text="⬅️Back" OnClick="backBtn_Click" />
    <div>
        <asp:Label ID="typeNameLbl" runat="server" Text="Makeup Type"></asp:Label>
        <asp:TextBox ID="typeNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    </div>

    <asp:Button ID="updateTypeBtn" runat="server" Text="Update Type" OnClick="updateTypeBtn_Click" />
</asp:Content>
