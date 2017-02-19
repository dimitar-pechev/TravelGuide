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
        private IStoreService service;

        public Details()
        {
            this.service = NinjectWebCommon.Kernel.Get<IStoreService>();
        }

        public StoreItem StoreItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = GetGuidFromString(this.Request.QueryString["id"]);
                this.StoreItem = this.service.GetStoreItemById(id);
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
    }
}