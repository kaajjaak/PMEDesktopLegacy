using System;
using System.Collections.Generic;
using System.Text;

namespace Productvity_Made_Easy
{
    class LoginAccount
    {
        private string Username;
        private string Password;

        public LoginAccount(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string username { get => Username; set => Username = value; }
        public string password { get => Password; set => Password = value; }
    }
}
