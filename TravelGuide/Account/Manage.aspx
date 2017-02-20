<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="TravelGuide.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container profile-container">
        <img src="/Images/1487625596_profle.png" alt="profile-picture" class="profile-picture img-circle" id="ProfilePic" runat="server" />
        <div class="card card-profile">
            <div class="card-content">
                <div class="col-md-6 text-center">
                    <h4>
                        <%: $"Welcome, {this.User.Identity.Name}!" %>
                    </h4>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button Text="Show Requests" CssClass="btn btn-login btn-primary" ID="BtnShowRequests" OnClick="BtnShowRequests_Click" runat="server" />
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Change Password" CssClass="btn btn-login btn-primary" Visible="false" ID="ChangePassword" runat="server" />
                            <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="Create a Password" CssClass="btn btn-login btn-primary" Visible="false" ID="CreatePassword" runat="server" />
                            <asp:Button Text="Edit Profile" CssClass="btn btn-login btn-primary" ID="BtnShowEditProfile" OnClick="BtnShowEditProfile_Click" runat="server" />
                            <asp:Button Text="Change Profile Picture" CssClass="btn btn-login btn-primary" ID="BtnShowUploadPicture" OnClick="BtnUploadPicture_Click" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-6 text-center">
                    <h4>Options</h4>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
