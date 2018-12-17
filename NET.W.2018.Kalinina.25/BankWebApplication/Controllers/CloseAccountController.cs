using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class CloseAccountController : Controller
    {
        public ActionResult Close(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Close()
        {
            string accountNumber = TempData["Id"].ToString();
            HomeController.service.CloseAccount(accountNumber);
            return RedirectToAction("Index", "Home"); ;
        }
    }
}