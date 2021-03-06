﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TravelGuide.Account.Register" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-10 col-md-offset-1">
                <div class="col-md-6 col-md-offset-3 text-center">
                    <div class="card login-form">
                        <div class="card-content">
                            <div class="form-horizontal">
                                <h4>Register</h4>
                                <hr />
                                <p class="text-danger small error-message">
                                    <asp:Literal runat="server" ID="ErrorMessage" />
                                </p>
                                <asp:ValidationSummary runat="server" CssClass="text-danger small" />
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Username" CssClass="control-label">Username</asp:Label>
                                    <asp:TextBox runat="server" ID="Username" CssClass="" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The username field is required." />
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="control-label">E-Mail</asp:Label>
                                    <asp:TextBox runat="server" ID="Email" CssClass="" TextMode="Email" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The E-Mail field is required." />
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                </div>
                                <div class="form-group">
                                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-success btn-login" />
                                </div>
                                <section id="socialLoginForm">
                                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                                </section>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
