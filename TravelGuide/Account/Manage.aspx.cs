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
using System.Linq;

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

        public static string Action { get; set; }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                this.BtnShowRequests_Click(null, null);

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
            Action = "Edit your profile";
            this.EditProfilePanel.Visible = true;
            this.PanelRequest.Visible = false;
            this.ResultLabel.Visible = false;
            var user = this.userService.GetById(this.User.Identity.GetUserId());

            this.FirstNameEdit.Text = user.FirstName;
            this.LastNameEdit.Text = user.LastName;
            this.PhoneEdit.Text = user.PhoneNumber;
            this.AddressEdit.Text = user.Address;
        }

        protected void BtnShowRequests_Click(object sender, EventArgs e)
        {
            Action = "Orders";
            this.PanelRequest.Visible = true;
            this.EditProfilePanel.Visible = false;
            this.ResultLabel.Visible = false;
            var user = this.userService.GetById(this.User.Identity.GetUserId());
            this.ListViewRequests.DataSource = user.Requests.ToList();
            this.ListViewRequests.DataBind();
        }

        protected void BtnUploadPicture_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitNeProfileInfo_Click(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();
            var firstName = this.FirstNameEdit.Text;
            var lastName = this.LastNameEdit.Text;
            var phone = this.PhoneEdit.Text;
            var address = this.AddressEdit.Text;

            this.userService.UpdateUserInfo(userId, firstName, lastName, phone, address);
            this.ResultLabel.Visible = true;
        }
    }
}