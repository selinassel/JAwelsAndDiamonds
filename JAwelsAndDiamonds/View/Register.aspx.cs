using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JAwelsAndDiamonds.Model;

namespace JAwelsAndDiamonds.View
{
    public partial class Register : System.Web.UI.Page
    {
        Database1Entities1 db = new Database1Entities1 ();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registButton_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string username = usernameBox.Text;
            string password = passwordBox.Text;
            string confirmPw = confirmPwBox.Text;
            string gender = genderMale.Checked ? "Male" : genderFemale.Checked ? "Female" : "";
            DateTime dob;

            if(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMsg.Text = "Email harus sesuai format";
                return;
            }
            if(db.MsUsers.Any(x => x.UserEmail == email))
            {
                errorMsg.Text = "Email sudah terdaftar";
                return;
            }

            if(username.Length < 3 || username.Length > 25)
            {
                errorMsg.Text = "Username harus 3-25 karakter";
                return;
            }
            if(username.)

        }
    }
}