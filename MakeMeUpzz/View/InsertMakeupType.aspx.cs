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
    public partial class InsertMakeupType : System.Web.UI.Page
    {
        MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
        InsertMakeupTypeFactory insertMakeupTypeFactory = new InsertMakeupTypeFactory();
        MakeupTypeController makeupTypeController = new MakeupTypeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            Err.Visible = false;
        }


        protected void insertTypeBtn_Click(object sender, EventArgs e)
        {
            // Validation
            string response = MakeupTypeController.checkMakeupTypeName(typeNameTxt.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            // Retrieve data
            int newTypeId = makeupTypeRepo.GenerateMakeupTypeId();
            string typeName = typeNameTxt.Text;

            // Insert data
            MakeupType makeupType = InsertMakeupTypeFactory.Create(newTypeId, typeName);

            makeupTypeRepo.AddMakeupType(makeupType);
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