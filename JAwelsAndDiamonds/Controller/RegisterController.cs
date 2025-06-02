using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class RegisterController
{
    public string registerUser(string email, string username, string password, string confirmPw, string gender, string dobInput)
    {
        Database1Entities1 db = new Database1Entities1();
        DateTime dob;

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            return "Email harus sesuai format";
        }
        if (db.MsUsers.Any(x => x.UserEmail == email))
        {
            return "Email sudah terdaftar";
        }

        if (username.Length < 3 || username.Length > 25)
        {
            return "Username length must be 3-25 characters";
        }

        if (password.Length < 8 || password.Length > 20 || !password.All(char.IsLetterOrDigit))
        {
            return "Password length must be 8-20 characters and alphanumeric only";
        }

        if (password != confirmPw)
        {
            return "Password doesn't match";
        }

        if (gender != "Male" && gender != "Female")
        {
            return "Gender must be selected";
        }

        if (!DateTime.TryParse(dobInput, out dob))
        {
            return "Date of Birth tidak valid.";
        }
        if (dob >= new DateTime(2010, 1, 1))
        {
            return "Date of Birth must be earlier than 01/01/2010";
        }

        // Register
        AuthHandler.RegisterUser(username, password, email, dob, gender);
        return "success";
    }
}
