using Microsoft.AspNetCore.Mvc;
using BankLedger.Models;

namespace BankLedger.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet("/signup")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/account/new")]
        public ActionResult Create(string username, string password)
        {
            UserAccount userAccount = new UserAccount(username, password);
            userAccount.SignIn();
            BankAccount account = new BankAccount(userAccount);
            return RedirectToAction("Index");
        }

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

        [HttpGet("/error")]
        public ActionResult Error()
        {
            return View();
        }
    }
}
