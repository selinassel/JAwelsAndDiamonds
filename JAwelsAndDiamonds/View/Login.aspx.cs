using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;
using System.Web;

namespace JAwelsAndDiamonds.View
{
    public partial class Login : System.Web.UI.Page
    {
        private Database1Entities1 db = new Database1Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Value;
            string password = passwordBox.Value;
            //bool remember = rememberMe.Checked;

            MsUser user = UserRepository.GetUserByEmailAndPassword(email, password);

            if (user != null)
            {
                Session["user"] = user;
                Session["Role"] = user.UserRole;

                if (rememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                errorLabel.Text = "Email atau password salah.";
            }
        }
    }
}