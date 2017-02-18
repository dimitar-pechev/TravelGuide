<%@ Page Title="Add New Article" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArticle.aspx.cs" Inherits="TravelGuide.AddArticle" %>

<asp:Content ID="AddArticle" ContentPlaceHolderID="MainContent" runat="server">   
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
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The title field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleTitle"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The title length can be between 2 and 30 symbols! Only latin letters, numbers and basic pctuations signs are allowed!"
                            ControlToValidate="ArticleTitle" runat="server" Display="Dynamic" CssClass="error-message"
                            ValidationExpression="^[0-9a-zA-Z !\.?,-]{2,30}$" />
                        <asp:TextBox runat="server" ID="ArticleTitle" />

                        <br />

                        <asp:Label Text="Country" runat="server" AssociatedControlID="ArticleCountry" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The country field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleCountry"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The country name length can be between 2 and 30 symbols! Only latin letters and hyphens are allowed!"
                            ControlToValidate="ArticleCountry" runat="server" Display="Dynamic" CssClass="error-message"
                            ValidationExpression="^[a-zA-Z-]{2,30}$" />
                        <asp:TextBox runat="server" ID="ArticleCountry" /><br />

                        <asp:Label Text="City" runat="server" AssociatedControlID="ArticleCity" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The city field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleCity"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The city name length can be between 2 and 30 symbols! Only latin letters and hyphens are allowed!"
                            ControlToValidate="ArticleCity" runat="server" Display="Dynamic" CssClass="error-message"
                            ValidationExpression="^[a-zA-Z-]{2,30}$" />
                        <asp:TextBox runat="server" ID="ArticleCity" /><br />

                        <asp:Label Text="Main Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The main picture field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleImageUrl"
                            Display="Dynamic" runat="server" />
                        <asp:TextBox runat="server" ID="ArticleImageUrl" />
                        <br />
                        <asp:Label Text="Second Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The second picture field cannot be left blank!" CssClass="error-message" ControlToValidate="SecondPictureUrl"
                            Display="Dynamic" runat="server" />
                        <asp:TextBox runat="server" ID="SecondPictureUrl" />
                        <br />
                        <asp:Label Text="Third Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The third picture field cannot be left blank!" CssClass="error-message" ControlToValidate="ThirdPictureUrl"
                            Display="Dynamic" runat="server" />
                        <asp:TextBox runat="server" ID="ThirdPictureUrl" />
                        <br />
                        <asp:Label Text="Covet Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The cover picture field cannot be left blank!" CssClass="error-message" ControlToValidate="CoverPictureUrl"
                            Display="Dynamic" runat="server" />
                        <asp:TextBox runat="server" ID="CoverPictureUrl" />
                    </div>
                    <div class="col-md-8">
                        <asp:RequiredFieldValidator ErrorMessage="The main content field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleContentMain"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The main content of the article must be between 50 and 2000 symbols!"
                            ControlToValidate="ArticleContentMain" runat="server" Display="Dynamic" CssClass="error-message"
                            ValidationExpression="^.{50,5000}$" />
                        <textarea runat="server" placeholder="Main article content text goes here..." class="form-control text-area-content" rows="7" id="ArticleContentMain" />

                        <asp:RequiredFieldValidator ErrorMessage="The must-see places content field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleContentMustSee"
                            Display="Dynamic" runat="server" />
                        <textarea runat="server" placeholder="Must-see places info..." class="form-control text-area-content" rows="7" id="ArticleContentMustSee" />

                        <asp:RequiredFieldValidator ErrorMessage="The budget tips content field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleContentBudgetTips"
                            Display="Dynamic" runat="server" />                        
                        <textarea runat="server" placeholder="Budget tips info..." class="form-control text-area-content" rows="7" id="ArticleContentBudgetTips" />

                        <asp:RequiredFieldValidator ErrorMessage="The accomodation content field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleContentAccomodation"
                            Display="Dynamic" runat="server" />                        
                        <textarea runat="server" placeholder="Accomodation info..." class="form-control text-area-content" rows="7" id="ArticleContentAccomodation" />
                    </div>
                </div>
                <div class="row text-center">
                    <asp:Button Text="Submit" CssClass="btn btn-success btn-login" ID="BtnSubmitNewArticle" OnClick="BtnSubmitNewArticle_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
