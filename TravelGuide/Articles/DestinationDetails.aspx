<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DestinationDetails.aspx.cs" Inherits="TravelGuide.DestinationDetails" %>

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
                <li><a href="#"><span class="glyphicon glyphicon-comment"></span> Comments</a></li>
            </ul>
            <hr />
        </div>
        <div class="row article-text">
            <img src="<%: this.Article.PrimaryImageUrl %>" data-toggle="modal" data-target="#details-photo"
                 class="thumb-photo thumbnail thumb-photo-left img-responsive" alt="Alternate Text" />
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
    </div>
    <script>
        var shiftWindow = function () { scrollBy(0, -75) };
        if (location.hash) shiftWindow();
        window.addEventListener("hashchange", shiftWindow);

        $('.thumb-photo').on('click', (e) => {
            $('#details-img-modal').attr('src', $(e.target).attr('src'));
        })
    </script>
    
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
