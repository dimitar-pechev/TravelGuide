using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.Store.Contracts;

namespace TravelGuide.Store
{
    public partial class AddItem : System.Web.UI.Page
    {
        private readonly IStoreService service;

        public AddItem()
        {
            this.service = NinjectWebCommon.Kernel.Get<IStoreService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewItem_Click(object sender, EventArgs e)
        {
            var itemName = this.NewItemName.Text;
            var description = this.NewItemDescription.Value;
            var destFor = this.NewItemDestFor.Text;
            var imageUrl = this.NewItemImageUrl.Text;
            var brand = this.NewItemBrand.Text;
            var price = this.NewItemPrice.Text;

            var isSuccessful = this.service.AddNewItem(itemName, description, destFor, imageUrl, brand, price);

            if (!isSuccessful)
            {
                this.ErrorMessage.Visible = true;
                return;
            }

            this.Response.Redirect("~/Store/AllItems.aspx");
        }
    }
}