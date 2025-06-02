using JAwelsAndDiamonds.Handler;
using System;

namespace JAwelsAndDiamonds.Controller
{
    public class AddJewelController
    {
        JewelHandler handler = new JewelHandler();

        public string AddJewel(string name, string priceTxt, string release, string categoryIDStr, string brandIDStr)
        {
            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel name length must be between 3-25 characters";
            }

            if (string.IsNullOrEmpty(categoryIDStr) || !int.TryParse(categoryIDStr, out int categoryID))
            {
                return "Please select a valid category";
            }

            if (string.IsNullOrEmpty(brandIDStr) || !int.TryParse(brandIDStr, out int brandID))
            {
                return "Please select a valid brand";
            }

            if (!int.TryParse(priceTxt.Replace("$", "").Trim(), out int price))
            {
                return "Price must be a valid number";
            }

            if (price < 25)
            {
                return "Price must be at least $25";
            }

            if (!int.TryParse(release, out int releaseYear) || releaseYear > DateTime.Now.Year)
            {
                return "Release date must be a valid year and not in the future";
            }

            handler.AddJewel(brandID, categoryID, name, price, releaseYear);
            return null;
        }
    }
}