<%@ Page Title="" Language="C#" MasterPageFile="~/frontend.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="onlineBookShop.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/login.css" rel="stylesheet" />
    <h2>Login</h2>

    <div class="login-container">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
</asp:Content>

