
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Role"] == null || Session["Role"].ToString() != "Customer")
            //{
            //    Response.Redirect("Home.aspx");
            //    return;
            //}

            if (!IsPostBack)
            {
                LoadCart();
                LoadPaymentMethods();
            }
        }
        private void LoadCart()
        {
            //int userId = Convert.ToInt32(Session["UserID"]);
            //int userId = Convert.ToInt32(Session[user] ?? -1);

            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;

            if (userId == -1)
            {
                ErrorLabel.Text = "User belum login.";
                return;
            }

            var cartItems = CartRepository.GetCartByUserId(userId);



            CartGridView.DataSource = cartItems;
            CartGridView.DataBind();

            int total = cartItems.Sum(item => item.Subtotal);
            TotalLabel.Text = $"Total: ${total}";

            var cartItem = CartRepository.GetCartByUserId(userId);

            if (cartItem.Count == 0)
            {
                ErrorLabel.Text = "Cart kosong atau tidak ditemukan.";
            }

        }

        private void LoadPaymentMethods()
        {
            PaymentDropdown.Items.Clear();
            PaymentDropdown.Items.Add(new ListItem("Select Payment Method", ""));
            PaymentDropdown.Items.Add(new ListItem("Credit Card", "Credit Card"));
            PaymentDropdown.Items.Add(new ListItem("Bank Transfer", "Bank Transfer"));
            PaymentDropdown.Items.Add(new ListItem("Cash", "Cash"));
        }

        private void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);

            foreach (GridViewRow row in CartGridView.Rows)
            {
                int jewelId = Convert.ToInt32(CartGridView.DataKeys[row.RowIndex].Value);
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    CartRepository.UpdateCartItemQuantity(userId, jewelId, quantity);
                }
            }

            LoadCart();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int jewelId = Convert.ToInt32(CartGridView.DataKeys[row.RowIndex].Value);
            int userId = Convert.ToInt32(Session["UserID"]);

            CartRepository.RemoveFromCart(userId, jewelId);
            LoadCart();
        }

        public void ClearCartButton_Click(object sender, EventArgs e)
        {
            //int userId = Convert.ToInt32(Session["UserID"]);
            //CartRepository.ClearCartByUserId(userId);
            //LoadCart();
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PaymentDropdown.SelectedValue))
            {
                ErrorLabel.Text = "Please select a payment method.";
                return;
            }

            int userId = Convert.ToInt32(Session["UserID"]);
            string paymentMethod = PaymentDropdown.SelectedValue;

            try
            {
                CartRepository.Checkout(userId, paymentMethod);

                ErrorLabel.ForeColor = System.Drawing.Color.Green;
                ErrorLabel.Text = "Checkout successful!";
                LoadCart();
            }
            catch (Exception ex)
            {
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Text = "Checkout failed. Please try again.";
            }

        }
    }
}