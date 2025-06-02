using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class JewelRepository
    {
        static Database1Entities1 db = new Database1Entities1();
        //JewelFactory jf = new JewelFactory();

        public JewelRepository() { }

        public static void insertJewel(int brandId, int categoryId, string JewelName, int price, int jewelReleaseYear)
        {
            JewelFactory factory = new JewelFactory();
            MsJewel jewel = factory.createNewJewel(brandId, categoryId, JewelName, price, jewelReleaseYear);

            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

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

        public List<MsJewel> ViewUpdateJewel()
        {
            return db.MsJewels
                .Select(j => new
                {
                    j.JewelName,
                    j.CategoryID,
                    j.BrandID,
                    j.JewelPrice,
                    j.JewelReleaseYear
                })
                .AsEnumerable()
                .Select(j => new MsJewel
                {
                    CategoryID = j.CategoryID,
                    JewelName = j.JewelName,
                    BrandID = j.BrandID,
                    JewelPrice = j.JewelPrice,
                    JewelReleaseYear = j.JewelReleaseYear
                })
                .ToList();
        }

        public bool updateJewel(int jewelId, int brandId, int categoryId, string name, int price, int releaseYear)
        {
            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == jewelId);
            if (jewel == null)
            {
                return false;
            }

            jewel.JewelName = name;
            jewel.CategoryID = categoryId;
            jewel.BrandID = brandId;
            jewel.JewelPrice = price;
            jewel.JewelReleaseYear = releaseYear;

            db.SaveChanges();
            return true;
        }

        public bool DeleteJewel(int jewelId)
        {
            var jewel = db.MsJewels.FirstOrDefault(j => j.JewelID == jewelId);
            if (jewel == null)
            {
                return false;
            }

            db.MsJewels.Remove(jewel);
            db.SaveChanges();
            return true;
        }


    }
}
