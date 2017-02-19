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
    public partial class AllPhotos : Page
    {
        private readonly IGalleryImageService service;

        public AllPhotos()
        {
            this.service = NinjectWebCommon.Kernel.Get<IGalleryImageService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewGalleryItem.DataSource = this.service.GetAllNotDeletedGalleryImagesOrderedByDate();
            this.ListViewGalleryItem.DataBind();
        }
    }
}