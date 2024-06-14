using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Controller;

namespace MakeMeUpzz.View
{
    public partial class Register : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }

            Err.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string response = UserController.checkUsername(TbUsername.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = UserController.checkEmail(TbEmail.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = UserController.checkGender(Male.Checked, Female.Checked);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = UserController.checkPassword(TbPassword.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = UserController.checkConfirmPassword(TbConfirmPassword.Text, TbPassword.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            response = UserController.checkDOB(TbDOB.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            if (!DateTime.TryParse(TbDOB.Text, out DateTime newDOB))
            {
                showError("Invalid date format. Please use yyyy-MM-dd.");
                return;
            }


            int newId = userRepo.generateId();
            String newUsername = TbUsername.Text;
            String newEmail = TbEmail.Text;
            String newGender = Male.Checked ? Male.Text : Female.Text;
            String newPassword = TbPassword.Text;
            String newRole = "Customer";

            User user = RegisterUserFactory.Create(newId, newUsername, newGender, newPassword, newEmail, newDOB, newRole);
            userRepo.InputRegisterUser(user);
            Response.Redirect("Login.aspx");
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}
