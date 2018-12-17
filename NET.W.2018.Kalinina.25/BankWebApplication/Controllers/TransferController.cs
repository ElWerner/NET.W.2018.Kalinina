using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class TransferController : Controller
    {
        public ActionResult Transfer(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Transfer(string secondAccountID, decimal? transferAmount)
        {
            string accountNumber = TempData["Id"].ToString();
            HomeController.service.TransferMoney(accountNumber, secondAccountID, (decimal)transferAmount);
            return RedirectToAction("Index", "Home");
        }
    }
}