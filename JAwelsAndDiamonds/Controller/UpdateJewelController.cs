using JAwelsAndDiamonds.Handler;
using System;

namespace JAwelsAndDiamonds.Controller
{
    public class UpdateJewelController
    {
        JewelHandler jh = new JewelHandler();
        public bool UpdateJewel(int jewelId, string name, string categoryID, string brandID, string priceTxt, string releaseYearTxt, out string errorMessage)
        {
            errorMessage = "";

            if (name.Length < 3 || name.Length > 25)
            {
                errorMessage = "Jewel name must be between 3-25 characters.";
                return false;
            }

            if (string.IsNullOrEmpty(categoryID))
            {
                errorMessage = "Please select a category.";
                return false;
            }

            if (string.IsNullOrEmpty(brandID))
            {
                errorMessage = "Please select a brand.";
                return false;
            }

            if (!int.TryParse(priceTxt, out int price) || price <= 25)
            {
                errorMessage = "Price must be a number and more than $25.";
                return false;
            }

            if (!int.TryParse(releaseYearTxt, out int releaseYear))
            {
                errorMessage = "Release year must be a valid number.";
                return false;
            }

            if (releaseYear >= DateTime.Now.Year)
            {
                errorMessage = "Release year must be less than current year.";
                return false;
            }

            bool result = jh.UpdateJewel(jewelId, Convert.ToInt32(brandID), Convert.ToInt32(categoryID), name, price, releaseYear);

            //bool result = JewelHandler.UpdateJewel(
            //    jewelId,
            //    Convert.ToInt32(brandID),
            //    Convert.ToInt32(categoryID),
            //    name,
            //    price,
            //    releaseYear);

            if (!result)
            {
                errorMessage = "Failed to update jewel, please try again.";
                return false;
            }

            return true;
        }

    }
}
