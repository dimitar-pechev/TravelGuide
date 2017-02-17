using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.Contracts;

namespace TravelGuide
{
    public partial class AddArticle : Page
    {
        private readonly IArticleService articleService;

        public AddArticle()
        {
            this.articleService = NinjectWebCommon.Kernel.Get<IArticleService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitNewArticle_Click(object sender, EventArgs e)
        {
            var username = this.User.Identity.Name;
            var title = this.ArticleTitle.Text;
            var city = this.ArticleCity.Text;
            var country = this.ArticleCountry.Text;
            var content = this.ArticleContent.Value;
            var imageUrl = this.ArticleImageUrl.Text;

            this.articleService.CreateArticle(username, title, city, country, content, imageUrl);
            this.Response.Redirect("~/CitiesAndSites.aspx");
        }
    }
}