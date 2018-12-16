using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using BankWebApplication.Models;

namespace BankWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IKernel resolver;

        public static IAccountService service;

        static HomeController()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();

            service = resolver.Get<IAccountService>();
        }

        public ActionResult Index()
        {
            var accounts = service.GetAccounts();

            ViewBag.Accounts = accounts;

            return View();
        }

        public ActionResult Deposit(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public string Deposit(decimal? depositAmount)
        {
            HomeController.service.DepositMoney(TempData["Id"].ToString(), (decimal)depositAmount);
            return "На баланс начислено " + depositAmount;
        }

        public ActionResult Withdraw(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public string Withdraw(decimal? withdrawAmount)
        {
            service.WithdrawMoney(TempData["Id"].ToString(), (decimal)withdrawAmount);
            return "С баланса снято " + withdrawAmount;
        }

        public ActionResult Close(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public string Close()
        {
            string accountNumber = TempData["Id"].ToString();
            service.CloseAccount(accountNumber);
            return "Счет " + accountNumber + " был закрыт.";
        }

        public ActionResult Transfer(string AccountID)
        {
            TempData["Id"] = Url.RequestContext.RouteData.Values["id"];
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public string Transfer(string secondAccountID, decimal? transferAmount)
        {
            string accountNumber = TempData["Id"].ToString();
            service.TransferMoney(accountNumber, secondAccountID, (decimal)transferAmount);
            return "OK";
        }


    }
}