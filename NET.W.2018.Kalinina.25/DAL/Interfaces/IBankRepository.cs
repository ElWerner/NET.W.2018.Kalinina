using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IBankRepository
    {
        /// <summary>
        /// Adds bank account to the container
        /// </summary>
        /// <param name="account">Bank account</param>
        void AddAccount(DalBankAccount account);

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
        DalBankAccount FindAccountByID(string accountID);

        /// <summary>
        /// Gets all bank accounts
        /// </summary>
        ///<returns>Collection of accounts</returns>
        IEnumerable<DalBankAccount> GetAccounts();
    }
}
