<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="Admin.aspx.cs" Inherits="TravelGuide.Admin.Admin" %>

<asp:Content ID="AdminPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container admin-container">
        <h3 class="text-center">Admin Panel</h3>
        <div class="bs-example bs-example-tabs" data-example-id="togglable-tabs">
            <ul class="nav nav-tabs" id="myTabs" role="tablist">
                <li role="presentation" class="active">
                    <a href="#users" id="users-tab" role="tab" data-toggle="tab" aria-controls="users" aria-expanded="true">Users</a>
                </li>
                <li role="presentation" class="">
                    <a href="#requests" role="tab" id="requests-tab" data-toggle="tab" aria-controls="requests" aria-expanded="false">Orders</a>
                </li>
            </ul>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade active in" role="tabpanel" id="users" aria-labelledby="users-tab">
                            <asp:ListView runat="server" ID="ListViewUsers" ItemType="TravelGuide.Models.User" OnItemDeleting="ListViewUsers_ItemDeleting">
                                <LayoutTemplate>
                                    <table class="table table-responsive table-bordered table-hover">
                                        <thead>
                                            <th>Username</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Phone</th>
                                            <th>Address</th>
                                            <th>Status</th>
                                            <th></th>
                                        </thead>
                                        <tbody>
                                            <span runat="server" id="itemPlaceholder"></span>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#: Item.UserName %></td>
                                        <td><%#: Item.FirstName %></td>
                                        <td><%#: Item.LastName %></td>
                                        <td><%#: Item.PhoneNumber %></td>
                                        <td><%#: Item.Address %></td>                                        
                                        <td><%#: Item.IsDeleted ? "Banned" : "Active"  %></td>
                                        <td class="text-center">
                                            <asp:Button Text="Delete" CommandName="Delete" Visible="<%# !Item.IsDeleted %>" CssClass="btn btn-danger btn-sm" ID="BtnDeactivateAccount" runat="server" />
                                            <asp:Button Text="Restore" Visible="<%# Item.IsDeleted %>" CssClass="btn btn-success btn-sm" ID="BtnRestore" OnClick="BtnRestore_Click" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div class="tab-pane fade" role="tabpanel" id="requests" aria-labelledby="requests-tab">
                            <asp:ListView runat="server" ID="ListViewRequests" OnItemUpdating="ListViewRequests_ItemUpdating" DataKeyNames="Id"
                                 ItemType="TravelGuide.Models.Requests.Request">
                                <LayoutTemplate>
                                    <table class="table table-responsive table-bordered table-hover">
                                        <thead>
                                            <th>Item</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Phone</th>
                                            <th>Address</th>
                                            <th>Order Status</th>
                                            <th></th>
                                        </thead>
                                        <tbody>
                                            <span runat="server" id="itemPlaceholder"></span>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#: Item.StoreItem.ItemName %></td>
                                        <td><%#: Item.FirstName %></td>
                                        <td><%#: Item.LastName %></td>
                                        <td><%#: Item.Phone %></td>
                                        <td><%#: Item.Address %></td>
                                        <td><%#: Item.Status %></td>
                                        <td class="text-center">
                                            <asp:Button Text="Conifrm order" CommandName="Update" CssClass="btn btn-success btn-sm" ID="BtnChangeStatus" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
