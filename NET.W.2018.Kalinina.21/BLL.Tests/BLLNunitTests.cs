using System;
using NUnit.Framework;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using BLL.ServiceImplementation;
using Ninject;

namespace BLL.Tests
{
    [TestFixture]
    public class BLLNunitTests
    {
        private static IKernel resolver = new StandardKernel();


        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base)]
        public void BLL_CreateNewAccount_Test(string lastName, string firstName, string accountID, decimal invoiceAmount, double bonusScores, AccountType accountType)
        {
            resolver.ConfigurateResolver();
            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);

            BankAccount actualAccount = service.GetAccountByID(accountID);

            Assert.AreEqual(lastName, actualAccount.Owner.LastName);
            Assert.AreEqual(firstName, actualAccount.Owner.FirstName);
            Assert.AreEqual(invoiceAmount, actualAccount.InvoiceAmount);
            Assert.AreEqual(bonusScores, actualAccount.BonuseScores);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, 100, ExpectedResult = 400)]
        public decimal BLL_Withdraw_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType, decimal withdrawAmount)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);

            service.WithdrawMoney(accountID, withdrawAmount);
            BankAccount account = service.GetAccountByID(accountID);

            return account.InvoiceAmount;
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, 100, ExpectedResult = 600)]
        public decimal BLL_Deposit_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType, decimal depositAmount)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);

            service.DepositMoney(accountID, depositAmount);
            BankAccount account = service.GetAccountByID(accountID);

            return account.InvoiceAmount;
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, ExpectedResult = true)]
        public bool BLL_CloseAccount_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);

            service.CloseAccount(accountID);
            BankAccount account = service.GetAccountByID(accountID);

            return account.IsClosed;
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, -100)]
        public void BLL_Withdraw_ArgumentOutOfRangeException_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType, decimal withdrawAmount)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);

            
            Assert.Throws<ArgumentOutOfRangeException>(() => service.WithdrawMoney(accountID, withdrawAmount));
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, 1000)]
        public void BLL_Withdraw_Exception_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType, decimal withdrawAmount)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);


            Assert.Throws<Exception>(() => service.WithdrawMoney(accountID, withdrawAmount));
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, AccountType.Base, -100)]
        public void BLL_Deposit_ArgumentOutOfRangeException_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType, decimal withdrawAmount)
        {
            resolver.ConfigurateResolver();

            IAccountService service = resolver.Get<IAccountService>();
            service.OpenAccount(lastName, firstName, accountID, invoiceAmount, bonusScores, accountType);


            Assert.Throws<ArgumentOutOfRangeException>(() => service.DepositMoney(accountID, withdrawAmount));
        }
    }
}
