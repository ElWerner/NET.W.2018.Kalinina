using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Repositories
{
    /// <summary>
    /// Provides methods to read and write elements to file
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        void AddAccount(BankAccount account);

        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="accountID">Bank account ID</param>
        void CloseAccount(string accountID);

        /// <summary>
        /// Finds bank account with specified ID
        /// </summary>
        /// <param name="accountID">Account ID</param>
        /// <returns>Reference to the bank account instance if bank account with specified account ID is presents
        /// in the container. Null otherwise</returns>
        BankAccount FindAccountByID(string accountID);
    }
}
