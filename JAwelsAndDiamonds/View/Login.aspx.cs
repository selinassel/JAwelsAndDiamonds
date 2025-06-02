using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Model;
using System;
using System.Web;

namespace JAwelsAndDiamonds.View
{
    public partial class Login : System.Web.UI.Page
    {
        private Database1Entities1 db = new Database1Entities1();
        LoginController lc = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user_cookie"] != null)
                {
                    string UserIdString = Request.Cookies["user_cookie"].Value;

                    if (int.TryParse(UserIdString, out int userId))
                    {
                        MsUser user = db.MsUsers.Find(userId);
                        if (user != null)
                        {
                            Session["user"] = user;
                            Session["Role"] = user.UserRole;
                            Response.Redirect("Home.aspx");
                        }
                    }
                }

            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Value;
            string password = passwordBox.Value;
            bool remember = rememberMe.Checked;

            MsUser user;
            string error = lc.Login(email, password, out user);

            if (error != null)
            {
                errorLabel.Text = error;
                return;
            }

            Session["user"] = user;
            Session["Role"] = user.UserRole;

            if (remember)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = user.UserID.ToString();
                cookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("Home.aspx");
        }

    }
}