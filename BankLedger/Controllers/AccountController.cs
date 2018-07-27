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
        public ActionResult Create(UserAccount user)
        {
            UserAccount userAccount = new UserAccount(user.Username, user.Password);
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
