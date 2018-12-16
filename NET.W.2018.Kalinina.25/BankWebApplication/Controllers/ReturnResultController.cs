using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankWebApplication.Controllers
{
    public class ReturnResultController : Controller
    {

        public string Deposit(float depositAmount)
        {
            HomeController.service.WithdrawMoney(ViewBag.AccountID, (decimal)depositAmount);
            return "На баланс начислено " + depositAmount;
        }
    }
}