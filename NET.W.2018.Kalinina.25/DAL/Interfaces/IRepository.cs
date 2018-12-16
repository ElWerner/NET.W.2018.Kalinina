using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Interfaces
{
    /// <summary>
    /// Provides methods to read and write elements to file
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        void AddAccount(T account);

        void SaveAccount(T account);

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
        T FindAccountByID(string accountID);

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        IEnumerable<T> GetAccounts();
    }
}
