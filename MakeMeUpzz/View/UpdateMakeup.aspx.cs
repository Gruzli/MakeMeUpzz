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
    public partial class UpdateMakeup : System.Web.UI.Page
    {
        MakeupRepository makeupRepo = new MakeupRepository();
        MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
        MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
        MakeupController makeupController = new MakeupController();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

            if (IsPostBack == false)
            {
                int makeupId = Convert.ToInt32(Request.QueryString["makeupId"]);
            
                Makeup makeup = makeupRepo.GetMakeupById(makeupId);
                if (makeup == null)
                {
                    Response.Redirect("ManageMakeup.aspx");
                }

                List<MakeupType> makeupTypes = makeupTypeRepo.GetAllMakeupTypes();
                List<String> typeNames = makeupTypes.Select(x => x.MakeupTypeName).ToList();
                makeupTypeDdl.DataSource = typeNames;
                makeupTypeDdl.DataBind();

                List<MakeupBrand> makeupBrands = makeupBrandRepo.GetAllMakeupBrands();
                List<String> brandNames = makeupBrands.Select(x => x.MakeupBrandName).ToList();
                makeupBrandDdl.DataSource = brandNames;
                makeupBrandDdl.DataBind();

                makeupNameTxt.Text = makeup.MakeupName;
                makeupPriceTxt.Text = makeup.MakeupPrice.ToString();
                makeupWeightTxt.Text = makeup.MakeupWeight.ToString();
                makeupTypeDdl.SelectedValue = makeup.MakeupType.MakeupTypeName;
                makeupBrandDdl.SelectedValue = makeup.MakeupBrand.MakeupBrandName;
            }

            Err.Visible = false;

        }

        protected void updateMakeupBtn_Click(object sender, EventArgs e)
        {
            // Validation
            string response = MakeupController.checkMakeupName(makeupNameTxt.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            string priceTxt = makeupPriceTxt.Text;
            response = MakeupController.checkMakeupPrice(priceTxt);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            string weightTxt = makeupWeightTxt.Text;
            response = MakeupController.checkMakeupWeight(weightTxt);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            int makeUpTypeID = makeupTypeRepo.GetMakeupTypeByName(makeupTypeDdl.SelectedValue).MakeupTypeID;
            response = MakeupController.checkMakeupTypeID(makeUpTypeID);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            int makeUpBrandID = makeupBrandRepo.GetMakeupBrandByName(makeupBrandDdl.SelectedValue).MakeupBrandID;
            response = MakeupController.checkMakeupBrandID(makeUpBrandID);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            // Retrieve data
            int makeupId = Convert.ToInt32(Request.QueryString["makeupId"]);
            String makeupName = makeupNameTxt.Text;
            int makeupPrice = Convert.ToInt32(makeupPriceTxt.Text);
            int makeupWeight = Convert.ToInt32(makeupWeightTxt.Text);
            String makeupType = makeupTypeDdl.SelectedValue;
            String makeupBrand = makeupBrandDdl.SelectedValue;

            MakeupType makeupTypes = makeupTypeRepo.GetMakeupTypeByName(makeupType);
            MakeupBrand makeupBrands = makeupBrandRepo.GetMakeupBrandByName(makeupBrand);

            // Update data
            makeupRepo.UpdateMakeup(makeupId, makeupName, makeupPrice, makeupWeight, makeupTypes, makeupBrands);
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