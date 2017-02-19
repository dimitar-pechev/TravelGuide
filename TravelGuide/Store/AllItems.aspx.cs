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
            this.ListViewStoreItems.DataSource = this.service.GetAllNotDeletedStoreItemsOrderedByDate();
            this.ListViewStoreItems.DataBind();
        }
    }
}