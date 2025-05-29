using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class Home : System.Web.UI.Page
    {
        JewelRepository jr = new JewelRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            GridViewJewelList.DataSource = jr.ViewJewel();
            GridViewJewelList.DataBind();
        }

    }
}