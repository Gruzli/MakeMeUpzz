<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <asp:Label ID="roleLbl" runat="server" Text="Role"></asp:Label>
        <asp:Label ID="nameLbl" runat="server" Text="Name"></asp:Label>
    </div>
    <div>
        <asp:Label ID="customerDataLbl" runat="server" Text="Customer Data"></asp:Label>
        <asp:GridView ID="customerGrid" runat="server"></asp:GridView>
    </div>
</asp:Content>
