using MakeMeUpzz.Controller;
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
    public partial class UpdateMakeupBrand : System.Web.UI.Page
    {
        MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
        MakeupBrandController makeupBrandController = new MakeupBrandController();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (IsPostBack == false)
            {
                int brandId = Convert.ToInt32(Request.QueryString["brandId"]);

                MakeupBrand makeupBrand = makeupBrandRepo.GetMakeupBrandById(brandId);
                if (makeupBrand == null)
                {
                    Response.Redirect("ManageMakeup.aspx");
                }

                brandNameTxt.Text = makeupBrand.MakeupBrandName;
                brandRatingTxt.Text = makeupBrand.MakeupBrandRating.ToString();
            }

            Err.Visible = false;
        }

        protected void updateBrandBtn_Click(object sender, EventArgs e)
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
            int brandId = Convert.ToInt32(Request.QueryString["brandId"]);
            string brandName = brandNameTxt.Text;
            int brandRating = Int32.Parse(brandRatingTxt.Text);

            // Update data
            makeupBrandRepo.UpdateMakeupBrand(brandId, brandName, brandRating);
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