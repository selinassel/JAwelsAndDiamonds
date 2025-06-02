using System;

namespace JAwelsAndDiamonds.Master
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = Session["Role"]?.ToString();

            adminPanel.Visible = role == "Admin";
            customerPanel.Visible = role == "Customer";
            guestPanel.Visible = role == null;
        }

        protected void LogoutLB2_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["user_cookie"] != null)
            {
                Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1); // Expire-kan cookie
            }
            Response.Redirect("Login.aspx");
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return;
        }

        protected void LogoutLB1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["user_cookie"] != null)
            {
                Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1); // Expire-kan cookie
            }
            Response.Redirect("Login.aspx");
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return;

        }
    }
}