using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class BankAccount
    {
        public UserAccount AccountOwner { get; set; }
        public double Balance { get; set; }
        public Transaction TransactionHistory { get; set; }
        public static Dictionary<string, BankAccount> BankAccounts = new Dictionary<string, BankAccount>() {};

        public BankAccount(UserAccount account)
        {
            AccountOwner = account;
            Balance = 0.00;
            BankAccounts.Add(AccountOwner.Username, this);
        }

        public static void ClearAll()
        {
            BankAccounts.Clear();
        }
    }
}