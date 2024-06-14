<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrand.aspx.cs" Inherits="MakeMeUpzz.View.UpdateMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Update Makeup Brand</h1>
    <asp:Button ID="backBtn" runat="server" Text="⬅️Back" OnClick="backBtn_Click" />
    <div>
        <asp:Label ID="brandNameLbl" runat="server" Text="Makeup Brand"></asp:Label>
        <asp:TextBox ID="brandNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
    <asp:Label ID="brandRatingLbl" runat="server" Text="Brand Rating"></asp:Label>
        <asp:TextBox ID="brandRatingTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    </div>

    <asp:Button ID="updateBrandBtn" runat="server" Text="Update Brand" OnClick="updateBrandBtn_Click" />
</asp:Content>
