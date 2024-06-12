<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz.View.ManageMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <h1>Manage Makeup</h1>
    <div>
        <asp:Button ID="insertMakeupBtn" runat="server" Text="Insert Makeup" OnClick="insertMakeupBtn_Click" />
    </div>
    <div>
        <asp:Button ID="insertMakeupTypeBtn" runat="server" Text="Insert Makeup Type" OnClick="insertMakeupTypeBtn_Click" />
    </div>
    <div>
        <asp:Button ID="insertMakeupBrandBtn" runat="server" Text="Insert Makeup Brand" OnClick="insertMakeupBrandBtn_Click" />
    </div>
    <div>
        <h2>Makeup List</h2>
        <asp:GridView ID="makeupGridView" runat="server" au="" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName"></asp:BoundField>
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice"></asp:BoundField>
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight"></asp:BoundField>
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupType.MakeupTypeName"></asp:BoundField>
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrand.MakeupBrandName"></asp:BoundField>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
     <h2>Makeup Types</h2>
        <asp:GridView ID="makeupTypeGridView" runat="server" au="" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeName"></asp:BoundField>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
         <Columns>
         </Columns>
     </asp:GridView>
    </div>
    <div>
     <h2>Makeup Brands</h2>
        <asp:GridView ID="makeupBrandGridView" runat="server" au="" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrandName"></asp:BoundField>
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating"></asp:BoundField>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            </Columns>
         <Columns>
         </Columns>
     </asp:GridView>
    </div>
</asp:Content>
