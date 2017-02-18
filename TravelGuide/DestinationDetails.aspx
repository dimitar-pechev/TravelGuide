<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DestinationDetails.aspx.cs" Inherits="TravelGuide.DestinationDetails" %>

<asp:Content ID="DestiantionDetails" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container destinations-details-container">
        <div class="row">
            <asp:Image ImageUrl="" ID="CoverPhoto" CssClass="cover-picture" runat="server" />
        </div>
        <h3 class="text-center" runat="server" id="DetailsHeading"><%: this.article.City %>, <%: this.article.Country %></h3>
        <hr />
        <div class="row text-center">
            <ul class="list-inline list-content-topics">
                <li><a href="#about"><span class="glyphicon glyphicon-globe"></span>About</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-camera"></span>Must-See Places</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-euro"></span>Budget Tips</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-home"></span>Accomodation</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-comment"></span>Comments</a></li>
            </ul>
            <hr />
        </div>
        <div class="row article-text">
            <img src="<%: this.article.PrimaryImageUrl %>" class="thumbnail thumb-photo img-responsive" alt="Alternate Text" />
            <p id="about"><%:this.article.Title %></p>
            <%: this.article.ContentMain %>
        </div>
    </div>
</asp:Content>


