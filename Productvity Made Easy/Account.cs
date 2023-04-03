using System;
using System.Collections.Generic;
using System.Text;

namespace Productvity_Made_Easy
{
    class Account
    {
        private string Username;
        private string Token;

        public Account(string username, string token)
        {
            this.Username = username;
            this.Token = token;
        }

        public string username { get => Username; set => Username = value; }
        public string token { get => Token; set => Token = value; }
    }
}
