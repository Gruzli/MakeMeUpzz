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
    public partial class InsertMakeupBrand : System.Web.UI.Page
    {
        MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
        InsertMakeupBrandFactory insertMakeupBrandFactory = new InsertMakeupBrandFactory();
        MakeupBrandController makeupBrandController = new MakeupBrandController();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            Err.Visible = false;
        }

        protected void insertBrandBtn_Click(object sender, EventArgs e)
        {
            // Validation
            string response = MakeupBrandController.checkMakeupBrandName(brandNameTxt.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = MakeupBrandController.checkMakeupBrandRating(brandRatingTxt.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            // Retrieve data
            int newBrandId = makeupBrandRepo.GenerateMakeupBrandId();
            string brandName = brandNameTxt.Text;
            int brandRating = Int32.Parse(brandRatingTxt.Text);

            // Insert data
            MakeupBrand makeupBrand = InsertMakeupBrandFactory.Create(newBrandId, brandName, brandRating);

            makeupBrandRepo.AddMakeupBrand(makeupBrand);
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