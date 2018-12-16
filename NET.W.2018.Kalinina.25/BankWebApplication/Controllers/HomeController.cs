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


    }
}