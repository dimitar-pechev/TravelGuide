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
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The title field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleTitle"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The title length can be between 2 and 30 symbols!" 
                            ControlToValidate="ArticleTitle" runat="server" Display="Dynamic" CssClass="error-message"
                             ValidationExpression="^[0-9a-zA-Z !\.?,]{2,30}$"/>
                        <asp:TextBox runat="server" ID="ArticleTitle" />

                        <br />
                        
                        <asp:Label Text="Country" runat="server" AssociatedControlID="ArticleCountry" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The country field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleCountry"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The country name length can be between 2 and 30 symbols!" 
                            ControlToValidate="ArticleCountry" runat="server" Display="Dynamic" CssClass="error-message"
                             ValidationExpression="^[0-9a-zA-Z !\.?,]{2,30}$"/>
                        <asp:TextBox runat="server" ID="ArticleCountry" /><br />

                        <asp:Label Text="City" runat="server" AssociatedControlID="ArticleCity" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The city field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleCity"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The city name length can be between 2 and 30 symbols!" 
                            ControlToValidate="ArticleCity" runat="server" Display="Dynamic" CssClass="error-message"
                             ValidationExpression="^[0-9a-zA-Z !\.?,]{2,30}$"/>
                        <asp:TextBox runat="server" ID="ArticleCity" /><br />

                        <asp:Label Text="Main Picture Url" AssociatedControlID="ArticleImageUrl" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="The main picture field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleImageUrl"
                            Display="Dynamic" runat="server" />
                        <asp:TextBox runat="server" ID="ArticleImageUrl" />
                    </div>
                    <div class="col-md-8">
                        <asp:RequiredFieldValidator ErrorMessage="The content field cannot be left blank!" CssClass="error-message" ControlToValidate="ArticleContent"
                            Display="Dynamic" runat="server" />
                        <asp:RegularExpressionValidator ErrorMessage="The content of the article must be between 50 and 5000 symbols!" 
                            ControlToValidate="ArticleContent" runat="server" Display="Dynamic" CssClass="error-message"
                             ValidationExpression="^[^\s]{50,5000}$"/>
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
