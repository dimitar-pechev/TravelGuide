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
                <div id="BuyDetails" runat="server">
                    <div>
                        <asp:Label Text="Quantity" AssociatedControlID="QuantityWanted" runat="server" />
                    </div>
                    <div class="row buy-details">
                        <input type="number" min="1" max="10" value="" class="form-quantity" id="QuantityWanted" runat="server" />
                        <asp:Button Text="Add to Cart" ID="BtnAddToCart" CssClass="btn btn-success"
                            OnClick="BtnAddToCart_Click" runat="server" />
                    </div>
                </div>
                <div runat="server" id="AdminOptionsPanel">
                    <h4 class="text-center">Admin Options</h4>
                    <asp:HyperLink Text="Edit" NavigateUrl='<%#: string.Format($"~/Store/EditItem.aspx?id={StoreItem.Id}") %>' CssClass="btn btn-default" runat="server" />
                    <asp:Button Text="Change Status" CssClass="btn btn-default" data-toggle="modal" data-target="#status-box"
                        ID="BtnChangeStatusReveal" runat="server" />
                    <asp:Button Text="Delete" CssClass="btn btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="status-box" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <p>Change the status of the product</p>
                </div>
                <div class="modal-body">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="StatusOptions">
                        <asp:ListItem Text="In stock" Value="true" />
                        <asp:ListItem Text="Depleted" Value="false" />
                    </asp:DropDownList>
                </div>
                <div class="modal-footer footer-comment">
                    <asp:Button Text="Submit" CssClass="btn btn-success btn-gallery" ID="BtnSubmitStatusChange" OnClick="BtnSubmitStatusChange_Click" runat="server" />
                    <asp:Button Text="Discard" CssClass="btn btn-danger btn-gallery" data-dismiss="modal" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
