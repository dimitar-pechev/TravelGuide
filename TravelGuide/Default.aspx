<%@ Page Title="Travel Guide" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelGuide._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <img src="/Images/boka-kotorska-1920x890.jpg" class="img-responsive landing-page-image" alt="boka-kotorska" />
    <div class="container">
        <div class="card card-main-page">
            <div class="card-content text-center">
                <h4>Get the best tips on your vacation</h4>
                <div class="row">
                    <div class="col-md-4">
                        <asp:HyperLink NavigateUrl="/Articles/CitiesAndSites" runat="server">
                        <div class="card card-nav">
                            <div class="card-content img-cont">
                                <img src="/Images/1.jpg" class="img-responsive" alt="Alternate Text" />
                            </div>
                            <div class="card-content text-center">
                                <p>Read on our destinations</p>
                            </div>
                        </div>
                        </asp:HyperLink>
                    </div>
                    <div class="col-md-4">
                        <asp:HyperLink NavigateUrl="/Gallery/AllPhotos" runat="server">
                        <div class="card card-nav">
                            <div class="card-content img-cont">
                                <img src="/Images/2.jpg" class="img-responsive" alt="Alternate Text" />
                            </div>
                            <div class="card-content text-center">
                                <p>Share with us your photos</p>
                            </div>
                        </div>
                        </asp:HyperLink>
                    </div>
                    <div class="col-md-4">
                        <asp:HyperLink NavigateUrl="/Store/AllItems" runat="server">
                        <div class="card card-nav">
                            <div class="card-content img-cont">
                                <img src="/Images/3.jpg" class="img-responsive" alt="Alternate Text" />
                            </div>
                            <div class="card-content text-center">
                                <p>Browse through our trip products</p>
                            </div>
                        </div>
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
