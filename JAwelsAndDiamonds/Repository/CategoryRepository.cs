using JAwelsAndDiamonds.Model;
using System.Collections.Generic;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class CategoryRepository
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