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
    public partial class EditItem : Page
    {
        private readonly IStoreService service;

        public EditItem()
        {
            this.service = NinjectWebCommon.Kernel.Get<IStoreService>();
        }

        public static StoreItem Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            this.BindToNewData();

            this.NewItemName.Text = Item.ItemName;
            this.NewItemDescription.Value = Item.Description;
            this.NewItemDestFor.Text = Item.DestinationFor;
            this.NewItemImageUrl.Text = Item.ImageUrl;
            this.NewItemBrand.Text = Item.Brand;
            this.NewItemPrice.Text = Item.Price.ToString();
        }

        protected void BtnEditItem_Click(object sender, EventArgs e)
        {
            var itemName = this.NewItemName.Text;
            var description = this.NewItemDescription.Value;
            var destFor = this.NewItemDestFor.Text;
            var imageUrl = this.NewItemImageUrl.Text;
            var brand = this.NewItemBrand.Text;
            var price = this.NewItemPrice.Text;

            var isSusccessful = this.service.EditItem(Item, itemName, description, destFor, imageUrl, brand, price);

            if (!isSusccessful)
            {
                this.ErrorMessage.Visible = true;
                return;
            }

            this.Response.Redirect($"~/Store/Details.aspx?id={Item.Id}");
        }

        private void BindToNewData()
        {
            try
            {
                var id = this.Request.QueryString["id"];
                var parsedId = Guid.Parse(id);
                Item = this.service.GetStoreItemById(parsedId);
            }
            catch (Exception)
            {
                this.Response.Redirect("~/Store/AllItems.aspx");
            }
        }
    }
}
