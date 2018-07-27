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
        public ActionResult Create()
        {
            return RedirectToAction("Index");
        }
    }
}
