using JAwelsAndDiamonds.Model;
using System;

namespace JAwelsAndDiamonds.Factory
{
    public class UserFactory
    {
        public MsUser CreateNewUser(string username, string password, string email, DateTime DOB, string gender)
        {
            MsUser user = new MsUser();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = DOB;
            user.UserGender = gender;
            user.UserRole = "Customer";
            return user;

        }
    }
}