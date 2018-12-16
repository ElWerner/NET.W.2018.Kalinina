using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class BankRepository : IRepository<DalBankAccount>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class with specified 
        /// path to the file
        /// </summary>
        public BankRepository()
        {

        }

        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentNullException">Thrown when bank account is null</exception>
        /// <exception cref="Exception">Thrown when bank account with the same account ID is already
        /// presents in the container</exception>
        public void AddAccount(DalBankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account is not initialized.");
            }

            if (FindAccountByID(account.BankAccountNumber) != null)
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
            if (string.IsNullOrEmpty(accountID))
            {
                throw new ArgumentNullException("Account ID is not initialized.");
            }

            if (FindAccountByID(accountID) == null)
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
        public DalBankAccount FindAccountByID(string accountID)
        {
            using (var db = new AccountsContext())
            {
                var query = db.Accounts.Where(p => p.BankAccountNumber == accountID).Include(p => p.AccountOwner).ToList();

                if (query.Any() == true)
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        public IEnumerable<DalBankAccount> GetAccounts()
        {
            List<DalBankAccount> dalBankAccounts = new List<DalBankAccount>();
            using (var db = new AccountsContext())
            {
                var query = db.Accounts.Include(p => p.AccountOwner).ToList();

                foreach(var account in query)
                {
                    dalBankAccounts.Add(account);
                }
            }

            return dalBankAccounts;
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="accountID">Bank account ID</param>
        private void Close(string accountID)
        {
            using (var db = new AccountsContext())
            {
                var closedAccount = db.Accounts.Where(p => p.BankAccountNumber == accountID).FirstOrDefault();

                if (closedAccount != null)
                {
                    closedAccount.IsClosed = true;

                    db.Entry(closedAccount).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

        }

        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        private void Add(DalBankAccount account)
        {
            using (var db = new AccountsContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public void SaveAccount(DalBankAccount account)
        {
            using (var db = new AccountsContext())
            {
                var savedAccount = db.Accounts.Where(p => p.BankAccountNumber == account.BankAccountNumber).FirstOrDefault();

                if(savedAccount != null)
                {
                    savedAccount.BonusScores = account.BonusScores;
                    savedAccount.InvoiceAmount = account.InvoiceAmount;
                    savedAccount.IsClosed = account.IsClosed;

                    db.Entry(savedAccount).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
        }
    }
}
