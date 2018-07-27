using System;
using System.Collections.Generic;
using BankLedger;

namespace BankLedger.Models
{
    public class Bank
    {
        public UserAccount Owner { get; set; }
        public decimal Balance { get; set; }
        public Transaction TransactionHistory { get; set; }
        public static Dictionary<string, Bank> AccountList = new Dictionary<string, Bank>() {};

        public Bank(UserAccount owner)
        {
            
        }
    }
}