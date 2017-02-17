<%@ Page Title="Add New Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="TravelGuide.AddArticle" %>

<asp:Content ID="AddArticle" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row discover-heading">
        <img src="/Images/destinations-heading.png" class="img-responsive" alt="heading" />
    </div>
    <div class="container">
        <div class="card card-add-article">
            <div class="card-content">
                <h4 class="text-center">Add a New Article</h4>
            </div>
            <hr />
            <div class="card-content">
                <div class="row">
                    <div class="col-md-4 text-center">
                        <asp:Label Text="Title" runat="server" AssociatedControlID="ArticleTitle" />
                        <asp:TextBox runat="server" ID="ArticleTitle" />
                        <br />

                        <asp:Label Text="Country" runat="server" AssociatedControlID="ArticleCountry" />
                        <asp:TextBox runat="server" ID="ArticleCountry" /><br />

                        <asp:Label Text="City" runat="server" AssociatedControlID="ArticleCity" />
                        <asp:TextBox runat="server" ID="ArticleCity" /><br />

                        <asp:Label Text="Main Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <asp:TextBox runat="server" ID="ArticleImageUrl" />
                    </div>
                    <div class="col-md-8">
                        <textarea runat="server" placeholder="Article text goes here..." class="form-control" rows="15" id="ArticleContent" />
                    </div>
                </div>
                <div class="row text-center">
                    <asp:Button Text="Submit" CssClass="btn btn-success btn-login" ID="BtnSubmitNewArticle" OnClick="BtnSubmitNewArticle_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
