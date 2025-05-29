using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Factory;

namespace JAwelsAndDiamonds.Repo
{
    public class UserRepo
    {
        static Database1Entities1 db = new Database1Entities1 ();

        public static MsUser GetUserByEmailAndPassword(string email, string password)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserEmail == email && x.UserPassword == password);
        }

        public static MsUser GetUserByEmail(string email)
        {
            return db.MsUsers.FirstOrDefault(x => x.UserEmail == email);
        }

        public static void insertUser(string username, string password, string email, DateTime dob, string gender)
        {
            UserFactory factory = new UserFactory ();
            MsUser user = factory.CreateNewUser(username, password, email, dob, gender);

            db.MsUsers.Add(user);
            db.SaveChanges();
        }
    }
}