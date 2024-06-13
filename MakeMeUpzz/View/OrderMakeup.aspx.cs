using MakeMeUpzz.Model;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz.View
{
    
    public partial class OrderMakeup : System.Web.UI.Page
    {
        MakeupRepository makeupRepo = new MakeupRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewOrder.DataSource = makeupRepo.GetAllMakeups();
                GridViewOrder.DataBind();
            }
        }

        protected void GridViewOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}