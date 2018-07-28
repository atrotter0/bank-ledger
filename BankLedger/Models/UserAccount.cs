using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BankLedger;

namespace BankLedger.Models
{
    public class UserAccount
    {
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public BankAccount BankAccount { get; set; }
        public bool IsSignedIn { get; set; }
        public static UserAccount SignedIn { get; set; }
        public static Dictionary<string, UserAccount> AccountList = new Dictionary<string, UserAccount>() {};

        public UserAccount(string username, string password)
        {
            Username = username;
            Password = password;
            BankAccount = new BankAccount(this);
            AccountList.Add(this.Username, this);
        }

        public static void ClearAll()
        {
            AccountList.Clear();
        }

        public void SignIn()
        {
            this.IsSignedIn = true;
            UserAccount.SignedIn = this;
        }

        public void SignOut()
        {
            this.IsSignedIn = false;
            UserAccount.SignedIn = null;
        }
    }
}
