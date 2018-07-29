using System;
using Microsoft.AspNetCore.Mvc;
using BankLedger.Models;

namespace BankLedger.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("/account")]
        public ActionResult Index()
        {
            if (UserAccount.SignedIn != null)
            {
                UserAccount userAccount = UserAccount.SignedIn;
                return View(userAccount);
            }
            return RedirectToAction("Error");
        }

        [HttpGet("/signup")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/account/new")]
        public ActionResult CreateAccount(string username, string password)
        {
            if (!UserAccount.AccountList.ContainsKey(username))
            {
                UserAccount userAccount = new UserAccount(username, password);
                userAccount.SignIn();
                return RedirectToAction("Index");
            }
            return RedirectToAction("New");
        }

        [HttpGet("/login")]
        public ActionResult Login()
        {
            if (UserAccount.SignedIn == null) return View();
            return RedirectToAction("Error");
        }

        [HttpPost("/login")]
        public ActionResult CreateLogin(string username, string password)
        {
            if (UserAccount.ValidUserAndPassword(username, password))
            {
                UserAccount.AccountList[username].SignIn();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        [HttpGet("/logout")]
        public ActionResult Logout()
        {
            if (UserAccount.SignedIn != null)
            {
                UserAccount.SignedIn.SignOut();
                return View();
            }
            return RedirectToAction("Error");
        }

        [HttpGet("/error")]
        public ActionResult Error()
        {
            return View();
        }

        [HttpPost("/account/deposit/{amount}")]
        public ActionResult Deposit(float amount)
        {
            if (UserAccount.SignedIn != null)
            {
                double convertedAmount = Math.Round(System.Convert.ToDouble(amount), 2);
                UserAccount userAccount = UserAccount.SignedIn;
                DateTime date = DateTime.Now;
                Transaction transaction = new Transaction(userAccount.BankAccount, date, "deposit", convertedAmount);
                return Json(new { balance = userAccount.BankAccount.Balance });
            }
            return BadRequest();
        }

        [HttpPost("/account/withdraw/{amount}")]
        public ActionResult Withdraw(float amount)
        {
            if (UserAccount.SignedIn != null && UserAccount.SignedIn.BankAccount.NotNegativeBalance(amount))
            {
                double convertedAmount = Math.Round(System.Convert.ToDouble(amount), 2);
                UserAccount userAccount = UserAccount.SignedIn;
                DateTime date = DateTime.Now;
                Transaction transaction = new Transaction(userAccount.BankAccount, date, "withdrawal", convertedAmount);
                return Json(new { balance = userAccount.BankAccount.Balance });
            }
            return BadRequest();
        }
    }
}
