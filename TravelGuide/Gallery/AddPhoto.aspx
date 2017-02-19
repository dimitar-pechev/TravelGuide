<%@ Page Title="Add Your Photos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPhoto.aspx.cs" Inherits="TravelGuide.Gallery.AddPhoto" %>

<asp:Content ID="AddNewPhoto" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-6 col-md-offset-3 text-center">
                <div class="card">
                    <div class="card-content form-add">
                        <h4>Add a New Photo</h4>
                        <hr />
                        <asp:Label Text="Title" AssociatedControlID="NewImageTitle" runat="server" />
                        <asp:TextBox runat="server" ID="NewImageTitle" />
                        <br />
                        <asp:Label Text="Image Url" AssociatedControlID="NewImageUrl" runat="server" />
                        <asp:TextBox runat="server" ID="NewImageUrl" />
                        <asp:Button Text="Add" CssClass="btn btn-success btn-login" ID="BtnAddNewPhoto" OnClick="BtnAddNewPhoto_Click" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
