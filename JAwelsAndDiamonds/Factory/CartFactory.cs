using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.Factory
{
    public class CartFactory
    {
        public Cart createNewCart(int jewelID, int userID, int quantity)
        {
            MsJewel jewel = new MsJewel();
            Cart cart = new Cart();
            cart.JewelID = jewelID;
            cart.UserID = userID;
            cart.Quantity = quantity;
            return cart;
        }
    }
}