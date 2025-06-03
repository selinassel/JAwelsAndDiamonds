
using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class CartRepository
    {
        Database1Entities1 db = new Database1Entities1();
        public static List<CartItemViewModel> GetCartByUserId(int userId)
        {
            using (var db = new Database1Entities1())
            {
                return db.Carts
                    .Include("MsJewel.MsBrand")
                    .Include("MsUser")
                    .Where(c => c.UserID == userId)
                    .Select(c => new CartItemViewModel
                    {
                        JewelID = c.JewelID,
                        JewelName = c.MsJewel.JewelName,
                        Price = c.MsJewel.JewelPrice,
                        Brand = c.MsJewel.MsBrand.BrandName,
                        Quantity = c.Quantity,
                        Subtotal = (c.MsJewel.JewelPrice) * (c.Quantity)
                    })
                    .ToList();
            }
        }


        public class CartItemViewModel
        {
            public int JewelID { get; set; }
            public string JewelName { get; set; }
            public int Price { get; set; }
            public string Brand { get; set; }
            public int Quantity { get; set; }
            public int Subtotal { get; set; }
        }


        public static void UpdateCartItemQuantity(int userId, int jewelId, int quantity)
        {
            using (var db = new Database1Entities1())
            {
                var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                if (cartItem != null)
                {
                    cartItem.Quantity = quantity;
                    db.SaveChanges();
                }
            }
        }
        public static void RemoveFromCart(int userId, int jewelId)
        {
            using (var db = new Database1Entities1())
            {
                var cartItem = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
                if (cartItem != null)
                {
                    db.Carts.Remove(cartItem);
                    db.SaveChanges();
                }
            }
        }

        public static void Checkout(int userId, string paymentMethod)
        {
            using (var db = new Database1Entities1())
            {
                var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();
                if (cartItems.Count == 0) return;

                var header = new TransactionHeader
                {
                    UserID = userId,
                    TransactionDate = DateTime.Now,
                    PaymentMethod = paymentMethod
                };

                TransactionFactory factory = new TransactionFactory();
                factory.createNewTransaction(userId, DateTime.Now, paymentMethod, "Payment Pending");

                db.TransactionHeaders.Add(header);
                db.SaveChanges();

                foreach (var item in cartItems)
                {
                    var detail = new TransactionDetail
                    {
                        TransactionID = header.TransactionID,
                        JewelID = item.JewelID,
                        Quantity = item.Quantity
                    };
                    db.TransactionDetails.Add(detail);
                }



                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
            }
        }


        public void ClearCartByUserId(int userId)
        {
            using (var db = new Database1Entities1())
            {
                var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();

                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
            }
        }



        public void AddToCart(int UserID, int JewelID, int Quantity)
        {
            CartFactory factory = new CartFactory();
            Cart cart = factory.createNewCart(UserID, JewelID, Quantity);

            db.Carts.Add(cart);
            db.SaveChanges();
        }
    }
}