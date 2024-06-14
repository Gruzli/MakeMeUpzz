using MakeMeUpzz.Controller;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class UpdateMakeupType : System.Web.UI.Page
    {
        MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
        MakeupTypeController makeupTypeController = new MakeupTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (IsPostBack == false)
            {
                int typeId = Convert.ToInt32(Request.QueryString["typeId"]);

                MakeupType makeupType = makeupTypeRepo.GetMakeupTypeById(typeId);
                if (makeupType == null)
                {
                    Response.Redirect("ManageMakeup.aspx");
                }

                typeNameTxt.Text = makeupType.MakeupTypeName;
            }

            Err.Visible = false;
        }

        protected void updateTypeBtn_Click(object sender, EventArgs e)
        {
            // Validation
            string response = MakeupTypeController.checkMakeupTypeName(typeNameTxt.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            // Retrieve data
            int typeId = Convert.ToInt32(Request.QueryString["typeId"]);
            string typeName = typeNameTxt.Text;

            // Update data
            makeupTypeRepo.UpdateMakeupType(typeId, typeName);
            Response.Redirect("ManageMakeup.aspx");

        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeup.aspx");
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}