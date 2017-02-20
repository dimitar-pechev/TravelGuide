<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TravelGuide.Cart" %>

<asp:Content ID="Cart" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container cart-container">
        <h3 class="text-center"><span class="glyphicon glyphicon-shopping-cart"></span> Cart</h3>
        <hr />
        <h4><%#: this.ItemsCount %></h4>
        <asp:GridView runat="server">
        </asp:GridView>
    </div>
</asp:Content>
