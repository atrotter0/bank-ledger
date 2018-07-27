using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class TransactionTests
    {
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
    }

}