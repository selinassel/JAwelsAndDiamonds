using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JAwelsAndDiamonds.Repo;

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
            JewelCategoryDdl.DataSource = CategoryRepo.GetAllCategories();
            JewelCategoryDdl.DataTextField = "CategoryName";
            JewelCategoryDdl.DataValueField = "CategoryID";
            JewelCategoryDdl.DataBind();

            JewelCategoryDdl.Items.Insert(0, new ListItem("Select Category", ""));
        }

        private void LoadBrands()
        {
            JewelBrandDdl.DataSource = BrandRepo.GetAllBrands();
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
            string categoryID = JewelCategoryDdl.SelectedValue;
            string brandID = JewelBrandDdl.SelectedValue;
            string priceTxt = jewelPriceTxt.Text.Trim();
            string release = jewelReleaseTxt.Text.Trim();

            if (name.Length < 3 || name.Length > 25)
            {
                errorLbl.Text = "Jewel name length must between 3-25 characters";
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

            if (!DateTime.TryParse(release, out DateTime releaseDate))
            {
                errorLbl.Text = "Release date must be a valid date";
                return;
            }

            if (releaseDate > DateTime.Now)
            {
                errorLbl.Text = "Release date cannot be in the future";
                return;
            }

            //disini nnti ad panggil jewelRepo

            //if (result)
            //{
            //    // Berhasil tambah
            //    Response.Redirect("Home.aspx");
            //}
            //else
            //{
            //    // Gagal tambah
            //    errorLbl.Text = "Failed to add jewel. Please try again";
            //}
        }
    }
}