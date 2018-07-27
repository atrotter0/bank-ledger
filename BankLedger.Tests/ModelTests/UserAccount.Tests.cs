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
            Assert.AreEqual(false, account.IsSignedIn);
        }

        [TestMethod]
        public void GetSetAccountList_GetsSetsAccountList_True()
        {
            UserAccount account = new UserAccount("frodo", "123");
            Dictionary<string, UserAccount> expectedAccountList = new Dictionary<string, UserAccount>() {};
            expectedAccountList.Add(account.Username, account);
            CollectionAssert.AreEqual(expectedAccountList, UserAccount.AccountList);
        }

        [TestMethod]
        public void SignIn_SignsUserIn_True()
        {
            UserAccount account = new UserAccount("frodo", "123");
            account.SignIn();
            Assert.AreEqual(UserAccount.SignedIn, account);
            Assert.AreEqual(account.IsSignedIn, true);
        }
    }
}
