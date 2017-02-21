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
    public partial class AllItems : Page
    {
        private readonly IStoreService service;

        public AllItems()
        {
            this.service = NinjectWebCommon.Kernel.Get<IStoreService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.IsInRole("admin"))
            {
                this.NewItemLink.Visible = true;
            }

            this.ListViewStoreItems.DataSource = this.service.GetAllNotDeletedStoreItemsOrderedByDate();
            this.ListViewStoreItems.DataBind();
        }

        protected void SearchBarDiscover_TextChanged(object sender, EventArgs e)
        {
            var items = this.service.GetItemsByKeyword(this.SearchBarDiscover.Text);

            if (items.Count() == 0)
            {
                this.NoResultsPanel.Visible = true;
            }
            else
            {
                this.NoResultsPanel.Visible = false;
            }

            this.ListViewStoreItems.DataSource = items;
            this.ListViewStoreItems.DataBind();
        }
    }
}