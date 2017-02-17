<%@ Page Title="Discover" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CitiesAndSites.aspx.cs" Inherits="TravelGuide.CitiesAndSites" %>

<asp:Content ID="CitiesAndSites" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row discover-heading">
        <img src="/Images/destinations-heading.png" class="img-responsive" alt="heading" />
    </div>
    <div class="container destinations-container">
        <div class="row">
            <div class="col-md-1 col-md-offset-3 text-right">
                <asp:Label Text="Search:" AssociatedControlID="SearchBarDiscover" CssClass="search-label-discover" runat="server" />
            </div>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="SearchBarDiscover" />
            </div>
            <div class="col-md-4 text-right">
                <asp:HyperLink NavigateUrl="~/AddArticle.aspx" CssClass="btn btn-success" Text="Add new article" runat="server" />
            </div>
        </div>
        <asp:ListView runat="server" ID="ListViewDestinations"
            ItemType="TravelGuide.Models.Articles.Article">
            <ItemTemplate>
                <div class="card destination-card">
                    <div class="card-content col-md-3 card-destinations-image">
                        <asp:Image ImageUrl="<%#: BindItem.ImageUrl %>" runat="server" ID="DestinationImage" />
                    </div>
                    <div class="card-content col-md-9 card-destinations-entry">
                        <asp:Label Text="<%#: BindItem.City %>" runat="server" ID="DestinationCity" CssClass="destinations-entry-city" />, 
                        <asp:Label Text="<%#: BindItem.Country %>" runat="server" ID="DestinationCountry" CssClass="destinations-entry-city" />
                        <br />
                        <asp:Label Text="<%#: BindItem.Title %>" runat="server" ID="DestinationTitle" CssClass="destinations-entry-title" />
                        <br />
                        <span class="destinations-entry-date">Posted on:
                            <asp:Label Text="<%#: BindItem.CreatedOn %>" runat="server" ID="DestinationDate" /></span>
                        <br />
                        <asp:Label Text="<%#: BindItem.Content %>" CssClass="destinations-entry-content" runat="server" ID="DestinationUser" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="text-center">
            <asp:DataPager ID="DataPagerDestinations" runat="server"
                PagedControlID="ListViewDestinations" PageSize="1"
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
