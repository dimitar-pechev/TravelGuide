using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Models.Store;
using TravelGuide.Services.Requests.Contracts;
using TravelGuide.Services.Store.Contracts;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide
{
    public partial class Cart : Page
    {
        private const string CookieName = "store-items";
        private readonly IStoreService storeService;
        private readonly ICartService cartService;
        private readonly IRequestService requestService;
        private readonly IUserService userService;

        public Cart()
        {
            this.storeService = NinjectWebCommon.Kernel.Get<IStoreService>();
            this.cartService = NinjectWebCommon.Kernel.Get<ICartService>();
            this.requestService = NinjectWebCommon.Kernel.Get<IRequestService>();
            this.userService = NinjectWebCommon.Kernel.Get<IUserService>();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies[CookieName + this.User.Identity.Name];
            var items = this.cartService.extractItemsFromCookie(cookie);

            if (items.Count() == 0)
            {
                this.NoItemsTemplate.Visible = true;
                this.HasItemsTemplate.Visible = false;
            }

            this.TotalPrice.Text = this.GetPrice(items);

            this.GridViewCartItems.DataSource = items;
            this.GridViewCartItems.DataBind();

            var user = this.userService.GetByUsername(this.User.Identity.Name);
            this.FirstName.Text = user.FirstName;
            this.LastName.Text = user.LastName;
            this.PhoneNumber.Text = user.PhoneNumber;
            this.Address.Text = user.Address;
        }

        protected void GridViewCartItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewCartItems.PageIndex = e.NewPageIndex;
        }

        protected void GridViewCartItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = string.Empty;
            foreach (var item in e.Keys.Values)
            {
                id = item.ToString();
            }

            var cookie = this.Request.Cookies[CookieName + this.User.Identity.Name];
            var newCookie = this.cartService.DeleteItemFromCookie(cookie, id);
            this.Response.Cookies.Add(newCookie);

            var items = this.cartService.extractItemsFromCookie(newCookie);

            if (items.Count() == 0)
            {
                this.NoItemsTemplate.Visible = true;
                this.HasItemsTemplate.Visible = false;
            }

            this.TotalPrice.Text = this.GetPrice(items);

            this.GridViewCartItems.DataSource = items;
            this.GridViewCartItems.DataBind();
        }

        private string GetPrice(IEnumerable<StoreItem> items)
        {
            var sum = 0d;
            foreach (var item in items)
            {
                sum += item.Price;
            }

            return $"Total: {sum} BGN";
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            var items = this.cartService.extractItemsFromCookie(this.Request.Cookies[CookieName + this.User.Identity.Name]);
            var username = this.User.Identity.Name;

            var firstName = this.FirstName.Text;
            var lastName = this.LastName.Text;
            var phone = this.PhoneNumber.Text;
            var address = this.Address.Text;

            foreach (var item in items)
            {
                this.requestService.MakeRequest(item, username, firstName, lastName, phone, address);
            }

            var cookie = this.cartService.GetClearedCookie(this.User.Identity.Name);
            this.Response.Cookies.Add(cookie);

            this.ReceivedOrder.Visible = true;
            this.HasItemsTemplate.Visible = false;
        }
    }
}