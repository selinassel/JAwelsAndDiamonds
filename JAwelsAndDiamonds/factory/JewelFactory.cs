using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
    public class JewelFactory
    {
        public MsJewel createNewJewel(int brandID, int categoryID, string jewelName, int jewelPrice, int jewelReleaseYear)
        {
            MsJewel jewel = new MsJewel();
            jewel.BrandID = brandID;
            jewel.CategoryID = categoryID;
            jewel.JewelName = jewelName;
            jewel.JewelPrice = jewelPrice;
            jewel.JewelReleaseYear = jewelReleaseYear;
            return jewel;
        }

    }
}