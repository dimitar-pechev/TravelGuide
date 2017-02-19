﻿<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPhotos.aspx.cs" Inherits="TravelGuide.Gallery.AllPhotos" %>

<asp:Content ID="GalleryMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <asp:Image ImageUrl="~/Images/gallery-cover.png" CssClass="img-responsive" runat="server" />
    </div>
    <div class="container gallery-container">
        <asp:ListView runat="server" ID="ListViewGalleryItem"
            ItemType="TravelGuide.Models.Gallery.GalleryImage">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card gallery-item">
                        <div class="card-content">
                            <asp:Image ImageUrl="<%#: BindItem.ImageUrl %>" ID="ImageUrl" runat="server" CssClass="img-responsive gallery-image-image" />
                        </div>
                        <div class="card-content gallery-image-footer">
                            <div class="image-title col-md-9">
                                <asp:Label Text="<%#: BindItem.Title %>" runat="server" ID="ImageTitle" />
                            </div>
                            <div class="image-comments-likes col-md-3">
                                <div class="col-md-6">
                                    <span class="glyphicon glyphicon-thumbs-up"></span> <asp:Label Text="<%#: BindItem.Likes.Count %>" runat="server" ID="Likes" />
                                </div>
                                <div class="col-md-6">
                                    <span class="glyphicon glyphicon-comment"></span> <asp:Label Text="<%#: BindItem.Comments.Count %>" runat="server" ID="Comments" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>