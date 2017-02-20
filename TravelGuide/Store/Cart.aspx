<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TravelGuide.Cart" %>

<asp:Content ID="Cart" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container cart-container">
        <h3 class="text-center"><span class="glyphicon glyphicon-shopping-cart"></span>Cart</h3>
        <hr />
        <asp:GridView CssClass="cart-table table table-responsive table-hover" ID="GridViewCartItems" runat="server"
            AutoGenerateColumns="false" AllowPaging="True" PageSize="5" DataKeyNames="Id"
            OnPageIndexChanging="GridViewCartItems_PageIndexChanging" OnRowDeleting="GridViewCartItems_RowDeleting"
            PagerStyle-CssClass="page-btn" ItemType="TravelGuide.Models.Store.StoreItem">
            <Columns>
                <asp:ImageField AlternateText="ItemName" DataImageUrlField="ImageUrl" NullImageUrl="http://devueltaalobasico.com/wp-content/uploads/2013/06/Signo_de_Pregunta.png" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" NullDisplayText="N/A" SortExpression="ItemName" />
                <asp:BoundField HeaderText="Brand" DataField="Brand" NullDisplayText="N/A" SortExpression="Brand" />
                <asp:BoundField HeaderText="Related Destination" DataField="DestinationFor" NullDisplayText="N/A" SortExpression="DestinationFor" />
                <asp:BoundField HeaderText="Price" DataField="Price" NullDisplayText="N/A" SortExpression="Price" />
                <asp:HyperLinkField Text="Details" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Store/Details.aspx?id={0}"
                    ItemStyle-CssClass="text-center" ControlStyle-CssClass="btn btn-sm btn-success" />
                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-sm btn-danger" ItemStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
        <div class="row text-right" id="CheckoutPanel" runat="server">
            <asp:Label Text="" ID="TotalPrice" runat="server" CssClass="total-price" />
            <br />
            <asp:Button Text="Check Out!" ID="BtnCheckOut" CssClass="btn btn-success btn-login btn-checkout" runat="server" />
        </div>
    </div>
</asp:Content>
