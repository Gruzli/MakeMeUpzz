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

            List<Makeup> makeUps = makeupRepo.GetAllMakeups();
            makeupGridView.DataSource = makeUps;
            makeupGridView.DataBind();

            List<MakeupType> makeUpTypes = makeupTypeRepo.GetAllMakeupTypes();
            makeupTypeGridView.DataSource = makeUpTypes;
            makeupTypeGridView.DataBind();

            List<MakeupBrand> makeUpBrands = makeupBrandRepo.GetAllMakeupBrands();
            makeupBrandGridView.DataSource = makeUpBrands;
            makeupBrandGridView.DataBind();

        }

        protected void gotoInsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMakeup.aspx");
        }

        protected void makeupGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = makeupGridView.SelectedRow;
            string makeupId = row.Cells[0].Text;
            Response.Redirect("UpdateMakeup.aspx?makeupId=" + makeupId);
        }

        protected void makeupGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = makeupGridView.Rows[e.NewEditIndex];
            string makeupId = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeup.aspx?makeupId=" + makeupId);
        }

        protected void makeupGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}