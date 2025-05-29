using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.Repo
{
    public class CategoryRepo
    {
        public static List<MsCategory> GetAllCategories()
        {
            using (var db = new Database1Entities1())
            {
                return db.MsCategories.ToList();
            }
        }
    }
}