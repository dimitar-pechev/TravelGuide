<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TravelGuide.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-10 col-md-offset-1">
                <div class="col-md-6 col-md-offset-3 text-center">
                    <div class="card login-form">
                        <div class="card-content">
                            <section id="loginForm">
                                <div class="form-horizontal">
                                    <h4>Sign in</h4>
                                    <hr />
                                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                        <p class="text-danger error-message">
                                            <asp:Literal runat="server" ID="FailureText" />
                                        </p>
                                    </asp:PlaceHolder>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">Email</asp:Label>
                                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The email field is required." />
                                    </div>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic"
                                             ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                                    </div>
                                    <div class="form-group hidden">
                                        <div class="checkbox">
                                            <asp:CheckBox runat="server" ID="RememberMe" />
                                            <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button runat="server" OnClick="LogIn" Text="Sing in" CssClass="btn btn-default btn-login" />
                                    </div>
                                </div>
                                <p class="hidden">
                                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                                </p>
                                <section id="socialLoginForm">
                                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                                </section>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
