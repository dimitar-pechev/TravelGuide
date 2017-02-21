<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs"
    Inherits="TravelGuide.Gallery.Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <asp:Image ImageUrl="~/Images/gallery-cover.png" CssClass="img-responsive" runat="server" />
    </div>
    <div class="container gallery-container">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="thumbnail">
                    <asp:Image ImageUrl="<%#: Image.ImageUrl %>" CssClass="modal-image" runat="server" />
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-6 text-left">
                        <p><%#: Image.Title  %></p>
                    </div>
                    <div class="col-md-6 text-right">
                        <asp:Button Text='<%# string.Format("Like (" + Image.Likes.Count + ")") %>' runat="server" CssClass="btn btn-success btn-sm btn-gallery" ID="Button1"
                            OnClick="BtnLikeImage_Click" />
                        <asp:Button Text='<%#: string.Format("Comments (" + Image.Comments.Count + ")") %>' runat="server" CssClass="btn btn-success btn-sm btn-gallery" ID="Button2"
                            OnClick="BtnCommentImage_Click" />
                        <asp:Button Text="Delete" CssClass="btn btn-danger btn-sm btn-gallery" ID="Button3"
                            OnClick="BtnDeleteImage_Click" runat="server" />
                    </div>
                </div>
                <asp:Panel runat="server" ID="CommentsPanel" Visible="false">
                    <hr />
                    <asp:ListView runat="server" ID="ListViewGalleryComments" OnItemDeleting="ListViewGalleryComments_ItemDeleting"
                        ItemType="TravelGuide.Models.Gallery.GalleryComment" DataKeyNames="Id">
                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>
                        <EmptyDataTemplate>
                            <div class="row">
                                <p class="text-center">Be the first to comment...</p>
                            </div>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <div class="card">
                                <div class="card-content">
                                    <p class="text-center">
                                        <asp:Label Text='<%#: Item.Content %>' runat="server" />
                                    </p>
                                    <div class="text-right">
                                        <asp:Button Text="Delete" CommandName="Delete" ID="BtnDeleteGalleryComment"
                                            CssClass="pull-left btn btn-danger btn-sm" runat="server" />
                                        <asp:Label Text='<%#: Item.User.UserName %>' runat="server" />
                                        <br />
                                        <asp:Label Text='<%#: Item.CreatedOn %>' runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    <div class="row text-center">
                        <asp:Button Text="Comment!" CssClass="btn btn-success btn-login" ID="BtnRevelCommentModal"
                            data-toggle="modal" data-target="#comment-box" runat="server" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
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
</asp:Content>
