using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Model;
using MakeMeUpzz.Reposiitory;
using MakeMeUpzz.Factory;

namespace MakeMeUpzz.View
{
    public partial class Register : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            Err.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbUsername.Text))
            {
                showError("Username cannot be empty!");
                return;
            }

            if (TbUsername.Text.Length < 5 || TbUsername.Text.Length > 15)
            {
                showError("Username must be between 5 to 15 characters!");
                return;
            }

            if (string.IsNullOrEmpty(TbEmail.Text))
            {
                showError("Email cannot be empty!");
                return;
            }

            if (!TbEmail.Text.Contains(".com"))
            {
                showError("Email must end with .com");
                return;
            }

            if (!Male.Checked && !Female.Checked)
            {
                showError("Gender must be chosen and cannot be empty");
                return;
            }

            if (string.IsNullOrEmpty(TbPassword.Text))
            {
                showError("Password cannot be empty!");
                return;
            }

            if (string.IsNullOrEmpty(TbConfirmPassword.Text))
            {
                showError("Confirmation password cannot be empty!");
                return;
            }

            if (TbConfirmPassword.Text != TbPassword.Text)
            {
                showError("Passwords must match!");
                return;
            }

            if (string.IsNullOrEmpty(TbDOB.Text))
            {
                showError("Date of birth cannot be empty");
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

            User user = UserFactory.Create(newId, newUsername, newEmail, newGender, newPassword, newDOB, newRole);
            userRepo.InsertDataUser(user);
            Response.Redirect("Login.aspx");
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}
