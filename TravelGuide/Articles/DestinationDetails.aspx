﻿<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="DestinationDetails.aspx.cs" Inherits="TravelGuide.DestinationDetails" %>

<asp:Content ID="DestiantionDetails" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container destinations-details-container">
        <div class="row">
            <asp:Image ImageUrl="<%: this.Article.CoverImageUrl %>" ID="CoverPhoto" CssClass="cover-picture" runat="server" />
        </div>
        <h3 class="text-center" runat="server" id="DetailsHeading"><%: this.Article.City %>, <%: this.Article.Country %></h3>
        <hr />
        <div class="row text-center">
            <ul class="list-inline list-content-topics">
                <li><a href="#about"><span class="glyphicon glyphicon-globe"></span> About</a></li>
                <li><a href="#must-see"><span class="glyphicon glyphicon-camera"></span> Must-See Places</a></li>
                <li><a href="#tips"><span class="glyphicon glyphicon-euro"></span> Budget Tips</a></li>
                <li><a href="#accomodation"><span class="glyphicon glyphicon-home"></span> Accomodation</a></li>
                <li><a href="#comments"><span class="glyphicon glyphicon-comment"></span> Comments</a></li>
            </ul>
            <hr />
        </div>
        <div class="row article-text">
            <div class="col-md-4 article-aside">
                <div class="row">
                    <img src="<%: this.Article.PrimaryImageUrl %>" data-toggle="modal" data-target="#details-photo"
                        class="thumb-photo thumbnail thumb-photo-main img-responsive" alt="Alternate Text" />
                </div>
                <div class="row">
                    <hr />
                    <p class="text-center">From our store</p>
                    <asp:ListView runat="server" ID="ListViewRelated" ItemType="TravelGuide.Models.Store.StoreItem">
                        <EmptyDataTemplate>
                            <div class="text-center">
                                <asp:Label Text="There are currently no related products from the store..." CssClass="text-center" runat="server" />
                            </div>
                            <hr />
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <div class="magring-bottom">
                                <asp:HyperLink NavigateUrl='<%#: string.Format($"/Store/Details.aspx?id={Item.Id}") %>' runat="server">
                            <div class="card related-item-placeholder">
                                <div class="col-md-2 img-placeholder">
                                    <asp:Image CssClass="related-item-img" ImageUrl="<%#: Item.ImageUrl %>" runat="server" />
                                </div>
                                <div class="col-md-10">
                                    <asp:label text="<%#: Item.ItemName %>" runat="server" />
                                    <br />
                                    <asp:label text="<%#: Item.Brand %>" runat="server" />
                                </div>
                            </div>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            <p id="about"><span class="glyphicon glyphicon-globe"></span> <%:this.Article.Title %></p>
            <%: this.Article.ContentMain %>
        </div>
        <hr />
        <div class="row article-text">
            <img src="<%: this.Article.SecondImageUrl %>" data-toggle="modal" data-target="#details-photo"
                class="thumb-photo thumbnail thumb-photo-right img-responsive" alt="Alternate Text" />
            <p id="must-see"><span class="glyphicon glyphicon-camera"></span> The places you absolutely must visit in <%: this.Article.City %></p>
            <%: this.Article.ContentMustSee %>
        </div>
        <hr />
        <div class="row article-text">
            <p id="tips"><span class="glyphicon glyphicon-euro"></span> Our assessment on the budget needed...</p>
            <%: this.Article.ContentBudgetTips %>
        </div>
        <hr />
        <div class="row article-text">
            <img src="<%: this.Article.ThirdImageUrl %>" data-toggle="modal" data-target="#details-photo"
                class="thumb-photo thumbnail thumb-photo-left img-responsive" alt="Alternate Text" />
            <p id="accomodation"><span class="glyphicon glyphicon-home"></span> Finally, a few tips on the accomodation in <%: this.Article.City %></p>
            <%: this.Article.ContentAccomodation %>
        </div>
        <hr />
        <div runat="server" id="PanelEditDelete" class="text-right" visible="false">
            <asp:HyperLink Text="Edit" NavigateUrl="" ID="EditBtnLink" CssClass="btn btn-warning" runat="server" />
            <asp:Button Text="Delete" CssClass="btn btn-danger" ID="BtnDeleteArticle" OnClick="BtnDeleteArticle_Click" runat="server" />
            <hr />
        </div>
        <div id="comments" class="row comment-panel-dest">
            <h4 class="text-center"><span class="glyphicon glyphicon-comment"></span> Comments</h4>
            <hr />
            <asp:ListView runat="server" ID="ListViewArticleComments" DataKeyNames="Id" OnItemDeleting="ListViewArticleComments_ItemDeleting"
                ItemType="TravelGuide.Models.Articles.ArticleComment">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <div class="row">
                        <p class="text-center">Be the first to comment...</p>
                    </div>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="card comment-box">
                        <div class="card-content">
                            <p class="text-center">
                                <asp:Label Text='<%#: Item.Content %>' runat="server" />
                            </p>
                            <div class="text-right">
                                <asp:Button Text="Delete" ID="BtnDeleteComment" Visible='<%# this.User.IsInRole("admin") ? true : false %>' CommandName="Delete"
                                    CssClass="pull-left btn btn-sm btn-danger" runat="server" />
                                <asp:Label Text='<%#: Item.User.UserName %>' runat="server" />
                                <br />
                                <asp:Label Text='<%#: Item.CreatedOn %>' runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <div class="row text-center">
                <asp:Button Text="Comment!" CssClass="btn btn-success btn-login" ID="BtnRevelCommentModal" Visible="false"
                    data-toggle="modal" data-target="#comment-box" runat="server" />
            </div>
        </div>
    </div>
    <script>
        var shiftWindow = function () { scrollBy(0, -75) };
        if (location.hash) shiftWindow();
        window.addEventListener("hashchange", shiftWindow);

        $('.thumb-photo').on('click', (e) => {
            $('#details-img-modal').attr('src', $(e.target).attr('src'));
        })
    </script>

    <%--comments modal--%>
    <div class="modal fade" id="comment-box" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <p>Type your comment here...</p>
                </div>
                <div class="modal-body">
                    <textarea runat="server" id="NewCommentContent" rows="3" class="form-control" />
                </div>
                <div class="modal-footer footer-comment">
                    <asp:Button Text="Submit" CssClass="btn btn-success btn-gallery" ID="BtnSubmitNewComment" OnClick="BtnSubmitNewComment_Click" runat="server" />
                    <asp:Button Text="Discard" CssClass="btn btn-danger btn-gallery" data-dismiss="modal" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <%--photos modal--%>
    <div class="modal fade" id="details-photo" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <img src="" id="details-img-modal" class="img-responsive" alt="picture.title">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
