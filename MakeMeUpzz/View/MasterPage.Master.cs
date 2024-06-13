using MakeMeUpzz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
	public partial class MasterPage : System.Web.UI.MasterPage
	{
        

        protected void Page_Load(object sender, EventArgs e)
		{
            User user = (User)Session["user"];
            
            if(user != null && user.UserRole != "admin")
            {
                homeBtn.Visible = false;
                manageMakeupBtn.Visible = false;
                orderQueueBtn.Visible = false;
                transactionReportBtn.Visible = false;
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

        protected void manageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeup.aspx");
        }

        protected void homeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}