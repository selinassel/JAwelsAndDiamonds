using JAwelsAndDiamonds.Handler;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class Home : System.Web.UI.Page
    {
        //JewelRepository jr = new JewelRepository();
        JewelHandler jh = new JewelHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] != null)
            //{
            //    Response.Redirect("Home.aspx");
            //}

            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            GridViewJewelList.DataSource = jh.ViewJewel();
            GridViewJewelList.DataBind();
        }
    }
}