using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.View
{
    public partial class ShowDetails : System.Web.UI.Page
    {
        JewelHandler jh = new JewelHandler();
        CartRepository cr = new CartRepository();
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
            MsUser user = Session["user"] as MsUser;
            int jewelID = int.Parse(Request.QueryString["id"]);
            int userID = user.UserID;
            int quantity = 1;

            cr.AddToCart(userID, jewelID, quantity);

            Response.Redirect("Cart.aspx");

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateJewel.aspx?id=" + Request.QueryString["id"]);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = jh.DeleteJewel(int.Parse(Request.QueryString["id"]));

            if (result)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                //LblErrorMessage.Text = "Error deleting jewel.";
            }

        }
    }
}