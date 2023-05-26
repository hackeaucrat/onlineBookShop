<%@ Page Title="manage" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="onlineBookShop.manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 259px;
        }
        .auto-style2 {
            width: 410px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Books Page</h1>

    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblbookID" runat="server" Text="Book ID"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddlbookID" runat="server" CssClass="inputbox">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnCreate" runat="server" CssClass="button" Text="Create Book Record" OnClick="btnCreate_Click1" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblbookTitle" runat="server" Text="Book Title"></asp:Label>
            </td>
            <td class="auto-style2"><asp:TextBox ID="txtbookTitle" runat="server" CssClass="inputbox"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnRetrieve" runat="server" CssClass="button" Text="Retrieve Book Record" OnClick="btnRetrieve_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblbookPrice" runat="server" Text="Book Price"></asp:Label>
            </td>
            <td class="auto-style2"><asp:TextBox ID="txtbookPrice" runat="server" CssClass="inputbox"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update Book Record" OnClick="btnUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblbookAuthor" runat="server" Text="Book Author"></asp:Label>
            </td>
            <td class="auto-style2"><asp:TextBox ID="txtbookAuthor" runat="server" CssClass="inputbox"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete Book Record" OnClick="btnDelete_Click" />
            </td>
        </tr>
        
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblbookImg" runat="server" Text="Book Image"></asp:Label>
            </td>
            <td class="auto-style2"><asp:TextBox ID="txtbookImg" runat="server" CssClass="inputbox"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblimgPreview" runat="server" Text="Book Image Preview"></asp:Label>
            </td>
            <td class="auto-style2"><asp:Image ID="imgPreview" runat="server" CssClass="inputbox" Height="300px" Width="300px" /></td>
            <td>&nbsp;</td>
        </tr>

    </table>

</asp:Content>


