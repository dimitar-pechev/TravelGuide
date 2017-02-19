<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="TravelGuide.Store.AddItem" %>

<asp:Content ID="AddItemPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-6 col-md-offset-3 text-center">
                <div class="card">
                    <div class="card-content form-add">
                        <h4>Add a New Store Item</h4>
                        <hr />
                        <asp:Label Text="Item Name" AssociatedControlID="NewItemName" runat="server" />
                        <asp:TextBox runat="server" ID="NewItemName" />
                        <br />
                        <asp:Label Text="Related Destination" AssociatedControlID="NewItemDestFor" runat="server" />
                        <asp:TextBox runat="server" ID="NewItemDestFor" />
                        <br />
                        <asp:Label Text="Brand" AssociatedControlID="NewItemBrand" runat="server" />
                        <asp:TextBox runat="server" ID="NewItemBrand" />
                        <br />
                        <asp:Label Text="Cover Image Url" AssociatedControlID="NewItemImageUrl" runat="server" />
                        <asp:TextBox runat="server" ID="NewItemImageUrl" TextMode="Url" />
                        <br />
                        <asp:Label Text="Price" AssociatedControlID="NewItemPrice" runat="server" />
                        <asp:TextBox runat="server" ID="NewItemPrice" />
                        <br />
                        <asp:Label Text="Short Description" AssociatedControlID="NewItemDescription" runat="server" />
                        <textarea runat="server" ID="NewItemDescription" rows="3" class="form-control" />
                        <asp:Button Text="Add" CssClass="btn btn-success btn-login" ID="BtnAddNewItem" OnClick="BtnAddNewItem_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
