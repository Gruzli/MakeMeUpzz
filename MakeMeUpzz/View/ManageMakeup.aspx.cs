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

        protected void insertMakeupBtn_Click(object sender, EventArgs e)
        {

        }

        protected void insertMakeupTypeBtn_Click(object sender, EventArgs e)
        {

        }

        protected void insertMakeupBrandBtn_Click(object sender, EventArgs e)
        {

        }
    }
}