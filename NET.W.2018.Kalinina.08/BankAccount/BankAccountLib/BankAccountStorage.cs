using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Represents a class providing basic input and output files operations with bank accounts list
    /// </summary>
    public class BankAccountStorage : IStorage<BankAccount>
    {
        #region Fields
        /// <summary>
        /// Field to hold path to the file
        /// </summary>
        private string filePath;

        #endregion

        #region Public API

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountStorage"/> class with specified 
        /// path to the file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <exception cref="ArgumentNullException">Thrown when file path 
        /// string is null or empty</exception>
        public BankAccountStorage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not initializes.");
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// Reads accounts from file into list of accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        /// <exception cref="ArgumentNullException">Thrown when file path is not initialized
        /// or this file is not exists</exception>
        public List<BankAccount> ReadFromFile()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not initialized.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentNullException("File is not exists.");
            }

            return ReadAccounts();
        }

        /// <summary>
        /// Writes accounts from list into the file
        /// </summary>
        /// <param name="accounts">List of accounts</param>
        /// <exception cref="ArgumentNullException">Thrown when file path or list of accounts
        /// is not initialized</exception>
        public void WriteToFile(List<BankAccount> accounts)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not initialized.");
            }

            if (accounts == null || accounts.Count == 0)
            {
                throw new ArgumentNullException("List of books is not initialized");
            }

            WriteAccounts(accounts);
        }

        #endregion

        #region Private API

        /// <summary>
        /// Reads accounts from file into list of accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        /// <exception cref="IOException">Thrown when files reading error occurred</exception>
        private List<BankAccount> ReadAccounts()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string number = reader.ReadString();
                        string firstName = reader.ReadString();
                        string lastName = reader.ReadString();
                        decimal invoiceAmount = reader.ReadDecimal();
                        double bonusScores = reader.ReadDouble();
                        BancAccountType type = (BancAccountType)reader.ReadInt32();
                        bool isClosed = reader.ReadBoolean();

                        BankAccount book = new BankAccount(
                            number, 
                            firstName, 
                            lastName, 
                            invoiceAmount, 
                            bonusScores,
                            type, 
                            isClosed);
                        accounts.Add(book);
                    }

                    return accounts;
                }
            }
            catch
            {
                throw new IOException("Unable to read from the file");
            }
        }

        /// <summary>
        /// Writes accounts from list into the file
        /// </summary>
        /// <param name="accounts">List of accounts</param>
        /// <exception cref="IOException">Thrown when files writing error occurred</exception>
        private void WriteAccounts(List<BankAccount> accounts)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
                {
                    foreach (BankAccount account in accounts)
                    {
                        writer.Write(account.AccountNumber);
                        writer.Write(account.FirstName);
                        writer.Write(account.LastName);
                        writer.Write(account.InvoiceAmount);
                        writer.Write(account.BonuseScores);
                        writer.Write((int)account.AccountType);
                        writer.Write(account.IsClosed);
                    }
                }
            }
            catch
            {
                throw new IOException("Unable to write into the file");
            }
        }

        #endregion
    }
}
