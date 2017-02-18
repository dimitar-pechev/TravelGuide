using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.Data;
using TravelGuide.Models.Articles;

namespace TravelGuide
{
    public partial class DestinationDetails : System.Web.UI.Page
    {
        public Article article;

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
                        
            try
            {
                var db = new TravelGuideContext();
                var id = Guid.Parse(this.Request.QueryString["id"]);
                this.article = db.Articles.Find(id);
                this.DataBind();
            }
            catch (Exception)
            {
                this.Response.Redirect("~/CitiesAndSites.aspx");
            }            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CoverPhoto.ImageUrl = this.article.CoverImageUrl;
        }
    }
}