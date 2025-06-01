using System;

namespace JAwelsAndDiamonds.Master
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void logout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}