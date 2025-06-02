using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using System;
using System.Linq;

namespace JAwelsAndDiamonds.Repository
{
    public class UserRepository
    {
        static Database1Entities1 db = new Database1Entities1();

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
            UserFactory factory = new UserFactory();
            MsUser user = factory.CreateNewUser(username, password, email, dob, gender);

            db.MsUsers.Add(user);
            db.SaveChanges();
        }


        public static bool UpdatePassword(int userId, string newPassword)
        {
            MsUser user = db.MsUsers.Find(userId);
            if (user == null) return false;

            user.UserPassword = newPassword;
            db.SaveChanges();
            return true;
        }
        public static MsUser GetUserById(int userId)
        {
            return db.MsUsers.Find(userId);
        }

    }
}