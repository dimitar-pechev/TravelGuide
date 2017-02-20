<%@ Page Title="Online Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllItems.aspx.cs" Inherits="TravelGuide.Store.AllItems" %>

<asp:Content ID="StroeMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <img src="/Images/shop-cover.png" alt="maps-shop" class="img-responsive" />
    </div>
    <div class="container store-container">
        <div class="row">
            <div class="row menu-store">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="col-md-4 col-md-offset-4 text-center">
                            <asp:Label Text="Search throgh our products:" AssociatedControlID="SearchBarDiscover" CssClass="search-label-discover" runat="server" />
                            <br />
                            <asp:TextBox runat="server" ID="SearchBarDiscover" OnTextChanged="SearchBarDiscover_TextChanged" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-4 text-right">
                    <asp:HyperLink NavigateUrl="~/Store/AddItem.aspx" CssClass="btn btn-success" Text="Add new product" runat="server" />
                </div>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row text-center" runat="server" id="NoResultsPanel" visible="false">
                        <p>No products were found... Try something else!</p>
                    </div>
                    <asp:ListView runat="server" ID="ListViewStoreItems" DataKeyNames="Id"
                        ItemType="TravelGuide.Models.Store.StoreItem">
                        <ItemTemplate>
                            <div class="col-md-2">
                                <asp:HyperLink NavigateUrl='<%#: string.Format("~/Store/Details.aspx?id={0}", Item.Id) %>' runat="server">
                                    <div class="card store-item" runat="server">
                                        <div class="card-content picture-placeholder">
                                            <asp:Image ImageUrl="<%#: Item.ImageUrl %>" ID="ImageUrl" runat="server"
                                                CssClass="img-responsive store-item-image" />
                                        </div>
                                        <div class="card-content store-item-footer text-center">
                                            <asp:Label CssClass="item-title" Text="<%#: Item.ItemName %>" runat="server" />
                                            <br />
                                            <i>
                                                <asp:Label Text="<%#: Item.Brand %>" runat="server" />
                                            </i>
                                            <br />
                                            <asp:Label Text='<%#: string.Format($"{Item.Price} BGN") %>' runat="server" />
                                            <br />
                                            <asp:Label Text='<%#: Item.InStock ? "In Stock" : "Depleted" %>' runat="server" />
                                        </div>
                                    </div>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row text-center gallery-pager">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:DataPager ID="DataPagerStore" runat="server"
                        PagedControlID="ListViewStoreItems" PageSize="12"
                        QueryStringField="page">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="false"
                                ShowNextPageButton="false" ShowPreviousPageButton="true" PreviousPageText="<" ButtonCssClass="btn-page" />
                            <asp:NumericPagerField NumericButtonCssClass="btn-page" CurrentPageLabelCssClass="btn-page btn-page-active" />
                            <asp:NextPreviousPagerField ShowLastPageButton="false"
                                ShowNextPageButton="true" ShowPreviousPageButton="false" NextPageText=">" ButtonCssClass="btn-page" />
                        </Fields>
                    </asp:DataPager>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
