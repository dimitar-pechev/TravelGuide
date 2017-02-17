using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.Data;

namespace TravelGuide
{
    public partial class CitiesAndSites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new TravelGuideContext();
            this.ListViewDestinations.DataSource = context.Articles.ToList();
            this.ListViewDestinations.DataBind();
        }
    }
}