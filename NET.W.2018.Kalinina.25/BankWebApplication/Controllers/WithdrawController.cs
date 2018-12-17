using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class WithdrawController : Controller
    {
        public ActionResult Withdraw(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Withdraw(decimal withdrawAmount)
        {
            HomeController.service.WithdrawMoney(TempData["Id"].ToString(), (decimal)withdrawAmount);
            return RedirectToAction("Index", "Home");
        }
    }
}