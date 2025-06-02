using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Repository;
using System;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        JewelRepository jr = new JewelRepository();
        private int JewelID;
        UpdateJewelController UpdateJewelController = new UpdateJewelController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["id"], out JewelID))
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCategories();
                LoadBrands();
                LoadJewelData(JewelID);
            }
        }

        private void LoadCategories()
        {
            JewelCategoryDdl.DataSource = CategoryRepository.GetAllCategories();
            JewelCategoryDdl.DataTextField = "CategoryName";
            JewelCategoryDdl.DataValueField = "CategoryID";
            JewelCategoryDdl.DataBind();
            JewelCategoryDdl.Items.Insert(0, new ListItem("Select Category", ""));
        }

        private void LoadBrands()
        {
            JewelBrandDdl.DataSource = BrandRepository.GetAllBrands();
            JewelBrandDdl.DataTextField = "BrandName";
            JewelBrandDdl.DataValueField = "BrandID";
            JewelBrandDdl.DataBind();
            JewelBrandDdl.Items.Insert(0, new ListItem("Select Brand", ""));
        }

        private void LoadJewelData(int JewelID)
        {
            var jewelList = jr.GetJewelDetails(JewelID);
            if (jewelList == null)
            {
                Response.Redirect("Home.aspx");
                return;
            }

            var jewel = jewelList[0];

            jewelNameTxt.Text = jewel.JewelName;
            JewelCategoryDdl.SelectedValue = jewel.CategoryID.ToString();
            JewelBrandDdl.SelectedValue = jewel.BrandID.ToString();
            jewelPriceTxt.Text = jewel.JewelPrice.ToString();
            jewelReleaseTxt.Text = jewel.JewelReleaseYear.ToString();

        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string name = jewelNameTxt.Text.Trim();
            string categoryID = JewelCategoryDdl.SelectedValue;
            string brandID = JewelBrandDdl.SelectedValue;
            string priceTxt = jewelPriceTxt.Text.Trim();
            string release = jewelReleaseTxt.Text.Trim();

            string errorMsg;
            bool isSuccess = UpdateJewelController.UpdateJewel(JewelID, name, categoryID, brandID, priceTxt, release, out errorMsg);

            if (!isSuccess)
            {
                errorLbl.Text = errorMsg;
            }
            else
            {
                Response.Redirect("Home.aspx");
            }

        }
    }
}