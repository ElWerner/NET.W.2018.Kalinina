﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.Interfaces;
using DAL.Entities;

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
        private IRepository<DalBankAccount> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountService"/> class
        /// </summary>
        /// <param name="repository">Reference to the bank accounts container</param>
        /// <exception cref="ArgumentNullException">Thrown when repository is null</exception>
        public BankAccountService(IRepository<DalBankAccount> repository)
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
        public void DepositMoney(string accountID, decimal amount)
        {
            var manager = new MailManager();
            double oldBonusScores;

            var dalAccount = repository.FindAccountByID(accountID);
            if (dalAccount.IsClosed == true)
            {
                throw new Exception("Account is closed.");
            }
            var account = Mappers.BankAccountsMapper.ToBankAccount(dalAccount);

            account.Register(manager);
            oldBonusScores = account.BonuseScores;

            account.DepositMoney(amount);
            manager.SimulateNewMail(amount, 0, account.BonuseScores - oldBonusScores);

            repository.SaveAccount(Mappers.BankAccountsMapper.ToDalBankAccount(account, dalAccount.AccountType));
        }

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="accountID">Account ID</param>
        public void WithdrawMoney(string accountID, decimal amount)
        {
            var manager = new MailManager();
            double oldBonusScores;

            var dalAccount = repository.FindAccountByID(accountID);
            if(dalAccount.IsClosed == true)
            {
                throw new Exception("Account is closed.");
            }
            var account = Mappers.BankAccountsMapper.ToBankAccount(dalAccount);

            account.Register(manager);
            oldBonusScores = account.BonuseScores;

            account.WithdrawMoney(amount);
            manager.SimulateNewMail(0, amount,  oldBonusScores - account.BonuseScores);

            repository.SaveAccount(Mappers.BankAccountsMapper.ToDalBankAccount(account, dalAccount.AccountType));
        }

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="accountID">Account ID</param>
        public void TransferMoney(string fromAccountID, string toAccountID, decimal amount)
        {
            var manager = new MailManager();
            double oldBonusScoresFirst;
            double oldBonusScoresSecond;

            var dalFromAccount = repository.FindAccountByID(fromAccountID);
            if (dalFromAccount.IsClosed == true)
            {
                throw new Exception("Account is closed.");
            }


            var dalToAccount = repository.FindAccountByID(toAccountID);
            if (dalToAccount.IsClosed == true)
            {
                throw new Exception("Account is closed.");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var fromAccount = Mappers.BankAccountsMapper.ToBankAccount(dalFromAccount);

            fromAccount.Register(manager);
            oldBonusScoresFirst = fromAccount.BonuseScores;

            fromAccount.WithdrawMoney(amount);
            manager.SimulateNewMail(0, amount, oldBonusScoresFirst - fromAccount.BonuseScores);
            fromAccount.Unregister(manager);

            repository.SaveAccount(Mappers.BankAccountsMapper.ToDalBankAccount(fromAccount, dalFromAccount.AccountType));

            var toAccount = Mappers.BankAccountsMapper.ToBankAccount(dalToAccount);

            toAccount.Register(manager);
            oldBonusScoresSecond = toAccount.BonuseScores;

            toAccount.DepositMoney(amount);
            manager.SimulateNewMail(amount, 0, - oldBonusScoresSecond + toAccount.BonuseScores);

            repository.SaveAccount(Mappers.BankAccountsMapper.ToDalBankAccount(toAccount, dalToAccount.AccountType));
        }

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        public IEnumerable<BankAccount> GetAccounts()
        {
            return Mappers.BankAccountsMapper.ToBankAccounts(repository.GetAccounts());
        }

        /// <summary>
        /// Gets account wiht specified ID
        /// </summary>
        /// <param name="accountID">Account ID</param>
        public BankAccount GetAccountByID(string accountID)
        {
            return Mappers.BankAccountsMapper.ToBankAccount(repository.FindAccountByID(accountID));
        }


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
                        repository.AddAccount(Mappers.BankAccountsMapper.ToDalBankAccount(newAccount, AccountType.Base));
                    }
                    break;
                case AccountType.Platinum:
                    {
                        newAccount = new PlatinumAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(Mappers.BankAccountsMapper.ToDalBankAccount(newAccount, AccountType.Platinum));
                    }
                    break;
                case AccountType.Gold:
                    {
                        newAccount = new GoldAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(Mappers.BankAccountsMapper.ToDalBankAccount(newAccount, AccountType.Gold));
                    }
                    break;
                default:
                    {
                        newAccount = new BaseAccount(accountOwner, accountID, invoiceAmount, bonusScores);
                        repository.AddAccount(Mappers.BankAccountsMapper.ToDalBankAccount(newAccount, AccountType.Base));
                    }
                    break;
            }
        }
    }
}
