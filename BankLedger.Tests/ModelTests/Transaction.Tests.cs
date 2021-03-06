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
            DateTime date1 = new DateTime(2025, 07, 26);
            DateTime date2 = new DateTime(2025, 08, 26);
            Transaction newTransaction = new Transaction(user.BankAccount, date1, "withdrawal", 100.00f);
            newTransaction.TransactionDate = date2;
            newTransaction.Type = "deposit";
            Assert.AreEqual(date2, newTransaction.TransactionDate);
            Assert.AreEqual("deposit", newTransaction.Type);
        }

        [TestMethod]
        public void CalculateBalance_CalculateBalanceForDeposit_Double()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            user.BankAccount.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 18);
            Transaction transaction = new Transaction(user.BankAccount, date, "deposit", 10.00f);
            Assert.AreEqual(65.50, transaction.Balance);
            Assert.AreEqual(65.50, transaction.Account.Balance);
        }

        [TestMethod]
        public void CalculateBalance_CalculateBalanceForWithdrawal_Double()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            user.BankAccount.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 19);
            Transaction transaction = new Transaction(user.BankAccount, date, "withdrawal", 100.00f);
            Assert.AreEqual(-44.50, transaction.Balance);
            Assert.AreEqual(-44.50, transaction.Account.Balance);
        }

        [TestMethod]
        public void AddTransactionToAccount_AddsTransactionToAccount_True()
        {
            UserAccount user = new UserAccount("aragorn", "trueKing");
            user.BankAccount.Balance = 55.50;
            DateTime date = new DateTime(2025, 11, 19);
            Transaction transaction = new Transaction(user.BankAccount, date, "withdrawal", 100.00f);
            List<Transaction> expectedTransactions = new List<Transaction>() { transaction };
            CollectionAssert.AreEqual(expectedTransactions, user.BankAccount.TransactionHistory);
        }
    }
}
