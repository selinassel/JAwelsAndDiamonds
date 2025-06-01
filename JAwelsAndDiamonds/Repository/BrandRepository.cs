using JAwelsAndDiamonds.Model;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class BrandRepository
    {
        public static List<MsBrand> GetAllBrands()
        {
            using (var db = new Database1Entities1())
            {
                return db.MsBrands.ToList();
            }
        }
    }
}