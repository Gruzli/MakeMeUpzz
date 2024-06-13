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
    public partial class InsertMakeup : System.Web.UI.Page
    {
        MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
        MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
        MakeupRepository makeupRepo = new MakeupRepository();
        InsertMakeupFactory insertMakeupFactory = new InsertMakeupFactory();
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
                List<MakeupType> makeupTypes = makeupTypeRepo.GetAllMakeupTypes();
                List<String> typeNames = makeupTypes.Select(x => x.MakeupTypeName).ToList();
                makeupTypeDdl.DataSource = typeNames;
                makeupTypeDdl.DataBind();

                List<MakeupBrand> makeupBrands = makeupBrandRepo.GetAllMakeupBrands();
                List<String> brandNames = makeupBrands.Select(x => x.MakeupBrandName).ToList();
                makeupBrandDdl.DataSource = brandNames;
                makeupBrandDdl.DataBind();
            }

            Err.Visible = false;
        }

        protected InsertMakeupFactory GetInsertMakeupFactory()
        {
            return insertMakeupFactory;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeup.aspx");
        }

        protected void insertMakeupBtn_Click(object sender, EventArgs e)
        {
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

            string name = makeupNameTxt.Text;
            int price = Int32.Parse(makeupPriceTxt.Text);
            int weight = Int32.Parse(makeupWeightTxt.Text);
            string typeName = makeupTypeDdl.SelectedValue;
            string brandName = makeupBrandDdl.SelectedValue;

            MakeupType makeupType = makeupTypeRepo.GetMakeupTypeByName(typeName);
            MakeupBrand makeupBrand = makeupBrandRepo.GetMakeupBrandByName(brandName);

            int newId = makeupRepo.GenerateMakeupId();

            Makeup makeup = InsertMakeupFactory.Create(newId, name, price, weight, makeupType.MakeupTypeID, makeupBrand.MakeupBrandID);

            makeupRepo.AddMakeup(makeup);

            Response.Redirect("ManageMakeup.aspx");
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}