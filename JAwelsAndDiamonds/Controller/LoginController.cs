using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.Controller
{
    public class LoginController
    {
        public string Login(string email, string password, out MsUser user)
        {
            user = null;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email dan password harus diisi.";
            }

            user = AuthHandler.GetUserByEmailAndPassword(email, password);

            if (user == null)
            {
                return "Email atau password salah.";
            }

            return null;
        }
    }
}
