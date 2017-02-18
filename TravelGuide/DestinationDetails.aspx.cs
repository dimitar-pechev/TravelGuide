using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.Data;

namespace TravelGuide
{
    public partial class DestinationDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new TravelGuideContext();

            var id = Guid.Parse(this.Request.QueryString["id"]);
           this.CoverPhoto.ImageUrl = db.Articles.Find(id).CoverImageUrl;
        }
    }
}