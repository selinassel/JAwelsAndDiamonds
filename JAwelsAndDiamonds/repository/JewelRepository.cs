using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
    public class JewelRepository
    {
        Database1Entities1 db = new Database1Entities1();
        JewelFactory jf = new JewelFactory();

        public JewelRepository() { }

        // Fixed method to return a List<MsJewel> instead of a single MsJewel  
        public List<MsJewel> GetJewelDetails(int jewelID)
        {
            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == jewelID);
            return jewel != null ? new List<MsJewel> { jewel } : new List<MsJewel>();
        }

        public List<MsJewel> ViewJewel()
        {
            return db.MsJewels
                .Select(j => new
                {
                    j.JewelID,
                    j.JewelName,
                    j.JewelPrice
                })
                .AsEnumerable()
                .Select(j => new MsJewel
                {
                    JewelID = j.JewelID,
                    JewelName = j.JewelName,
                    JewelPrice = j.JewelPrice
                })
                .ToList();
        }
    }
}
