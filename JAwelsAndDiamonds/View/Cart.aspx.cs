using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;
using System.Linq;
using System.Web.UI;
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
                ErrorLabel.Text = "Cart is empty";
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
        public void ClearCartButton_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ErrorLabel.Text = "User belum login.";
                return;
            }

            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;

            CartRepository.ClearCartByUserId(userId);
            LoadCart();

            ErrorLabel.Text = "Cart cleared.";
            ErrorLabel.ForeColor = System.Drawing.Color.Green;
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PaymentDropdown.SelectedValue))
            {
                ErrorLabel.Text = "Please select a payment method.";
                return;
            }

            MsUser user = Session["user"] as MsUser;
            int userId = user.UserID;
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
                ErrorLabel.Text = "Checkout failed";
            }
        }
        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdateItem" || e.CommandName == "RemoveItem")
            {
                int jewelId = Convert.ToInt32(e.CommandArgument);
                int userId = ((MsUser)Session["user"]).UserID;

                GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;

                if (row == null) return;

                if (e.CommandName == "UpdateItem")
                {
                    TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;

                    if (txtQuantity != null && int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                    {
                        CartRepository.UpdateCartItemQuantity(userId, jewelId, quantity);
                    }
                }
                else if (e.CommandName == "RemoveItem")
                {
                    CartRepository.RemoveFromCart(userId, jewelId);
                }

                LoadCart();
            }
        }

    }
}