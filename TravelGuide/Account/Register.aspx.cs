using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TravelGuide.Auth;
using TravelGuide.Models;

namespace TravelGuide.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new User()
            {
                UserName = this.Username.Text,
                Email = this.Email.Text
            };
            
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                var currentUser = manager.FindByName(user.UserName);
                var roleresult = manager.AddToRole(currentUser.Id, "user");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}