<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeMeUpzz.View.ManageMakeup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
