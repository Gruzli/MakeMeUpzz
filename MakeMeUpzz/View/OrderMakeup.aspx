<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="MakeMeUpzz.View.OrderMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div>
        <asp:GridView ID="GridViewOrder" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" Visible="False" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="MakeupType" SortExpression="MakeupType.MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand Name" SortExpression="MakeupBrand.MakeupBrandName" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
