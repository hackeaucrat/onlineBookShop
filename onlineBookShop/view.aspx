<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="onlineBookShop.view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>View Books Page</h1>
    <table style="width: 100%;">

        <tr>
            <td class="auto_style1">
                <asp:Label ID="lblSort" runat="server" CssClass="inputbox" Text="Sort by (Price)"></asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlSort" CssClass="inputbox">
                    <asp:ListItem>Ascending</asp:ListItem>
                    <asp:ListItem>Desending</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button runat="server" Text="Refresh View" ID="Button1" CssClass="button" OnClick="btnRefresh_Click"></asp:Button>
            </td>
        </tr>

    </table>
    <asp:GridView ID="gvView" runat="server" CssClass="auto_style1"></asp:GridView>

</asp:Content>
