<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="onlineBookShop.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:Button ID="btnManage" runat="server" Text="Manage Books" Height="100px" Width="200px" CssClass="button" OnClick="btnManage_Click" />
    <br />
    <br />
    <br />
    <asp:Button ID="btnView" runat="server" Text="View Books" Height="100px" Width="200px" CssClass="button" OnClick="btnView_Click" />


</asp:Content>
