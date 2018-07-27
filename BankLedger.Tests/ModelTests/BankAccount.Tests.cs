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
            BankAccount bankAccount = new BankAccount(account);
            UserAccount account2 = new UserAccount("frodo", "shire");
            bankAccount.Balance = 1.49;
            bankAccount.AccountOwner = account2;
            Assert.AreEqual(1.49, bankAccount.Balance);
            Assert.AreEqual(account2, bankAccount.AccountOwner);
        }

        [TestMethod]
        public void LastTransactionBalance_ReturnsZeroWhenNoTransactions_Double()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            BankAccount bankAccount = new BankAccount(account);
            Assert.AreEqual(0.00, bankAccount.LastTransactionBalance());
        }

        [TestMethod]
        public void LastTransactionBalance_ReturnsValueWhenTransactionsExist_Double()
        {
            UserAccount account = new UserAccount("balrog", "youshallnotpass");
            BankAccount bankAccount = new BankAccount(account);
            DateTime date = new DateTime(2025, 11, 18);
            Transaction transaction = new Transaction(bankAccount, date, "deposit", 50.00);
            Assert.AreEqual(50.00, bankAccount.LastTransactionBalance());
        }
    }
}
