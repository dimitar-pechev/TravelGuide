using Microsoft.AspNet.Identity;
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
            var userId = this.User.Identity.GetUserId();
            var title = this.ArticleTitle.Text;
            var city = this.ArticleCity.Text;
            var country = this.ArticleCountry.Text;
            var contentMain = this.ArticleContentMain.Value;
            var contentMustSee = this.ArticleContentMustSee.Value;
            var contentTips = this.ArticleContentBudgetTips.Value;
            var contentAccomodation = this.ArticleContentAccomodation.Value;
            var primaryImageUrl = this.ArticleImageUrl.Text;
            var secondImageUrl = this.SecondPictureUrl.Text;
            var thirdImageUrl = this.ThirdPictureUrl.Text;
            var coverImageUrl = this.CoverPictureUrl.Text;

            this.articleService.CreateArticle(userId, title, city, country, contentMain, contentMustSee, contentTips,
                contentAccomodation, primaryImageUrl, secondImageUrl, thirdImageUrl, coverImageUrl);
            this.Response.Redirect("~/Articles/CitiesAndSites.aspx");
        }
    }
}