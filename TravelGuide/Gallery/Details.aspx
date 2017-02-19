<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="TravelGuide.Gallery.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                                    <asp:Image ImageUrl="<%#: "" %>" CssClass="modal-image" runat="server" />
                              
                                <div class="modal-footer">
                                    <div class="col-md-6 text-left">
                                        <p><%#:""  %></p>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <asp:Button Text='<%# string.Format("Like (" +   ")") %>' runat="server" CssClass="btn btn-success btn-sm btn-gallery" ID="BtnLikeImage"
                                            OnClick="BtnLikeImage_Click" />
                                        <asp:Button Text='<%#: string.Format("Comments (" + ")") %>' runat="server" CssClass="btn btn-success btn-sm btn-gallery" ID="BtnCommentImage"
                                            OnClick="BtnCommentImage_Click" />
                                        <asp:Button Text="Delete" CssClass="btn btn-danger btn-sm btn-gallery" ID="BtnDeleteImage"
                                            OnClick="BtnDeleteImage_Click" runat="server" />
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:ListView runat="server" ID="ListViewComments" ItemType="TravelGuide.Models.Gallery.GalleryComment">
                                        <ItemTemplate>
                                            <div class="card">
                                                <div class="card-content">
                                                    <p class="text-center">
                                                        <asp:Label Text='<%#: Item.Content %>' runat="server" />
                                                    </p>
                                                    <asp:Label Text='<%#: Item.User.UserName %>' runat="server" />
                                                    <asp:Label Text='<%#: Item.CreatedOn %>' runat="server" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                           
</asp:Content>
