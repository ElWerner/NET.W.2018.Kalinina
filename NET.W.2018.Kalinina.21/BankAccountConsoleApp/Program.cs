using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;


namespace BankAccountConsoleApp
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base);
            service.OpenAccount("Petrov", "Petr", "454121313f", 100, 0, AccountType.Gold);
            service.OpenAccount("Fedorova", "Maria", "54121ef21", 1000, 0, AccountType.Platinum);

            var accounts = service.GetAccounts();
            ListInput(accounts);

            service.WithdrawMoney("5523664212", 20);
            service.DepositMoney("454121313f", 300);
            service.CloseAccount("54121ef21");

            Console.WriteLine();

            accounts = service.GetAccounts();
            ListInput(accounts);


            Console.ReadLine();
        }

        private static void ListInput(IEnumerable<BankAccount> list)
        {
            foreach (var account in list)
            {
                Console.WriteLine(account);
            }

            Console.WriteLine();
        }
    }
}
