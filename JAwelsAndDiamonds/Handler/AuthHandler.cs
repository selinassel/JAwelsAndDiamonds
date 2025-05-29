using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repo;

namespace JAwelsAndDiamonds.Handler
{
    public class AuthHandler
    {
        public static MsUser GetUserByEmailAndPassword(string email, string password)
        {
            return UserRepo.GetUserByEmailAndPassword(email, password);
        }
        public static void RegisterUser(string username, string password, string email, DateTime dob, string gender)
        {
            UserRepo.insertUser(username, password, email, dob, gender);
        }
    }
}