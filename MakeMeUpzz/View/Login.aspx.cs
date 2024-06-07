using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Models;

namespace Test.View
{
    public partial class Login : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Err.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = TbEmail.Text;
            string password = TbPassword.Text;

            if (string.IsNullOrEmpty(email))
            {
                showError("Email cannot be empty!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                showError("Password cannot be empty!");
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
            if (user != null)
            {
                // Successfully logged in
                Session["UserId"] = user.UserID;
                Session["Username"] = user.Username;
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                showError("Invalid email or password!");
            }
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }

    }
}