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
                    <asp:UpdatePanel runat="server" UpdateMode="Always">
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
                    <asp:UpdatePanel runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <h4><%: Action %></h4>
                            <div runat="server" id="PanelRequest" visible="false">
                                <asp:ListView runat="server" ID="ListViewRequests" ItemType="TravelGuide.Models.Requests.Request">
                                    <LayoutTemplate>
                                        <table class="table table-bordered table-hover">
                                            <thead>
                                                <th></th>
                                                <th>Name</th>
                                                <th>Status</th>
                                                <th>Ordered On</th>
                                            </thead>
                                            <tbody>
                                                <span runat="server" id="itemPlaceholder"></span>
                                            </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <img class="img-request-profile" src=" <%#: Item.StoreItem.ImageUrl %>" runat="server" id="ImageRequest" alt="image" />
                                            </td>
                                            <td><%#: Item.StoreItem.ItemName %></td>
                                            <td><%#: Item.Status %></td>
                                            <td><%#: Item.CreatedOn.ToShortDateString() %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                                <div class="pager-profile">
                                    <asp:DataPager ID="DataPagerRequests" runat="server"
                                        PagedControlID="ListViewRequests" PageSize="3"
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <p runat="server" id="ResultLabel" visible="false" style="color: red;">Profile updated successfully!</p>
                            <div id="EditProfilePanel" runat="server" visible="false" class="text-center">
                                <asp:Label Text="First Name" runat="server" AssociatedControlID="FirstNameEdit" />
                                <asp:TextBox runat="server" ID="FirstNameEdit" />
                                <br />
                                <asp:Label Text="Last Name" runat="server" AssociatedControlID="LastNameEdit" />
                                <asp:TextBox runat="server" ID="LastNameEdit" />
                                <br />
                                <asp:Label Text="Phone" runat="server" AssociatedControlID="PhoneEdit" />
                                <asp:TextBox runat="server" ID="PhoneEdit" TextMode="Number" />
                                <br />
                                <asp:Label Text="Addres" runat="server" AssociatedControlID="AddressEdit" />
                                <asp:TextBox runat="server" ID="AddressEdit" />
                                <asp:Button Text="Submit" runat="server" ID="BtnSubmitNeProfileInfo" OnClick="BtnSubmitNeProfileInfo_Click" CssClass="btn btn-success btn-login" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
