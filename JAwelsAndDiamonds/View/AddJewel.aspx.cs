using JAwelsAndDiamonds.Repository;
using System;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class AddJewel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCategories();
                LoadBrands();
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

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string name = jewelNameTxt.Text.Trim();
            string priceTxt = jewelPriceTxt.Text.Trim();
            string release = jewelReleaseTxt.Text.Trim();
            int releaseYear = int.Parse(release);

            if (name.Length < 3 || name.Length > 25)
            {
                errorLbl.Text = "Jewel name length must be between 3-25 characters";
                return;
            }

            if (string.IsNullOrEmpty(JewelCategoryDdl.SelectedValue) ||
                !int.TryParse(JewelCategoryDdl.SelectedValue, out int categoryID))
            {
                errorLbl.Text = "Please select a valid category";
                return;
            }

            if (string.IsNullOrEmpty(JewelBrandDdl.SelectedValue) ||
                !int.TryParse(JewelBrandDdl.SelectedValue, out int brandID))
            {
                errorLbl.Text = "Please select a valid brand";
                return;
            }

            if (!int.TryParse(priceTxt.Replace("$", "").Trim(), out int price))
            {
                errorLbl.Text = "Price must be a valid number";
                return;
            }

            if (price < 25)
            {
                errorLbl.Text = "Price must be at least $25";
                return;
            }

            //if (!DateTime.TryParse(release, out DateTime releaseDate))
            //{
            //    errorLbl.Text = "Release date must be a valid date";
            //    return;
            //}

            if (releaseYear > DateTime.Now.Year)
            {
                errorLbl.Text = "Release date cannot be in the future";
                return;
            }

            //int releaseYear = releaseDate.Year;

            JewelRepository.insertJewel(categoryID, brandID, name, price, releaseYear);

            Response.Redirect("Home.aspx");

            //errorLbl.Text = "Failed to add jewel. Please try again."
        }
    }
}