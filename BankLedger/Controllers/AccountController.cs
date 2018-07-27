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
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
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
                BankAccount account = new BankAccount(userAccount);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("New");
            }
        }

        [HttpGet("/login")]
        public ActionResult Login()
        {
            if (UserAccount.SignedIn == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost("/login")]
        public ActionResult CreateLogin(string username, string password)
        {
            if (UserAccount.AccountList.ContainsKey(username))
            {
                UserAccount userAccount = UserAccount.AccountList[username];
                userAccount.SignIn();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet("/logout")]
        public ActionResult Logout()
        {
            if (UserAccount.SignedIn != null)
            {
                UserAccount userAccount = UserAccount.SignedIn;
                userAccount.SignOut();
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet("/error")]
        public ActionResult Error()
        {
            return View();
        }
    }
}
