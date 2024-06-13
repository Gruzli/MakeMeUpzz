<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateMakeup.aspx.cs" Inherits="MakeMeUpzz.View.UpdateMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Update Makeup</h1>
    <asp:Button ID="backBtn" runat="server" Text="⬅️Back" OnClick="backBtn_Click" />
    <div>
        <asp:Label ID="makeupNameLbl" runat="server" Text="Makeup Name"></asp:Label>
        <asp:TextBox ID="makeupNameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="makeupPriceLbl" runat="server" Text="Makeup Price"></asp:Label>
        <asp:TextBox ID="makeupPriceTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="makeupWeightLbl" runat="server" Text="Makeup Weight"></asp:Label>
        <asp:TextBox ID="makeupWeightTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="makeupTypeLbl" runat="server" Text="Makeup Type"></asp:Label>
        <asp:DropDownList ID="makeupTypeDdl" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="makeupBrandLbl" runat="server" Text="Makeup Brand"></asp:Label>
        <asp:DropDownList ID="makeupBrandDdl" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="Err" runat="server" Text="Label" ForeColor="Red"></asp:Label>
    </div>

    <asp:Button ID="updateMakeupBtn" runat="server" Text="Update Makeup" OnClick="updateMakeupBtn_Click" />
</asp:Content>
