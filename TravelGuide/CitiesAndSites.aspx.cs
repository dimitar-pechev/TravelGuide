using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Data;
using TravelGuide.Services.Contracts;

namespace TravelGuide
{
    public partial class CitiesAndSites : Page
    {
        private readonly IArticleService articleService;

        public CitiesAndSites()
        {
            this.articleService = NinjectWebCommon.Kernel.Get<IArticleService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var articles = this.articleService.GetAllArticles();
            this.ListViewDestinations.DataSource = articles;
            this.ListViewDestinations.DataBind();
        }
    }
}