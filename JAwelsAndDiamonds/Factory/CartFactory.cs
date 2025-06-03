using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.Factory
{
    public class CartFactory
    {
        public Cart createNewCart(int userID, int jewelID, int quantity)
        {
            Cart cart = new Cart();
            cart.UserID = userID;
            cart.JewelID = jewelID;
            cart.Quantity = quantity;
            return cart;
        }
    }
}