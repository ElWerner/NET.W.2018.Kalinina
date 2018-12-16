using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Represents a class providing bank accounts container
    /// </summary>
    public class Repository : IRepository<BankAccount>
    {
        /// <summary>
        /// 
        /// </summary>
        private List<BankAccount> accounts = new List<BankAccount>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class with specified 
        /// path to the file
        /// </summary>
        public Repository()
        {

        }

        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentNullException">Thrown when bank account is null</exception>
        /// <exception cref="Exception">Thrown when bank account with the same account ID is already
        /// presents in the container</exception>
        public void AddAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account is not initialized.");
            }

            if (FindAccountByID(account.AccountID) != null)
            {
                throw new Exception("Account has already been added.");
            }

            Add(account);
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when bank account is null</exception>
        /// <exception cref="Exception">Thrown when bank account with specified account 
        /// ID wasn't found in the container or if the bank account has already been closed</exception>
        public void CloseAccount(string accountID)
        {
            if(string.IsNullOrEmpty(accountID))
            {
                throw new ArgumentNullException("Account ID is not initialized.");
            }

            if(FindAccountByID(accountID) == null)
            {
                throw new Exception("Account was not found.");
            }

            if (FindAccountByID(accountID).IsClosed == true)
            {
                throw new Exception("Account has already been closed.");
            }

            Close(accountID);
        }

        /// <summary>
        /// Finds bank account with specified ID
        /// </summary>
        /// <param name="accountID">Account ID</param>
        /// <returns>Reference to the bank account instance if bank account with specified account ID is presents
        /// in the container. Null otherwise</returns>
        public BankAccount FindAccountByID(string accountID)
        {
            foreach (var account in accounts)
            {
                if (account.AccountID == accountID)
                {
                    return account;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        public IEnumerable<BankAccount> GetAccounts()
        {
            return accounts;
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="accountID">Bank account ID</param>
        private void Close(string accountID)
        {
            foreach(var account in accounts)
            {
                if(account.AccountID == accountID)
                {
                    account.IsClosed = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        private void Add(BankAccount account)
        {
            accounts.Add(account);
        }

        public void SaveAccount(BankAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
