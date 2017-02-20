using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Data;
using TravelGuide.Models.Articles;
using TravelGuide.Services.Contracts;
using TravelGuide.Services.Factories;

namespace TravelGuide
{
    public partial class DestinationDetails : Page
    {
        private IArticleService articleService;

        public DestinationDetails()
        {
            this.articleService = NinjectWebCommon.Kernel.Get<IArticleService>();
        }

        public Article Article { get; set; }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            try
            {
                var id = GetGuidFromString(this.Request.QueryString["id"]);
                this.Article = this.articleService.GetArticleById(id);
            }
            catch (Exception)
            {
                this.Response.Redirect("~/Articles/CitiesAndSites.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CoverPhoto.ImageUrl = this.Article.CoverImageUrl;
            this.ListViewArticleComments.DataSource = this.Article.Comments;
            this.ListViewArticleComments.DataBind();
        }

        private Guid GetGuidFromString(string str)
        {
            var id = Guid.Parse(str);
            return id;
        }

        protected void BtnSubmitNewComment_Click(object sender, EventArgs e)
        {
            var username = this.User.Identity.Name;
            var content = this.NewCommentContent.Value;
            var articleId = this.Article.Id;
            this.articleService.AddComment(username, content, articleId);
            this.ListViewArticleComments.DataSource = this.Article.Comments;
            this.ListViewArticleComments.DataBind();
        }
    }
}