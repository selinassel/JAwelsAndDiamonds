using JAwelsAndDiamonds.Model;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class Register : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1();
        RegisterController rc = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string confirmPw = confirmPwBox.Text;
            string gender = genderMale.Checked ? "Male" : genderFemale.Checked ? "Female" : "";
            string dobText = dobBox.Text;

            string result = rc.registerUser(email, username, password, confirmPw, gender, dobText);

            if (result == "success")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                errorMsg.Text = result;
            }

        }
    }
}