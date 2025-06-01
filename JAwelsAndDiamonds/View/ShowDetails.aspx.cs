using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        JewelRepository jr = new JewelRepository();
        JewelHandler jh = new JewelHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}

            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            if (Request.QueryString["id"] != null)
            {
                int jewelID = int.Parse(Request.QueryString["id"]);
                var jewelList = jh.GetJewelDetails(jewelID);

                if (jewelList.Count > 0)
                {
                    var jewel = jewelList[0];
                    LblJewelName.Text = jewel.JewelName;
                    LblCategoryName.Text = jewel.MsCategory.CategoryName;
                    LblBrandName.Text = jewel.MsBrand.BrandName;
                    LblCountry.Text = jewel.MsBrand.BrandCountry;
                    LblBrandClass.Text = jewel.MsBrand.BrandClass;
                    LblPrice.Text = jewel.JewelPrice.ToString();
                    LblReleaseYear.Text = jewel.JewelReleaseYear.ToString();
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateJewel.aspx?id=" + Request.QueryString["id"]);
        }
    }
}