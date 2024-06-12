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
    public partial class Home : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            customerDataLbl.Visible = false;
            customerGrid.Visible = false;
            if (Session["user"] == null && Request.Cookies["user_cookies"] == null)
            {
                Response.Redirect("Login.aspx");
            } else {
                User user;
                if (Session["user"] == null)
                {
                    var id = Request.Cookies["user_cookies"].Value;
                    user  = userRepo.getUserById(int.Parse(id));
                    Session["user"] = user;
                } else 
                {
                    user = (User)Session["user"];
                }
                roleLbl.Text = user.UserRole;
                nameLbl.Text = user.Username;

                if (user.UserRole == "admin")
                {
                    customerDataLbl.Visible = true;
                    customerGrid.Visible = true;

                    List<User> users = userRepo.getAllUser();

                    customerGrid.DataSource = users;
                    customerGrid.DataBind();


                }
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("user");
            Response.Redirect("Login.aspx");
        }
    }
}