using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System.Collections.Generic;

namespace JAwelsAndDiamonds.Handler
{
    public class JewelHandler
    {
        JewelRepository jr = new JewelRepository();
        public List<MsJewel> ViewJewel()
        {
            return jr.ViewJewel();
        }

        public List<MsJewel> GetJewelDetails(int jewelID)
        {
            return jr.GetJewelDetails(jewelID);
        }

        public bool UpdateJewel(int jewelId, int brandId, int categoryId, string JewelName, int price, int jewelReleaseYear)
        {
            //bool success;
            return jr.updateJewel(jewelId, brandId, categoryId, JewelName, price, jewelReleaseYear);
        }
        public bool DeleteJewel(int jewelId)
        {
            return jr.DeleteJewel(jewelId);
        }

        public void AddJewel(int brandID, int categoryID, string name, int price, int releaseYear)
        {
            JewelRepository.insertJewel(brandID, categoryID, name, price, releaseYear);
        }

    }
}