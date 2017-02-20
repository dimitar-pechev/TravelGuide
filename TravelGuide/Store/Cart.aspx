<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="TravelGuide.Cart" %>

<asp:Content ID="Cart" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container cart-container">
        <h3 class="text-center"><span class="glyphicon glyphicon-shopping-cart"></span>Cart</h3>
        <hr />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div runat="server" id="HasItemsTemplate">
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
                        <asp:Button Text="Check Out!" ID="BtnCheckOut" data-toggle="modal" data-target="#check-out" CssClass="btn btn-success btn-login btn-checkout" runat="server" />
                    </div>
                </div>
                <div class="row text-center" id="NoItemsTemplate" visible="false" runat="server">
                    <p>Your cart is empty...</p>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row text-center" id="ReceivedOrder" visible="false" runat="server">
            <p>Your order has been received! An administrator will contact you!</p>
        </div>
    </div>
    <div class="modal fade" id="check-out" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <p>Confirm your date before checking out</p>
                </div>
                <div class="modal-body">
                    <asp:Label Text="First Name" AssociatedControlID="FirstName" runat="server" />
                    <asp:TextBox runat="server" ID="FirstName" />
                    <br />
                    <asp:Label Text="Last Name" AssociatedControlID="LastName" runat="server" />
                    <asp:TextBox runat="server" ID="LastName" />
                    <br />
                    <asp:Label Text="Phone Number" AssociatedControlID="PhoneNumber" runat="server" />
                    <asp:TextBox runat="server" ID="PhoneNumber" TextMode="Number" />
                    <br />
                    <asp:Label Text="Address" AssociatedControlID="Address" runat="server" />
                    <asp:TextBox runat="server" ID="Address" />
                    <br />
                </div>
                <div class="modal-footer footer-comment">
                    <asp:Button Text="Submit" OnClick="BtnCheckOut_Click" CssClass="btn btn-success btn-gallery" ID="BtnSubmitData" runat="server" />
                    <asp:Button Text="Discard" CssClass="btn btn-danger btn-gallery" data-dismiss="modal" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
