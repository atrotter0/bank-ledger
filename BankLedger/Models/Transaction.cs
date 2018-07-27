using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class Transaction
    {
        public BankAccount Account { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }

        public Transaction(BankAccount bankAccount, DateTime date, string type, double amount)
        {
            Account = bankAccount;
            TransactionDate = date;
            Type = type;
            Amount = amount;
            this.CalculateBalance();
            this.AddTransactionToAccount(this);
        }

        public void CalculateBalance()
        {
            if (this.Type == "withdrawal")
            {
                this.Balance = this.Account.Balance -= this.Amount;
            }
            else
            {
                this.Balance = this.Account.Balance += this.Amount;
            }
            this.Account.Balance = this.Balance;
        }

        public void AddTransactionToAccount(Transaction transaction)
        {
            this.Account.TransactionHistory.Add(transaction);
        }
    }
}
