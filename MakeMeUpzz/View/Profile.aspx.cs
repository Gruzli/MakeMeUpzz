using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MakeMeUpzz.Repository;
using MakeMeUpzz.Repositories;
using MakeMeUpzz.Model;
using MakeMeUpzz.Factory;
using MakeMeUpzz.Controller;

namespace MakeMeUpzz.View
{
    public partial class Profile : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                if (user != null)
                {
                    int id = user.UserID;
                    User currUser = userRepo.getUserById(id);

                    if (currUser != null)
                    {
                        TbUsername.Text = currUser.Username;
                        TbEmail.Text = currUser.UserEmail;
                        if (currUser.UserGender == "Male")
                        {
                            Male.Checked = true;
                            Female.Checked = false;
                        }
                        else
                        {
                            Male.Checked = false;
                            Female.Checked = true;
                        }
                        TbDOB.Text = currUser.UserDOB.ToString("yyyy-MM-dd"); // Assuming UserDOB is a DateTime
                    }
                }
                else
                {
                    Response.Redirect("~/View/Login.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Err.Visible = true;
            User user = (User)Session["user"];
            if(user == null )
            {
                Response.Redirect("HomePage.aspx");
            }

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

            response = UserController.checkDOB(TbDOB.Text);
            if (!string.IsNullOrEmpty(response))
            {
                showError(response);
                return;
            }

            int updateId = user.UserID;
            User updateUser = userRepo.getUserById(updateId);

            String updateName = TbUsername.Text.ToString();
            String updateEmail = TbEmail.Text.ToString();
            String updateGender = Male.Checked ? "Male" : "Female";
            String updatePassword = user.UserPassword;
            DateTime updateDOB;
            String updateRole = user.UserRole;

            if (DateTime.TryParse(TbDOB.Text, out updateDOB))
            {
               
                userRepo.UpdateDataUser(updateId, updateName, updateGender, updatePassword, updateEmail, updateDOB, updateRole);
                Err.Text = "Successfully!";
            }
            else
            {
                Err.Text = "Invalid date format. Please enter a valid date.";
            }
        }
        

        protected void btnchangePass_Click(object sender, EventArgs e)
        {
            Err2.Visible = true;
            User user = (User)Session["user"];
            if (user == null)
            {
                Response.Redirect("HomePage.aspx");
            }

            int updateId = user.UserID;
            User updateUser = userRepo.getUserById(updateId);

            String oldPass = TbOldPass.Text.ToString();
            String newPass = TbNewPass.Text.ToString();

            if(oldPass != user.UserPassword)
            {
                Err2.Text = "Your old password is wrong!"; 
                return;
            }

            userRepo.UpdatePasswordUser(updateId, newPass);
            Err2.Text = "Successful change your password!";
        }

        private void showError(string msg)
        {
            Err.Visible = true;
            Err.Text = msg;
        }
    }
}