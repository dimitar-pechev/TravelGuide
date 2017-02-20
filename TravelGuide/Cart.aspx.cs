using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.Store.Contracts;

namespace TravelGuide
{
    public partial class Cart : Page
    {
        private const string CookieName = "store-items";
        private readonly IStoreService storeService;
        private readonly ICartService cartService;
       
        public Cart()
        {
            this.storeService = NinjectWebCommon.Kernel.Get<IStoreService>();
            this.cartService = NinjectWebCommon.Kernel.Get<ICartService>();
        }

        public int ItemsCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies[CookieName];
            var items = this.cartService.extractItemsFromCookie(cookie);
            this.ItemsCount = items.Count();
            this.DataBind();
        }
    }
}