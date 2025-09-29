using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Model;
using System;

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
                BindData();


            }
        }

        protected void BindData()
        {
            MsUser user = Session["user"] as MsUser;
            if (user != null)
            {
                lblUsernameValue.Text = user.UserName;
                lblEmailValue.Text = user.UserEmail;
                lblDOBValue.Text = user.UserDOB.ToShortDateString();
                lblGenderValue.Text = user.UserGender;
                //Session["Password"] = user.UserPassword; 
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassInput = txtOldPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            MsUser sessionUser = Session["user"] as MsUser;
            PasswordController controller = new PasswordController();

            string cssClass;
            string message = controller.ChangePassword(sessionUser, oldPassInput, newPass, confirmPass, out cssClass);

            lblMessage.CssClass = cssClass;
            lblMessage.Text = message;

            if (cssClass == "success-msg")
            {
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }
    }
}