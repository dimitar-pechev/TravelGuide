using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Models.Articles;
using TravelGuide.Services.Contracts;

namespace TravelGuide.Articles
{
    public partial class EditArticle : System.Web.UI.Page
    {
        private readonly IArticleService articleService;

        public EditArticle()
        {
            this.articleService = NinjectWebCommon.Kernel.Get<IArticleService>();
        }

        public static Article Article { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            try
            {
                var articleId = this.Request.QueryString["id"];
                var parsed = ParseGuid(articleId);
                Article = this.articleService.GetArticleById(parsed);
            }
            catch (Exception)
            {
                this.Response.Redirect("/Articles/CitiesAndSites.aspx");
            }

            this.ArticleTitle.Text = Article.Title;
            this.ArticleCity.Text = Article.City;
            this.ArticleCountry.Text = Article.Country;
            this.ArticleContentMain.Value = Article.ContentMain;
            this.ArticleContentMustSee.Value = Article.ContentMustSee;
            this.ArticleContentBudgetTips.Value = Article.ContentBudgetTips;
            this.ArticleContentAccomodation.Value = Article.ContentAccomodation;
            this.ArticleImageUrl.Text = Article.PrimaryImageUrl;
            this.SecondPictureUrl.Text = Article.SecondImageUrl;
            this.ThirdPictureUrl.Text = Article.ThirdImageUrl;
            this.CoverPictureUrl.Text = Article.CoverImageUrl;
        }

        protected void BtnEditArticleSubmit_Click(object sender, EventArgs e)
        {
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

            this.articleService.EditArticle(Article.Id, title, city, country, contentMain, contentMustSee, contentTips,
                contentAccomodation, primaryImageUrl, secondImageUrl, thirdImageUrl, coverImageUrl);

            this.Response.Redirect("~/Articles/DestinationDetails.aspx?id=" + Article.Id.ToString());
        }

        private Guid ParseGuid(string str)
        {
            return Guid.Parse(str);
        }
    }
}