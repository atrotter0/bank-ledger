using System;
using Microsoft.AspNetCore.Mvc;
using BankLedger.Models;

namespace BankLedger.Controllers
{
    public class TransactionsController : Controller
    {
        [HttpGet("/account/transactions")]
        public ActionResult Index()
        {
            if (UserAccount.SignedIn != null)
            {
                return View(UserAccount.SignedIn);
            }
            return RedirectToAction("Error");
        }
    }
}
