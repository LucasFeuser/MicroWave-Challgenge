<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MicroOndas.Application.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="LoginForm" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="lblUsername" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="LoginUser" />
        </div>
    </form>
</body>
</html>
