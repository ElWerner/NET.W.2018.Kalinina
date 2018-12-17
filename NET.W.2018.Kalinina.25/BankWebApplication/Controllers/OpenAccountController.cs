using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;

namespace BankWebApplication.Controllers
{
    public class OpenAccountController : Controller
    {
        public ActionResult Open()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Open(string accountNumber, string firstName, string lastName, int accountType)
        {
            HomeController.service.OpenAccount(lastName, firstName, accountNumber, 0, 0, (AccountType)accountType);
            return RedirectToAction("Index", "Home");
        }
    }
}