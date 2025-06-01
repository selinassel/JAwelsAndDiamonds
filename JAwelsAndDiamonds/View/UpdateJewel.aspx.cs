using JAwelsAndDiamonds.Repository;
using System;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        JewelRepository jr = new JewelRepository();
        private int JewelID;
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
                LoadJewelData();
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

        private void LoadJewelData()
        {
            var jewelList = jr.ViewUpdateJewel();
            if (jewelList == null)
            {
                Response.Redirect("Home.aspx");
                return;
            }

            for (int i = 0; i < jewelList.Count; i++)
            {
                var jewel = jewelList[i];

                jewelNameTxt.Text = jewel.JewelName;
                JewelCategoryDdl.SelectedValue = jewel.CategoryID.ToString();
                JewelBrandDdl.SelectedValue = jewel.BrandID.ToString();
                jewelPriceTxt.Text = jewel.JewelPrice.ToString();
                jewelReleaseTxt.Text = jewel.JewelReleaseYear.ToString();

            }
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

            if (name.Length < 3 || name.Length > 25)
            {
                errorLbl.Text = "Jewel name must be between 3-25 characters.";
                return;
            }

            if (string.IsNullOrEmpty(categoryID))
            {
                errorLbl.Text = "Please select a category";
                return;
            }

            if (string.IsNullOrEmpty(brandID))
            {
                errorLbl.Text = "Please select a brand";
                return;
            }

            if (!int.TryParse(priceTxt, out int price) || price <= 25)
            {
                errorLbl.Text = "Price must be a number and more than $25";
                return;
            }

            if (!int.TryParse(release, out int releaseYear))
            {
                errorLbl.Text = "Release year must be a valid number";
                return;
            }

            if (releaseYear >= DateTime.Now.Year)
            {
                errorLbl.Text = "Release year must be less than current year";
                return;
            }

            //bool result = jr.UpdateJewel(JewelID, name, Convert.ToInt32(categoryID), Convert.ToInt32(brandID), price, releaseYear);

            //if (result)
            //{
            //    Response.Redirect("Home.aspx");
            //}
            //else
            //{
            //    errorLbl.Text = "Failed to update jewel, please try again";
            //}
        }
    }
}