using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Models.Gallery;
using TravelGuide.Services.GalleryImages.Contracts;

namespace TravelGuide.Gallery
{
    public partial class Details : Page
    {
        private readonly IGalleryImageService service;

        public Details()
        {
            this.service = NinjectWebCommon.Kernel.Get<IGalleryImageService>();
        }

        public GalleryImage Image { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = GetGuidFromString(this.Request.QueryString["id"]);
                this.Image = this.service.GetGalleryImageById(id);
                this.DataBind();
            }
            catch (Exception)
            {
                this.Response.Redirect("~/Gallery/AllPhotos.aspx");
            }
        }

        private Guid GetGuidFromString(string str)
        {
            var id = Guid.Parse(str);
            return id;
        }

        protected void BtnLikeImage_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCommentImage_Click(object sender, EventArgs e)
        {
            if (this.CommentsPanel.Visible)
            {
                this.CommentsPanel.Visible = false;
                return;
            }

            this.CommentsPanel.Visible = true;
        }

        protected void BtnDeleteImage_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitNewComment_Click(object sender, EventArgs e)
        {

        }
    }   
}
