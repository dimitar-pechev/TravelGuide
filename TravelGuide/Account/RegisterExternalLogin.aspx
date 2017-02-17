<%@ Page Title="Register an external login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="TravelGuide.Account.RegisterExternalLogin" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-10 col-md-offset-1">
                <div class="col-md-6 col-md-offset-3 text-center">
                    <div class="card login-form">
                        <div class="card-content">
                            <asp:PlaceHolder runat="server">
                                <div class="form-horizontal">
                                    <h4>Register with your <%: ProviderName %> account</h4>
                                    <hr />
                                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                                    <p class="text-info">
                                        You've authenticated with <strong><%: ProviderName %></strong>. Please enter a username below for the current site
                and click the Sign in button.
                                    </p>
                                    <div class="form-group">
                                        <asp:Label runat="server" AssociatedControlID="Username" CssClass="control-label">Username</asp:Label>
                                        <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                            Display="Dynamic" CssClass="text-danger" ErrorMessage="Username is required" />
                                    </div>
                                    <div class="form-group">
                                        <asp:Button runat="server" Text="Sing in" CssClass="btn btn-success btn-login" OnClick="LogIn_Click" />
                                    </div>
                                </div>
                            </asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
