using Microsoft.AspNet.Identity;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelGuide.App_Start;
using TravelGuide.Services.Users.Contracts;

namespace TravelGuide.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        private IUserService userService;

        public Admin()
        {
            this.userService = NinjectWebCommon.Kernel.Get<IUserService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ListViewUsers.DataSource = this.userService.GetAllUsers();
            this.ListViewUsers.DataBind();
        }

        protected void ListViewUsers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            this.userService.DeleteUser(this.User.Identity.GetUserId());
        }
    }
}