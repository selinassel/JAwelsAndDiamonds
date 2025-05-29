using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.Repo
{
    public class BrandRepo
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