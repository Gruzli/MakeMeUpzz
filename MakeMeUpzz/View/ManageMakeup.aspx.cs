using MakeMeUpzz.Controller;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repositories;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    public partial class ManageMakeup : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        MakeupRepository makeupRepo = new MakeupRepository();
        MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
        MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            if (user == null || user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }
            Err.Visible = false;

            List<Makeup> makeups = makeupRepo.GetAllMakeups();
            makeupGridView.DataSource = makeups;
            makeupGridView.DataBind();

            List<MakeupType> makeupTypes = makeupTypeRepo.GetAllMakeupTypes();
            makeupTypeGridView.DataSource = makeupTypes;
            makeupTypeGridView.DataBind();

            List<MakeupBrand> makeupBrands = makeupBrandRepo.GetAllMakeupBrands();
            makeupBrandGridView.DataSource = makeupBrands;
            makeupBrandGridView.DataBind();

        }

        protected void gotoInsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMakeup.aspx");
        }

        protected void makeupGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = makeupGridView.Rows[e.NewEditIndex];
            string makeupId = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeup.aspx?makeupId=" + makeupId);
        }

        protected void makeupGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupGridView.Rows[e.RowIndex];
            int makeupId = Convert.ToInt32(row.Cells[0].Text.ToString());

            string response = makeupRepo.DeleteMakeup(makeupId);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
            }

            List<Makeup> makeups = makeupRepo.GetAllMakeups();
            makeupGridView.DataSource = makeups;
            makeupGridView.DataBind();
        }

        protected void gotoInsertTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMakeupType.aspx");
        }

        protected void makeupTypeGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = makeupTypeGridView.Rows[e.NewEditIndex];
            string typeId = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeupType.aspx?typeId=" + typeId);
        }

        protected void makeupTypeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupTypeGridView.Rows[e.RowIndex];
            int typeId = Convert.ToInt32(row.Cells[0].Text.ToString());

            string response = makeupTypeRepo.DeleteMakeupType(typeId);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
            }

            List<MakeupType> makeupTypes = makeupTypeRepo.GetAllMakeupTypes();
            makeupTypeGridView.DataSource = makeupTypes;
            makeupTypeGridView.DataBind();
        }

        protected void gotoInsertBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMakeupBrand.aspx");
        }

        protected void makeupBrandGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = makeupBrandGridView.Rows[e.NewEditIndex];
            string brandId = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeupBrand.aspx?brandId=" + brandId);

        }

        protected void makeupBrandGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupBrandGridView.Rows[e.RowIndex];
            int brandId = Convert.ToInt32(row.Cells[0].Text.ToString());

            string response = makeupBrandRepo.DeleteMakeupBrand(brandId);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
            }

            List<MakeupBrand> makeupBrands = makeupBrandRepo.GetAllMakeupBrands();
            makeupBrandGridView.DataSource = makeupBrands;
            makeupBrandGridView.DataBind();
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}