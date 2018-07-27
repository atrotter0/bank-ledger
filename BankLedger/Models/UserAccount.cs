using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool SignedIn { get; set; }
        public static Dictionary<string, string> Credentials = new Dictionary<string, string>() {};
        public static Dictionary<string, UserAccount> AccountList = new Dictionary<string, UserAccount>() {};

        public UserAccount(string username, string password)
        {
            Username = username;
            Password = password;
            Credentials.Add(this.Username, this.Password);
            AccountList.Add(this.Username, this);
        }

        public static void ClearAll()
        {
            Credentials.Clear();
            AccountList.Clear();
        }
    }
}
