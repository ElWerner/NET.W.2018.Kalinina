using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLib;

namespace BankAccuntConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountStorage storage = new BankAccountStorage("BankAccountStorage.bin");

            BankAccountService service = new BankAccountService();

            BankAccount account1 = new BankAccount("454545nn45", "Ivan", "Petrov", 596.30m, 0.15, BancAccountType.Gold);
            BankAccount account2 = new BankAccount("56dj8533d2", "Sergei", "Sidorov", 0m, 0, BancAccountType.Base);
            BankAccount account3 = new BankAccount("45jnd45snn", "Elena", "Ivanova", 100m, 1, BancAccountType.Platinum);

            List<BankAccount> bankAccounts = new List<BankAccount>() { account1, account2, account3 };
            ListInput(bankAccounts);

            service.WriteAccounts(storage, bankAccounts);

            service.WithdrawMoney(100m, bankAccounts[0]);
            service.DepositMoney(10m, bankAccounts[1]);
            service.CloseAccount(bankAccounts[2]);
            ListInput(bankAccounts);

            bankAccounts = service.ReadAccounts(storage);
            ListInput(bankAccounts);

            Console.ReadLine();
        }

        private static void ListInput(List<BankAccount> list)
        {
            foreach(var account in list)
            {
                Console.WriteLine(account);
            }

            Console.WriteLine();
        }
    }
}
