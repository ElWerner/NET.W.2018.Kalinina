using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class DepositController : Controller
    {
        public ActionResult Deposit(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Deposit(decimal depositAmount)
        {
            HomeController.service.DepositMoney(TempData["Id"].ToString(), (decimal)depositAmount);
            return RedirectToAction("Index", "Home");
        }
    }
}