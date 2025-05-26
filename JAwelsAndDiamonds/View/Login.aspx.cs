using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.View
{
    public partial class Login : System.Web.UI.Page
    {
        private Database1Entities1 db = new Database1Entities1 ();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Value;
            string password = passwordBox.Value;
            bool remember = rememberMe.Checked;

            var user = (from x in db.MsUsers where x.UserEmail.Equals(email) && x.UserPassword.Equals(password) select x).FirstOrDefault();

            if (user != null)
            {
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
            else
            {
                errorLabel.Text = "Email atau password salah.";
            }
        }
    }
}