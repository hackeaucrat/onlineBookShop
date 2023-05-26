<%@ Page Title="Basket" Language="C#" MasterPageFile="~/frontend.Master" AutoEventWireup="true" CodeBehind="basket.aspx.cs" Inherits="onlineBookShop.basket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/basket.css" rel="stylesheet" />

    <h2>Basket</h2>
    <div class="loggedInUser">
        <asp:Label ID="lblLoggedInUser" runat="server" CssClass="logged-in-user" Visible="false"></asp:Label>
    </div>

    <div class="basket-container">
        <asp:Repeater ID="rptBasketItems" runat="server">
            <ItemTemplate>
                <div class="basket-item">
                    <div class="book-column">
                        <asp:Image ID="imgBook" runat="server" ImageUrl='<%# GetImageUrl(Eval("bookImg")) %>' CssClass="book-image" />
                    </div>
                    <div class="details-column">
                        <div class="title-author-section">
                            <h4><%# Eval("bookTitle") %></h4>
                            <p><%# Eval("bookAuthor") %></p>
                        </div>
                        <div class="price-section">
                            <p>Price: £<%# Eval("bookPrice") %></p>
                        </div>
                    </div>
                    <div class="action-column">
                        <asp:Button ID="btnRemoveFromCart" runat="server" Text="Remove" CommandName="RemoveFromCart"
                            CommandArgument='<%# Eval("bookID") %>' OnCommand="btnRemoveFromCart_Command" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="checkout-section">
            <h3>Total Price: £<asp:Literal ID="litTotalPrice" runat="server"></asp:Literal></h3>
            <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
        </div>
    </div>
</asp:Content>