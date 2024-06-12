<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz.View.ManageMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <asp:Button ID="insertMakeupBtn" runat="server" Text="Insert Makeup" OnClick="insertMakeupBtn_Click" />
    </div>
    <div>
        <asp:Button ID="insertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" OnClick="insertMakeupTypeBtn_Click" />
    </div>
    <div>
        <asp:Button ID="insertMakeupBrandBtn" runat="server" Text="Insert Makeup Brand" OnClick="insertMakeupBrandBtn_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
