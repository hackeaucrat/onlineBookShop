<%@ Page Title="Home" Language="C#" MasterPageFile="~/frontend.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="onlineBookShop.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="css/home.css" rel="stylesheet" />
    <h2>Popular Books</h2>

    <div class="books-item">
        
        <asp:Repeater ID="rptBooks" runat="server">
            <ItemTemplate>
                <div class="book-item">
                    <h4><%# Eval("bookTitle") %></h4>
                   <asp:Image ID="imgBook" runat="server" ImageUrl='<%# Eval("bookImg") %>' CssClass="book-image" />

                    <p><%# Eval("bookAuthor") %></p>
                    <p>Price: £<%# Eval("bookPrice") %></p>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Basket" CommandName="AddToCart"
                        CommandArgument='<%# Eval("bookID") %>' OnCommand="btnAddToCart_Command" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
