<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllPhotos.aspx.cs"
    Inherits="TravelGuide.Gallery.AllPhotos" EnableEventValidation="false" %>

<asp:Content ID="GalleryMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <asp:Image ImageUrl="~/Images/gallery-cover.png" CssClass="img-responsive" runat="server" />
    </div>
    <div class="container gallery-container">
        <div class="row">
            <div class="row text-right button-row">
                <asp:HyperLink NavigateUrl="~/Gallery/AddPhoto.aspx" CssClass="btn btn-success" Text="Add new photo" runat="server" />
            </div>
            <asp:ListView runat="server" ID="ListViewGalleryItem" DataKeyNames="Id"
                ItemType="TravelGuide.Models.Gallery.GalleryImage">
                <ItemTemplate>
                    <div class="col-md-4">
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/Gallery/Details.aspx?id={0}", Item.Id) %>' runat="server">
                            <div class="card gallery-item" runat="server">
                                <div class="card-content"> 
                                    <asp:Image ImageUrl="<%#: Item.ImageUrl %>" ID="ImageUrl" runat="server" CssClass="img-responsive gallery-image-image" />
                                </div>
                                <div class="card-content gallery-image-footer">
                                    <div class="image-title col-md-9">
                                        <asp:Label Text="<%#: Item.Title %>" runat="server" ID="ImageTitle" />
                                    </div>
                                    <div class="image-comments-likes col-md-3">
                                        <div class="col-md-6">
                                            <span class="glyphicon glyphicon-thumbs-up"></span>
                                            <asp:Label Text="<%#: Item.Likes.Count %>" runat="server" ID="Likes" />
                                        </div>
                                        <div class="col-md-6">
                                            <span class="glyphicon glyphicon-comment"></span>
                                            <asp:Label Text="<%#: Item.Comments.Count %>" runat="server" ID="Comments" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="row text-center gallery-pager">
            <asp:DataPager ID="DataPagerGallery" runat="server"
                PagedControlID="ListViewGalleryItem" PageSize="9"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="false"
                        ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<" ButtonCssClass="btn-page" />
                    <asp:NumericPagerField NumericButtonCssClass="btn-page" CurrentPageLabelCssClass="btn-page btn-page-active" />
                    <asp:NextPreviousPagerField ShowLastPageButton="false"
                        ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText=">" ButtonCssClass="btn-page" />
                </Fields>
            </asp:DataPager>
        </div>
    </div>
</asp:Content>
