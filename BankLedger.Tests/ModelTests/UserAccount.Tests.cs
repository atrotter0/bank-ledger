using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class UserAccountTest : IDisposable
    {
        public void Dispose()
        {
            UserAccount.ClearAll();
        }

        [TestMethod]
        public void GetSetProperties_GetsSetsProperties_True()
        {
            UserAccount account = new UserAccount("frodo", "123");
            account.Username = "sam";
            account.Password = "1234";
            Assert.AreEqual("sam", account.Username);
            Assert.AreEqual("1234", account.Password);
        }

        [TestMethod]
        public void GetSetAccount_GetsSetsAccounts_True()
        {
            UserAccount account = new UserAccount("frodo", "123");
            Dictionary<string, string> expectedAccounts = new Dictionary<string, string>() {};
            expectedAccounts.Add(account.Username, account.Password);
            CollectionAssert.AreEqual(expectedAccounts, UserAccount.Accounts);
        }
    }
}
