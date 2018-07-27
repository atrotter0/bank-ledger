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
    }
}
