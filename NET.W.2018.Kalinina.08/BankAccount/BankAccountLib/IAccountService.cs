using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Provides basic methods to manipulate bank account
    /// </summary>
    /// <typeparam name="T">Type of account</typeparam>
    public interface IAccountService<T>
    {
        /// <summary>
        /// Deposits money to the account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="account">Bank account</param>
        void DepositMoney(decimal amount, T account);

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <param name="account">Bank account</param>
        void WithdrawMoney(decimal amount, T account);

        /// <summary>
        /// Closes account
        /// </summary>
        /// <param name="account">Closed account</param>
        void CloseAccount(T account);
    }
}
