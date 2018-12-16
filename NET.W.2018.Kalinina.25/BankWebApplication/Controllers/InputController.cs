using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class InputController : Controller
    {

        public ActionResult Deposit(string AccountID)
        {
            ViewBag.AccountID = AccountID;
            return View();
        }
    }
}