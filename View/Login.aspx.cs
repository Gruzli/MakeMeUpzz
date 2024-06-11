using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Model;
using MakeMeUpzz.Reposiitory;

namespace MakeMeUpzz.View
{
    public partial class Login : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            Err.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = TbUsername.Text;
            string password = TbPassword.Text;
            bool isRemember = RememberMe.Checked;


            if (string.IsNullOrEmpty(username))
            {
                showError("Username cannot be empty!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                showError("Password cannot be empty!");
                return;
            }
            bool isAuthenticated = userRepo.isAuthenticate(username, password);

            if (isAuthenticated)
            {
                Session["user"] = isAuthenticated;
                HttpCookie cookie = new HttpCookie("user_cookies");
                cookie.Value = username;
                cookie.Expires = DateTime.Now.AddHours(5);
                Response.Cookies.Add(cookie);
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                showError("Invalid email or password!");
                return;
            }
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }

    }
}