using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class BankAccountTests : IDisposable
    {
        public void Dispose()
        {
            UserAccount.ClearAll();
            BankAccount.ClearAll();
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_True()
        {
            UserAccount account = new UserAccount("gandalf", "middleearth");
            UserAccount account2 = new UserAccount("frodo", "shire");
            account.BankAccount.Balance = 1.49;
            account.BankAccount.AccountOwner = account2;
            Assert.AreEqual(1.49, account.BankAccount.Balance);
            Assert.AreEqual(account2, account.BankAccount.AccountOwner);
        }

        [TestMethod]
        public void LastTransactionBalance_ReturnsZeroWhenNoTransactions_Double()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            Assert.AreEqual(0.00, account.BankAccount.LastTransactionBalance());
        }

        [TestMethod]
        public void LastTransactionBalance_ReturnsValueWhenTransactionsExist_Double()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            DateTime date = new DateTime(2025, 11, 18);
            Transaction transaction = new Transaction(account.BankAccount, date, "deposit", 50.00);
            Assert.AreEqual(50.00, account.BankAccount.LastTransactionBalance());
        }

        [TestMethod]
        public void IsPositiveBalance_ChecksIfBalanceIsGreaterThanZero_True()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            DateTime date = new DateTime(2025, 11, 18);
            account.BankAccount.Balance = 50.00;
            Assert.AreEqual(true, account.BankAccount.IsPositiveBalance(45));
        }

        [TestMethod]
        public void IsPositiveBalance_ChecksIfBalanceIsGreaterThanZero_False()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            DateTime date = new DateTime(2025, 11, 18);
            Assert.AreEqual(false, account.BankAccount.IsPositiveBalance(45));
        }
    }
}
