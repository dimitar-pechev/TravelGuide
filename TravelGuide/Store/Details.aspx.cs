using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Models.Store;
using TravelGuide.Services.Store.Contracts;

namespace TravelGuide.Store
{
    public partial class Details : Page
    {
        private const string CookieName = "store-items";
        private readonly IStoreService storeService;
        private readonly ICartService cartService;

        public Details()
        {
            this.storeService = NinjectWebCommon.Kernel.Get<IStoreService>();
            this.cartService = NinjectWebCommon.Kernel.Get<ICartService>();
        }

        public StoreItem StoreItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = GetGuidFromString(this.Request.QueryString["id"]);
                this.StoreItem = this.storeService.GetStoreItemById(id);
                if (StoreItem.InStock)
                {
                    this.BuyDetails.Visible = true;
                }
                else
                {
                    this.BuyDetails.Visible = false;
                }

                this.DataBind();
            }
            catch (Exception)
            {
                this.Response.Redirect("~/Store/AllItems.aspx");
            }
        }

        private Guid GetGuidFromString(string str)
        {
            var id = Guid.Parse(str);
            return id;
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            var cookiePrev = this.Request.Cookies[CookieName + this.User.Identity.Name];
            var cookie = this.cartService.WriteCookie(cookiePrev, this.User.Identity.Name, this.StoreItem.Id.ToString());
            this.Response.Cookies.Add(cookie);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            this.storeService.DeleteItem(StoreItem.Id);
            this.Response.Redirect("~/Store/AllItems.aspx");
        }

        protected void BtnSubmitStatusChange_Click(object sender, EventArgs e)
        {
            var status = this.StatusOptions.SelectedValue;
            this.storeService.ChangeStatus(StoreItem.Id, status);
            StoreItem = this.storeService.GetStoreItemById(StoreItem.Id);
            this.DataBind();

            if (StoreItem.InStock)
            {
                this.BuyDetails.Visible = true;
            }
            else
            {
                this.BuyDetails.Visible = false;
            }
        }
    }
}