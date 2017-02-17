﻿<%@ Page Title="Manage Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="TravelGuide.Account.ManagePassword" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row card-only">
            <div class="col-md-10 col-md-offset-1">
                <div class="col-md-6 col-md-offset-3 text-center">
                    <div class="card login-form">
                        <div class="card-content">
                            <h4>Set Password</h4>
                            <div class="form-horizontal">
                                <section id="passwordForm">
                                    <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                                        <p class="text-info">
                                            You do not have a local password for this site. Add a local
                        password so you can log in without an external login.
                                        </p>
                                        <div class="form-horizontal">
                                            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                                            <hr />
                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="password" CssClass="control-label">Password</asp:Label>
                                                <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                                    CssClass="text-danger" ErrorMessage="The password field is required."
                                                    Display="Dynamic" ValidationGroup="SetPassword" />
                                                <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                                    CssClass="text-danger" SetFocusOnError="true" />
                                            </div>

                                            <div class="form-group">
                                                <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="control-label">Confirm password</asp:Label>

                                                <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" CssClass="" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required."
                                                    ValidationGroup="SetPassword" />
                                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match."
                                                    ValidationGroup="SetPassword" />
                                            </div>
                                            <div class="form-group">
                                                <asp:Button runat="server" Text="Set Password" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-success btn-login" />
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                                        <div class="form-horizontal">
                                            <hr />
                                            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="control-label">Current password</asp:Label>
                                                <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                                    CssClass="text-danger" ErrorMessage="The current password field is required."
                                                    ValidationGroup="ChangePassword" />
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="control-label">New password</asp:Label>
                                                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                                    CssClass="text-danger" ErrorMessage="The new password is required."
                                                    ValidationGroup="ChangePassword" />
                                            </div>
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="control-label">Confirm new password</asp:Label>
                                                <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="" />
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                                    ValidationGroup="ChangePassword" />
                                                <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                                    ValidationGroup="ChangePassword" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button runat="server" Text="Change Password" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-success btn-login" />
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                </section>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
