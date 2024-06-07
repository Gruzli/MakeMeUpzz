using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Models;

namespace Test.View
{
    public partial class Register : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            Err.Visible = false;
        }

        protected int generateId()
        {
            int lastId = db.Users.OrderByDescending(x => x.UserID).Select(x => x.UserID).FirstOrDefault();
            return lastId + 1;
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

            try
            {
                int newId = generateId();
                string newUsername = TbUsername.Text;
                string newEmail = TbEmail.Text;
                string newGender = Male.Checked ? Male.Text : Female.Text;
                string newPassword = TbPassword.Text;

                User user = new User
                {
                    UserID = newId,
                    Username = newUsername,
                    UserGender = newGender,
                    UserPassword = newPassword,
                    UserEmail = newEmail,
                    UserDOB = newDOB,
                    UserRole = "Admin"
                };

                db.Users.Add(user);
                db.SaveChanges();

                // Redirect to the login page
                Response.Redirect("Login.aspx");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        showError($"{validationError.PropertyName}: {validationError.ErrorMessage}");
                    }
                }
            }
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }

        protected void Male_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
