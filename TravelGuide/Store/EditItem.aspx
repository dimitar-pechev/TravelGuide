<%@ Page Title="Edit Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="TravelGuide.Store.EditItem" %>

<asp:Content ID="EditItem" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-6 col-md-offset-3 text-center">
                <div class="card">
                    <div class="card-content form-add">
                        <h4>Edit Store Item</h4>
                        <p runat="server" id="ErrorMessage" visible="false" style="color: red;">An error occured! Please correct your data and try again!</p>
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
                        <textarea runat="server" id="NewItemDescription" rows="3" class="form-control" />
                        <asp:Button Text="Submit" CssClass="btn btn-success btn-login" ID="BtnEditItem" OnClick="BtnEditItem_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
