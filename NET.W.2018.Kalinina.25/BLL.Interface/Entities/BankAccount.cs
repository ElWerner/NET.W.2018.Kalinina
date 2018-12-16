using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// A class that represents bank account entity
    /// </summary>
    public abstract class BankAccount
    {
        public int BankAccountId { get; set; }
        /// <summary>
        /// A filed to hold account number
        /// </summary>
        private string accountID;

        /// <summary>
        /// A field to hold first name of the account owner
        /// </summary>
        private AccountOwner accountOwner;

        /// <summary>
        /// A field to hold balance amount
        /// </summary>
        private decimal invoiceAmount;

        /// <summary>
        /// A filed to hold account bonus scores
        /// </summary>
        private double bonusScores;

        /// <summary>
        /// A filed to hold account status
        /// </summary>
        private bool isClosed;

        /// <summary>
        /// Bonus scores increase/decrease percents
        /// </summary>
        protected const double PERCENTS = 0.001;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with specified params
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="owner">Account owner</param>
        /// <param name="invoiceAmount">Account balance</param>
        /// <param name="bonusScores">Bonus scores</param>
        /// <param name="accountType">Account type</param>
        /// <param name="isClosed">Account status</param>
        public BankAccount(AccountOwner owner, string accountNumber, decimal invoiceAmount, double bonusScores,
               bool isClosed = false)
        {
            Owner = owner;
            AccountID = accountNumber;
            InvoiceAmount = invoiceAmount;
            BonuseScores = bonusScores;
            IsClosed = isClosed;
        }

        /// <summary>
        /// Gets or sets account number
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when Account number is 
        /// null or empty</exception>
        public string AccountID
        {
            get
            {
                return accountID;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Account number is not initialized.");
                }

                accountID = value;
            }
        }

        /// <summary>
        /// Gets or sets account owner
        /// </summary>
        ///<exception cref="ArgumentNullException">Thrown when owner entity is null</exception>
        public AccountOwner Owner
        {
            get
            {
                return accountOwner;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Account owner is not initialized.");
                }

                accountOwner = value;
            }
        }


        /// <summary>
        /// Gets or sets account balance
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when invoice amount is 
        /// less than 0</exception>
        public decimal InvoiceAmount
        {
            get
            {
                return invoiceAmount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Invoice amount cannot be less than 0.");
                }

                invoiceAmount = value;
            }
        }

        /// <summary>
        /// Gets or sets bonus scores
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when bonus scores is 
        /// less than 0</exception>
        public double BonuseScores
        {
            get
            {
                return bonusScores;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Bonus scores cannot be less than 0.");
                }

                bonusScores = value;
            }
        }

        /// <summary>
        /// Gets or sets account status
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return isClosed;
            }

            set
            {
                isClosed = value;
            }
        }

        /// <summary>
        /// Increases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <param name="account">Bank account</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when deposit amount is less
        /// than 0</exception>
        public abstract void DepositMoney(decimal amount);


        /// <summary>
        /// Decreases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when withdraw amount is less
        /// than 0</exception>
        public abstract void WithdrawMoney(decimal amount);

        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public override string ToString()
        {
            return $"Account Number: {accountID}, First Name: {accountOwner.FirstName}, LastName: {accountOwner.LastName}, " +
                $"Invoice Amount: {invoiceAmount:C}, Bonus Scores: {bonusScores}, " +
                $"Is Closed?: {isClosed}";
        }
    }
}
