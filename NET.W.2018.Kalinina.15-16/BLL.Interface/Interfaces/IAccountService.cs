using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides basic methods to manipulate bank account
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Opens new account with specified type
        /// </summary>
        /// <param name="accountOwner">Account owner</param>
        /// <param name="accountID">Account ID</param>
        /// <param name="invoiceAmount">Invoice amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        /// <param name="accountType">Account type</param>
        void OpenAccount(AccountOwner accountOwner, string accountID, decimal invoiceAmount, double bonusScores, AccountType accountType);

        /// <summary>
        /// Opens new account with specified type
        /// </summary>
        /// <param name="lastName">Account owner's last name</param>
        /// <param name="firstName">Account owner's fist name</param>
        /// <param name="accountID">Account ID</param>
        /// <param name="invoiceAmount">Invoice amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        /// <param name="accountType">Account type</param>
        void OpenAccount(string lastName, string firstName, string accountID, decimal invoiceAmount, double bonusScores, AccountType accountType);

        /// <summary>
        /// Deposits money to the account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="accountID">Account ID</param>
        void DepositMoney(string accountID, decimal amount);

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="accountID">Account ID</param>
        void WithdrawMoney(string accountID, decimal amount);

        /// <summary>
        /// Closes account
        /// </summary>
        /// <param name="accountID">Account ID</param>
        void CloseAccount(string accountID);

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        IEnumerable<BankAccount> GetAccounts();
    }
}
