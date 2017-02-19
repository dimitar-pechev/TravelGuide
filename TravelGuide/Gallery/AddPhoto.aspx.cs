using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.GalleryImages.Contracts;

namespace TravelGuide.Gallery
{
    public partial class AddPhoto : Page
    {
        private readonly IGalleryImageService service;

        public AddPhoto()
        {
            this.service = NinjectWebCommon.Kernel.Get<IGalleryImageService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddNewPhoto_Click(object sender, EventArgs e)
        {
            var username = this.User.Identity.Name;
            var title = this.NewImageTitle.Text;
            var newImageUrl = this.NewImageUrl.Text;

            this.service.AddNewImage(username, title, newImageUrl);

            this.Response.Redirect("~/Gallery/AllPhotos.aspx");
        }
    }
}