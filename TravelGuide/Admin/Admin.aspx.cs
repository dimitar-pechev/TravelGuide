using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.Requests.Contracts;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        private IUserService userService;
        private IRequestService requestService;

        public Admin()
        {
            this.userService = NinjectWebCommon.Kernel.Get<IUserService>();
            this.requestService = NinjectWebCommon.Kernel.Get<IRequestService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            this.ListViewRequests.DataSource = this.requestService.GetAllRequests();
            this.ListViewRequests.DataBind();

            this.ListViewUsers.DataSource = this.userService.GetAllUsers();
            this.ListViewUsers.DataBind();
        }

        protected void ListViewUsers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            this.userService.DeleteUser(this.User.Identity.GetUserId());
            this.ListViewUsers.DataSource = this.userService.GetAllUsers();
            this.ListViewUsers.DataBind();
        }

        protected void BtnRestore_Click(object sender, EventArgs e)
        {
            this.userService.ActivateAccount(this.User.Identity.GetUserId());
            this.ListViewUsers.DataSource = this.userService.GetAllUsers();
            this.ListViewUsers.DataBind();
        }

        protected void ListViewRequests_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }
    }
}