using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.Repositories;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Represents a class providing basic operations with bank account
    /// </summary>
    public class BankAccountService : IAccountService
    {
        /// <summary>
        /// Holds reference to the bank accounts container
        /// </summary>
        private IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class
        /// </summary>
        /// <param name="repository">Reference to the bank accounts container</param>
        /// <exception cref="ArgumentNullException">Thrown when repository is null</exception>
        public BankAccountService(IRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("Repository is not initialized.");
            }

            this.repository = repository;
        }

        /// <summary>
        /// Closes account
        /// </summary>
        /// <param name="accountID">Account ID</param>
        public void CloseAccount(string accountID) => repository.CloseAccount(accountID);

        /// <summary>
        /// Opens new account with specified type
        /// </summary>
        /// <param name="accountOwner">Account owner</param>
        /// <param name="accountID">Account ID</param>
        /// <param name="invoiceAmount">Invoice amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        /// <param name="accountType">Account type</param>
        public void OpenAccount(AccountOwner accountOwner, string accountID, decimal invoiceAmount, double bonusScores, AccountType accountType)
        {
            if(accountOwner == null)
            {
                throw new ArgumentNullException("Account owner is not initialized.");
            }

            Create(accountOwner, accountID, invoiceAmount, bonusScores, accountType);
        }

        /// <summary>
        /// Opens new account with specified type
        /// </summary>
        /// <param name="lastName">Account owner's last name</param>
        /// <param name="firstName">Account owner's fist name</param>
        /// <param name="accountID">Account ID</param>
        /// <param name="invoiceAmount">Invoice amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        /// <param name="accountType">Account type</param>
        public void OpenAccount(string lastName, string firstName, string accountID,
            decimal invoiceAmount, double bonusScores, AccountType accountType) => OpenAccount(new AccountOwner(firstName, lastName), accountID, invoiceAmount, bonusScores, accountType);

        /// <summary>
        /// Deposits money to the account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="accountID">Account ID</param>
        public void DepositMoney(string accountID, decimal amount) => repository.FindAccountByID(accountID).DepositMoney(amount);

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="accountID">Account ID</param>
        public void WithdrawMoney(string accountID, decimal amount) => repository.FindAccountByID(accountID).WithdrawMoney(amount);

        /// <summary>
        /// Creates new bank account with specified type and adds it to the repository
        /// </summary>
        /// <param name="accountOwner">Account owner</param>
        /// <param name="accountID">Account ID</param>
        /// <param name="invoiceAmount">Invoice amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        /// <param name="accountType">Account type</param>
        private void Create(AccountOwner accountOwner, string accountID, decimal invoiceAmount, double bonusScores, AccountType accountType)
        {
            BankAccount newAccount;
            switch(accountType)
            {
                case AccountType.Base:
                    {
                        newAccount = new BaseAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(newAccount);
                    }
                    break;
                case AccountType.Silver:
                    {
                        newAccount = new SilverAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(newAccount);
                    }
                    break;
                case AccountType.Gold:
                    {
                        newAccount = new GoldAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(newAccount);
                    }
                    break;
                default:
                    {
                        newAccount = new BaseAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(newAccount);
                    }
                    break;
            }
        }
    }
}
