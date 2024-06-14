<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertMakeupBrand.aspx.cs" Inherits="MakeMeUpzz.View.InsertMakeupBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Insert Makeup Brand</h1>
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

    <asp:Button ID="insertBrandBtn" runat="server" Text="Insert Brand" OnClick="insertBrandBtn_Click" />
</asp:Content>
