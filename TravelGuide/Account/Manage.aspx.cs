using System;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TravelGuide.Auth;
using TravelGuide.Services.Requests.Contracts;
using TravelGuide.Services.Users.Contracts;
using TravelGuide.Services.Store.Contracts;
using TravelGuide.App_Start;
using Ninject;

namespace TravelGuide.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private readonly IRequestService requestService;
        private readonly IUserService userService;
        private readonly IStoreService storeService;

        public Manage()
        {
            this.requestService = NinjectWebCommon.Kernel.Get<IRequestService>();
            this.userService = NinjectWebCommon.Kernel.Get<IUserService>();
            this.storeService = NinjectWebCommon.Kernel.Get<IStoreService>();
        }

        public string Action { get; set; }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        protected void Page_Load()
        {
            this.BtnShowRequests_Click(null, null);

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }
            }
        }

        protected void BtnShowEditProfile_Click(object sender, EventArgs e)
        {
            this.Action = "Edit your profile";
            this.EditProfilePanel.Visible = true;
            this.PanelRequest.Visible = false;
        }

        protected void BtnShowRequests_Click(object sender, EventArgs e)
        {
            this.Action = "Orders";
            this.PanelRequest.Visible = true;
            this.EditProfilePanel.Visible = false;
            this.ListViewRequests.DataSource = this.requestService.GetAllRequests();
            this.ListViewRequests.DataBind();
        }

        protected void BtnUploadPicture_Click(object sender, EventArgs e)
        {

        }
    }
}