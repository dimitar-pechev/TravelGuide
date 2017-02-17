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
        </div>
    </div>
    <hr />
</asp:Content>
