using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public static Dictionary<string, string> Accounts = new Dictionary<string, string>() {};

        public UserAccount(string username, string password)
        {
            Username = username;
            Password = password;
            Accounts.Add(this.Username, this.Password);
        }

        public static void ClearAll()
        {
            Accounts.Clear();
        }
    }
}
