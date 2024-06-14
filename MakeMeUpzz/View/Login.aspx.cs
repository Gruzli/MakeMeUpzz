using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;

namespace MakeMeUpzz.View
{
    public partial class Login : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }

            Err.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = TbUsername.Text;
            string password = TbPassword.Text;
            bool isRemember = CheckBox1.Checked;

            bool isAuthenticated = userRepo.Authentication(username, password);

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

            if (isAuthenticated)
            {
                var user = userRepo.getUserByUsername(username);
                Session["user"] = user;

                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookies");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(5);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("HomePage.aspx");
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