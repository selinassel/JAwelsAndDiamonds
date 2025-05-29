using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
    public class UserFactory
    {
        public MsUser CreateNewUser(string username, string password, string email, DateTime dob, string gender)
        {
            MsUser user = new MsUser();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserRole = "Customer";
            return user;

        }
    }
}