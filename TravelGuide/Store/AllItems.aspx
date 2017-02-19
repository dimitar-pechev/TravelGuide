<%@ Page Title="Online Store" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllItems.aspx.cs" Inherits="TravelGuide.Store.AllItems" %>

<asp:Content ID="StroeMain" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row gallery-cover-container">
        <img src="/Images/shop-cover.png" alt="maps-shop" class="img-responsive" />
    </div>
    <div class="container store-container">
        <div class="row">
            <div class="row text-right button-row">
                <asp:HyperLink NavigateUrl="~/Store/AddItem.aspx" CssClass="btn btn-success" Text="Add new item" runat="server" />
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
        </div>
        <div class="row text-center gallery-pager">
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
        </div>
    </div>
</asp:Content>
