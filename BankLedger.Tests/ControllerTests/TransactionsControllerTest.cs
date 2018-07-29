using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BankLedger.Controllers;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class TransactionsControllerTest : IDisposable
    {
        public void Dispose()
        {
            UserAccount.ClearAll();
            BankAccount.ClearAll();
        }

        [TestMethod]
        public void Index_ReturnsCorrectViewWhenUserNotSignedIn_True()
        {
            TransactionsController controller = new TransactionsController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Index_ReturnsCorrectViewWhenUserSignedIn_True()
        {
            UserAccount user = new UserAccount("frodo", "shire");
            TransactionsController controller = new TransactionsController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(ActionResult));
        }
    }
}
