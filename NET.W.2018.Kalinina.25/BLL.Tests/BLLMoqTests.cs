using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interfaces;

namespace BLL.Tests
{
    [TestFixture]
    class BLLMoqTests
    {
        [TestCase]
        public void BLL_GetAccounts_Test()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetAccounts()).Returns(new List<BankAccount>());
            IAccountService service = new BankAccountService(mock.Object);

            var accounts = service.GetAccounts();

            Assert.IsNotNull(accounts);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0)]
        public void BLL_FindAccounByID_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores)
        {
            BankAccount account = new BaseAccount(new AccountOwner(firstName, lastName), accountID, invoiceAmount, bonusScores);
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.FindAccountByID(It.IsAny<string>())).Returns(account);
            IAccountService service = new BankAccountService(mock.Object);

            var actualAccount = service.GetAccountByID(accountID);

            Assert.NotNull(account);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0)]
        public void BLL_GetAccountByIdExecute_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores)
        {
            var mock = new Mock<IRepository>();
            IAccountService service = new BankAccountService(mock.Object);
            service.GetAccountByID(accountID);
            mock.Verify(a => a.FindAccountByID(accountID));
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, 100)]
        public void BLL_WithdrawExecute_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, decimal withdrawAmount)
        {
            BankAccount account = new BaseAccount(new AccountOwner(firstName, lastName), accountID, invoiceAmount, bonusScores);
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.FindAccountByID(accountID)).Returns(account);
            IAccountService service = new BankAccountService(mock.Object);
            service.WithdrawMoney(accountID, withdrawAmount);

            Assert.AreEqual(400, account.InvoiceAmount);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, 100)]
        public void BLL_DepositExecute_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, decimal withdrawAmount)
        {
            BankAccount account = new BaseAccount(new AccountOwner(firstName, lastName), accountID, invoiceAmount, bonusScores);
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.FindAccountByID(accountID)).Returns(account);
            IAccountService service = new BankAccountService(mock.Object);
            service.DepositMoney(accountID, withdrawAmount);

            Assert.AreEqual(600, account.InvoiceAmount);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0)]
        public void BLL_CloseAccountExecute_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores)
        {
            BankAccount account = new BaseAccount(new AccountOwner(firstName, lastName), accountID, invoiceAmount, bonusScores);
            account.IsClosed = true;
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.FindAccountByID(accountID)).Returns(account);
            IAccountService service = new BankAccountService(mock.Object);
            service.CloseAccount(accountID);

            Assert.AreEqual(true, account.IsClosed);
        }

        [TestCase("Ivanov", "Ivan", "5523664212", 500, 0, 100)]
        public void BLL_CloseNotExistedAccount_Test(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, decimal withdrawAmount)
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.CloseAccount(accountID)).Throws(new Exception());
            IAccountService service = new BankAccountService(mock.Object);
            

            Assert.Throws<Exception>(() => service.CloseAccount(accountID));
        }
    }
}
