using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Repository;
using System;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class AddJewel : System.Web.UI.Page
    {
        AddJewelController addController = new AddJewelController();
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
            string categoryVal = JewelCategoryDdl.SelectedValue;
            string brandVal = JewelBrandDdl.SelectedValue;

            string error = addController.AddJewel(name, priceTxt, release, categoryVal, brandVal);

            if (error != null)
            {
                errorLbl.Text = error;
                return;
            }

            Response.Redirect("Home.aspx");
        }
    }
}