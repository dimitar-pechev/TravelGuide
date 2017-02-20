<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TravelGuide.Store.Details" %>

<asp:Content ID="DetailsStoreITem" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <img src="/Images/shop-cover.png" alt="maps-shop" class="img-responsive" />
    </div>
    <div class="container store-container">
        <hr class="hr" />
        <div class="row">
            <div class="col-md-4">
                <img src="<%#: this.StoreItem.ImageUrl %>" runat="server" class="item-details-image" alt="Alternate Text" />
            </div>
            <div class="col-md-4 item-second-col">
                <h4><%#: this.StoreItem.ItemName %></h4>
                <p><i><%#: this.StoreItem.Brand %></i></p>
                <p class="item-description"><%#: this.StoreItem.Description %></p>
            </div>
            <div class="col-md-4">
                <h4><%#: string.Format($"{this.StoreItem.Price} BGN") %></h4>
                <p><%#: this.StoreItem.InStock ? "In Stock" : "Depleted" %></p>
                <div>
                    <asp:Label Text="Quantity" AssociatedControlID="QuantityWanted" runat="server" />
                </div>
                <div class="row buy-details">
                    <input type="number" min="1" max="10" value="" class="form-quantity" id="QuantityWanted" runat="server" />
                    <asp:Button Text="Add to Cart" ID="BtnAddToCart" CssClass="btn btn-success"
                        OnClick="BtnAddToCart_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
