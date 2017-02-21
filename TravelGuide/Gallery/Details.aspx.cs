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

        public static GalleryImage Image { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            if (this.User.Identity.IsAuthenticated)
            {
                this.ButtonLikeImage.Visible = true;
                this.BtnRevelCommentModal.Visible = true;
            }

            if (this.User.IsInRole("admin"))
            {
                this.BtnDeleteImage.Visible = true;
            }

            this.BindToNewData();
        }

        private Guid GetGuidFromString(string str)
        {
            var id = Guid.Parse(str);
            return id;
        }

        protected void BtnLikeImage_Click(object sender, EventArgs e)
        {
            this.service.ToggleLike(this.User.Identity.Name, Image.Id);
            this.BindToNewData();
        }

        protected void BtnCommentImage_Click(object sender, EventArgs e)
        {
            if (this.CommentsPanel.Visible)
            {
                this.CommentsPanel.Visible = false;
                return;
            }

            this.CommentsPanel.Visible = true;
            this.BindToNewData();
        }

        protected void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            this.service.DeleteImage(Image);
            this.Response.Redirect("~/Gallery/AllPhotos.aspx");
        }

        protected void BtnSubmitNewComment_Click(object sender, EventArgs e)
        {
            this.service.AddComment(this.User.Identity.Name, this.NewCommentContent.Value.Trim(), Image.Id);
            this.BindToNewData();
        }

        protected void ListViewGalleryComments_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var id = string.Empty;
            foreach (var item in e.Keys.Values)
            {
                id = item.ToString();
            }

            this.service.DeleteComment(id);

            this.BindToNewData();
            this.Response.Redirect($"~/Gallery/Details.aspx?id={Image.Id.ToString()}");
        }

        private void BindToNewData()
        {
            try
            {
                var id = GetGuidFromString(this.Request.QueryString["id"]);
                Image = this.service.GetGalleryImageById(id);
                this.ListViewGalleryComments.DataSource = Image.Comments;
                this.DataBind();
            }
            catch (Exception)
            {
                this.Response.Redirect("~/Gallery/AllPhotos.aspx");
            }
        }
    }
}
