using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Represents a class providing basic operations with bank account
    /// </summary>
    public class BankAccountService : IAccountService<BankAccount>
    {
        /// <summary>
        /// A constant that holds number for evaluating bonus scores 
        /// </summary>
        private const double PERCENTS = 0.1;

        /// <summary>
        /// A constant that holds number for evaluating bonus scores during depositing
        /// </summary>
        private const double DEPOSIT = 0.5;

        /// <summary>
        /// A constant that holds number for evaluating bonus scores during withdrawing
        /// </summary>
        private const double WITHDRAW = 0.3;

        /// <summary>
        /// Increases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when deposit amount is less
        /// than 0</exception>
        /// <exception cref="ArgumentNullException">Thrown when bank account is not initialized</exception>
        /// <exception cref="Exception">Thrown when bank account is closed</exception>
        public void DepositMoney(decimal amount, BankAccount account)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount cannot be less than 0.");
            }

            if (account == null)
            {
                throw new ArgumentNullException("Bank account is not initialized");
            }

            if (account.IsClosed == true)
            {
                throw new Exception("Current account is closed.");
            }

            account.InvoiceAmount += amount;
            account.BonuseScores = IncreaseBonusScores(amount, account);
        }

        /// <summary>
        /// Decreases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when withdraw amount is less
        /// than 0</exception>
        /// <exception cref="ArgumentNullException">Thrown when bank account is not initialized</exception>
        /// <exception cref="Exception">Thrown when bank account is closed or 
        /// there is insufficient funds for withdrawing</exception>
        public void WithdrawMoney(decimal amount, BankAccount account)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Withdraw amount cannot be less than 0.");
            }

            if (account == null)
            {
                throw new ArgumentNullException("Bank account is not initialized");
            }

            if (account.IsClosed == true)
            {
                throw new Exception("Current account is closed.");
            }

            if (amount > account.InvoiceAmount)
            {
                throw new Exception("Insufficient funds for withdrawing");
            }

            account.InvoiceAmount -= amount;
            account.BonuseScores = DecreaseBonusScores(amount, account);
        }

        /// <summary>
        /// Writes accounts to the storage
        /// </summary>
        /// <param name="storage">Storage to hold list of accounts</param>
        /// <param name="accountsList">List of accounts</param>
        /// <exception cref="ArgumentNullException">Thrown when storage or
        /// list of accounts is not initialized</exception>
        public void WriteAccounts(IStorage<BankAccount> storage, List<BankAccount> accountsList)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("Storage is not initialized");
            }

            if (accountsList == null || accountsList.Count == 0)
            {
                throw new ArgumentNullException("Account list is not initialized");
            }

            storage.WriteToFile(accountsList);
        }

        /// <summary>
        /// Reads accounts from the storage
        /// </summary>
        /// <param name="storage">Storage that holds list of accounts</param>
        /// <returns>List of bank accounts</returns>
        /// <exception cref="ArgumentNullException">Thrown when storage is not initialized</exception>
        public List<BankAccount> ReadAccounts(IStorage<BankAccount> storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }

            return storage.ReadFromFile();
        }

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentNullException">Thrown when account is not initialized</exception>
        /// <exception cref="Exception">Thrown when account is already closed</exception>
        public void CloseAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account list is not initialized");
            }

            if (account.IsClosed == true)
            {
                throw new Exception("Current account is closed.");
            }

            account.IsClosed = true;
        }

        /// <summary>
        /// Increase bonus scores of the account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="account">Bank account</param>
        /// <returns>Increased bonus scores</returns>
        private double IncreaseBonusScores(decimal amount, BankAccount account)
        {
            return account.BonuseScores + ((double)amount * (int)account.AccountType * PERCENTS * DEPOSIT);
        }

        /// <summary>
        /// Decrease bonus scores of the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="account">Bank account</param>
        /// <returns>Decreased bonus scores</returns>
        private double DecreaseBonusScores(decimal amount, BankAccount account)
        {
            double decreaseScores = account.BonuseScores - ((double)amount * (int)account.AccountType * PERCENTS * WITHDRAW);

            if (decreaseScores > account.BonuseScores)
            {
                return 0;
            }
            else
            {
                return account.BonuseScores - decreaseScores;
            }
        }
    }
}
