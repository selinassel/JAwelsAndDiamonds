using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using System.Text.RegularExpressions;

namespace JAwelsAndDiamonds.Controller
{
    public class PasswordController
    {
        Database1Entities1 db = new Database1Entities1();
        public string ChangePassword(MsUser user, string oldPass, string newPass, string confirmPass, out string cssClass)
        {
            cssClass = "error-msg";

            if (user == null)
                return "User session expired. Please login again.";

            if (oldPass != user.UserPassword)
                return "Old password is incorrect.";

            if (newPass.Length < 8 || newPass.Length > 25)
                return "New password must be between 8 and 25 characters.";

            if (!Regex.IsMatch(newPass, "^[a-zA-Z0-9]+$"))
                return "New password must be alphanumeric.";

            if (newPass != confirmPass)
                return "Confirm password must match the new password.";

            bool isSuccess = AuthHandler.ChangePassword(user.UserID, newPass);
            if (isSuccess)
            {
                cssClass = "success-msg";
                return "Password changed successfully.";
            }

            return "Failed to change password. Please try again.";
        }
    }
}