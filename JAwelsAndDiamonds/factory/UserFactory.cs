using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
    public class UserFactory
    {
        public MsUser CreateNewUser(string username, string password, string email, DateTime DOB, string gender, string role)
        {
            MsUser user = new MsUser();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserDOB = DOB;
            user.UserGender = gender;
            user.UserRole = role;
            return user;

        }
    }
}