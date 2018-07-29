using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class BankAccount
    {
        public const double ZERO_BALANCE = 0.00;
        public UserAccount AccountOwner { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
        public double Balance { get; set; }
        public static Dictionary<string, BankAccount> BankAccounts = new Dictionary<string, BankAccount>() {};

        public BankAccount(UserAccount account)
        {
            AccountOwner = account;
            TransactionHistory = new List<Transaction>() {};
            Balance = this.LastTransactionBalance();
            BankAccounts.Add(AccountOwner.Username, this);
        }

        public static void ClearAll()
        {
            BankAccounts.Clear();
        }

        public double LastTransactionBalance()
        {
            if (this.TransactionHistory.Count > 0)
            {
                int lastItem = this.TransactionHistory.Count - 1;
                return this.TransactionHistory[lastItem].Balance;
            }
            return ZERO_BALANCE;
        }

        public bool IsPositiveBalance(float amount)
        {
            return (this.Balance - amount >= 0);
        }
    }
}
