using System;
using System.Text.RegularExpressions;

namespace JAwelsAndDiamonds.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["Username"] == null || Session["Password"] == null)
                //{
                //    Response.Redirect("Login.aspx");
                //    return;
                //}



            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassInput = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            string currentPass = Session["Password"].ToString();

            if (oldPassInput != currentPass)
            {
                lblMessage.Text = "Old password is incorrect.";
                return;
            }

            if (newPass.Length < 8 || newPass.Length > 25)
            {
                lblMessage.Text = "New password must be between 8 and 25 characters.";
                return;
            }
            if (!Regex.IsMatch(newPass, "^[a-zA-Z0-9]+$"))
            {
                lblMessage.Text = "New password must be alphanumeric.";
                return;
            }

            if (newPass != confirmPass)
            {
                lblMessage.Text = "Confirm password must match the new password.";
                return;
            }

            Session["Password"] = newPass;

            lblMessage.CssClass = "success-msg";
            lblMessage.Text = "Password changed successfully.";

            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}