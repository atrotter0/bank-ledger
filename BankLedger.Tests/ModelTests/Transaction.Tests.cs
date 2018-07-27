using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class TransactionTests : IDisposable
    {
        public void Dispose()
        {
            UserAccount.ClearAll();
            BankAccount.ClearAll();
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_True()
        {
            UserAccount user = new UserAccount("bilbo", "oneRing");
            BankAccount account = new BankAccount(user);
            DateTime date1 = new DateTime(2025, 07, 26);
            DateTime date2 = new DateTime(2025, 08, 26);
            Transaction newTransaction = new Transaction(account, date1, "withdrawal", 100.00);
            newTransaction.TransactionDate = date2;
            newTransaction.Type = "deposit";
            Assert.AreEqual(date2, newTransaction.TransactionDate);
            Assert.AreEqual("deposit", newTransaction.Type);
        }

        [TestMethod]
        public void CalculateBalance_CalculateBalanceForDeposit_Double()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            BankAccount account = new BankAccount(user);
            account.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 18);
            Transaction transaction = new Transaction(account, date, "deposit", 10.00);
            Assert.AreEqual(65.50, transaction.Balance);
            Assert.AreEqual(65.50, transaction.Account.Balance);
        }

        [TestMethod]
        public void CalculateBalance_CalculateBalanceForWithdrawal_Double()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            BankAccount account = new BankAccount(user);
            account.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 19);
            Transaction transaction = new Transaction(account, date, "withdrawal", 100.00);
            Assert.AreEqual(-44.50, transaction.Balance);
            Assert.AreEqual(-44.50, transaction.Account.Balance);
        }

        [TestMethod]
        public void AddTransactionToAccount_AddsTransactionToAccount_True()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            BankAccount account = new BankAccount(user);
            account.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 19);
            Transaction transaction = new Transaction(account, date, "withdrawal", 100.00);
            List<Transaction> expectedTransactions = new List<Transaction>() { transaction };
            CollectionAssert.AreEqual(expectedTransactions, account.TransactionHistory);
        }
    }
}
