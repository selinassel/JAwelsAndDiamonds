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

    }
}