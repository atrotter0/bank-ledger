using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BankLedger.Controllers;
using BankLedger.Models;

namespace BankLedger.Tests
{
    [TestClass]
    public class AccountControllerTest : IDisposable
    {
        public void Dispose()
        {
            UserAccount.ClearAll();
            BankAccount.ClearAll();
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            AccountController controller = new AccountController();
            ActionResult New = controller.New();
            Assert.IsInstanceOfType(New, typeof(ActionResult));
        }

        [TestMethod]
        public void CreateAccount_ReturnsCorrectViewIfAccountIsNotFound_True()
        {
            AccountController controller = new AccountController();
            ActionResult CreateAccount = controller.CreateAccount("tom", "bombadil321");
            Assert.IsInstanceOfType(CreateAccount, typeof(RedirectToActionResult));
        }
        
        [TestMethod]
        public void CreateAccount_ReturnsCorrectViewIfAccountIsFound_True()
        {
            UserAccount user = new UserAccount("tom", "bombadil321");
            AccountController controller = new AccountController();
            ActionResult CreateAccount = controller.CreateAccount("tom", "bombadil321");
            Assert.IsInstanceOfType(CreateAccount, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Index_ReturnsCorrectViewWhenUserNotSignedIn_True()
        {
            AccountController controller = new AccountController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Index_ReturnsCorrectViewWhenUserSignedIn_True()
        {
            UserAccount user = new UserAccount("frodo", "shireishome");
            AccountController controller = new AccountController();
            ActionResult Index = controller.Index();
            Assert.IsInstanceOfType(Index, typeof(ActionResult));
        }

        [TestMethod]
        public void Login_ReturnsCorrectView_True()
        {
            AccountController controller = new AccountController();
            ActionResult Login = controller.Login();
            Assert.IsInstanceOfType(Login, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateLogin_ReturnsCorrectViewIfValidCredentials_True()
        {
            UserAccount user = new UserAccount("tom", "bombadil321");
            AccountController controller = new AccountController();
            ActionResult CreateLogin = controller.CreateLogin("tom", "bombadil321");
            Assert.IsInstanceOfType(CreateLogin, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void CreateLogin_ReturnsCorrectViewIfInValidCredentials_True()
        {
            UserAccount user = new UserAccount("tom", "bombadil321");
            AccountController controller = new AccountController();
            ActionResult CreateLogin = controller.CreateLogin("tom", "bombadil");
            Assert.IsInstanceOfType(CreateLogin, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Logout_ReturnsCorrectViewWhenUserSignedIn_True()
        {
            UserAccount user = new UserAccount("frodo", "shireishome");
            AccountController controller = new AccountController();
            ActionResult Logout = controller.Logout();
            Assert.IsInstanceOfType(Logout, typeof(ActionResult));
        }

        [TestMethod]
        public void Logout_ReturnsCorrectViewWhenUserNotSignedIn_True()
        {
            AccountController controller = new AccountController();
            ActionResult Logout = controller.Logout();
            Assert.IsInstanceOfType(Logout, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Error_ReturnsCorrectView_True()
        {
            AccountController controller = new AccountController();
            ActionResult Error = controller.Error();
            Assert.IsInstanceOfType(Error, typeof(ActionResult));
        }
    }
}
