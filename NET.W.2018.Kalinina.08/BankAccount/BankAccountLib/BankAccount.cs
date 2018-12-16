using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLib
{
    /// <summary>
    /// Enum to hold account types
    /// </summary>
    public enum BancAccountType
    {
        Base = 1,
        Gold,
        Platinum
    }

    /// <summary>
    /// Class that represents bank account entity
    /// </summary>
    public class BankAccount
    {
        #region Fields
        /// <summary>
        /// A filed to hold account number
        /// </summary>
        private string accountNumber;

        /// <summary>
        /// A field to hold first name of the account owner
        /// </summary>
        private string firstName;

        /// <summary>
        /// A field to hold last name of the account owner
        /// </summary>
        private string lastName;

        /// <summary>
        /// A field to hold balance amount
        /// </summary>
        private decimal invoiceAmount;

        /// <summary>
        /// A filed to hold account bonus scores
        /// </summary>
        private double bonusScores;

        /// <summary>
        /// A field to hold account type
        /// </summary>
        private BancAccountType accountType;

        /// <summary>
        /// A filed to hold account status
        /// </summary>
        private bool isClosed;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class with specified parameters
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="firstName">First name of the owner</param>
        /// <param name="lastName">Last name of the owner</param>
        /// <param name="invoiceAmount">Account balance</param>
        /// <param name="bonusScores">Bonus scores</param>
        /// <param name="accountType">Account type</param>
        /// <param name="isClosed">Account status</param>
        public BankAccount(
            string accountNumber,
            string firstName,
            string lastName,
            decimal invoiceAmount,
            double bonusScores, 
            BancAccountType accountType,
            bool isClosed = false)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            InvoiceAmount = invoiceAmount;
            BonuseScores = bonusScores;
            AccountType = accountType;
            IsClosed = isClosed;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets account number
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when Account number is 
        /// null or empty</exception>
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Account number is not initialized.");
                }

                accountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets first name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when first name is 
        /// null or empty</exception>
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name is not initialized.");
                }

                firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when last name is 
        /// null or empty</exception>
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name is not initialized.");
                }

                lastName = value;
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
        /// Gets or sets account type
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when type is out of range</exception>
        public BancAccountType AccountType
        {
            get
            {
                return accountType;
            }

            set
            {
                if (value < BancAccountType.Base || value > BancAccountType.Platinum)
                {
                    throw new ArgumentNullException("Account type is out of range.");
                }

                accountType = value;
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

        #endregion

        #region Public API
        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public override string ToString()
        {
            return $"Account Number: {accountNumber}, First Name: {firstName}, LastName: {lastName}, " +
                $"Invoice Amount: {invoiceAmount:C}, Bonus Scores: {bonusScores}, " +
                $"Account Type: {accountType.ToString()}, Is Closed?: {isClosed}";
        }

        #endregion
    }
}
