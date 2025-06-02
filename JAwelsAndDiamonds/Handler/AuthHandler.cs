using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;

namespace JAwelsAndDiamonds.Handler
{
    public class AuthHandler
    {
        public static MsUser GetUserByEmailAndPassword(string email, string password)
        {
            return UserRepository.GetUserByEmailAndPassword(email, password);
        }
        public static void RegisterUser(string username, string password, string email, DateTime dob, string gender)
        {
            UserRepository.insertUser(username, password, email, dob, gender);
        }
        public static bool ChangePassword(int userId, string newPassword)
        {
            return UserRepository.UpdatePassword(userId, newPassword);
        }

    }
}