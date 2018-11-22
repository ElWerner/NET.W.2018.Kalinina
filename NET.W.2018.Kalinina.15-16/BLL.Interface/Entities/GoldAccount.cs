using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// A class that represents platinum bank account entity
    /// </summary>
    public class GoldAccount : BankAccount
    {
        /// <summary>
        /// A field to hold withdraw coefficient to calculate bonus scores
        /// </summary>
        private const int WITHDRAWCOEFFICIENT = 4;

        /// <summary>
        /// A filed to hold deposit coefficient to calculate bonus scores
        /// </summary>
        private const int DEPOSITCOEFFICIENT = 9;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class with specified params
        /// </summary>
        /// <param name="accountNumber">Account number</param>
        /// <param name="firstName">First name of the owner</param>
        /// <param name="lastName">Last name of the owner</param>
        /// <param name="invoiceAmount">Account balance</param>
        /// <param name="bonusScores">Bonus scores</param>
        /// <param name="accountType">Account type</param>
        /// <param name="isClosed">Account status</param>
        public GoldAccount(AccountOwner owner, string accountNumber, decimal invoiceAmount, double bonusScores,
               bool isClosed = false) : base(owner, accountNumber, invoiceAmount, bonusScores, isClosed)
        {
        }

        /// <summary>
        /// Increases balance of the bank account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when deposit amount is less
        /// than 0</exception>
        public override void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Deposit amount cannot be less than 0.");
            }

            Deposit(amount);
        }

        /// <summary>
        /// Increases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        private void Deposit(decimal amount)
        {
            InvoiceAmount += amount;
            BonuseScores = IncreaseBonusScores(amount);
        }

        /// <summary>
        /// Decreases balance of the bank account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when withdraw amount is less
        /// than 0</exception>
        public override void WithdrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Withdraw amount cannot be less than 0.");
            }

            if (amount > InvoiceAmount)
            {
                throw new Exception("Insufficient funds for withdrawing");
            }

            Withdraw(amount);
        }

        /// <summary>
        /// Decreases balance and bonus scores of the bank account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        private void Withdraw(decimal amount)
        {
            InvoiceAmount -= amount;
            BonuseScores = DecreaseBonusScores(amount);
        }

        /// <summary>
        /// Increase bonus scores of the account
        /// </summary>
        /// <param name="amount">Deposit amount</param>
        /// <returns>Increased bonus scores</returns>
        private double IncreaseBonusScores(decimal amount)
        {
            return BonuseScores + ((double)amount * DEPOSITCOEFFICIENT * PERCENTS);
        }

        /// <summary>
        /// Decrease bonus scores of the account
        /// </summary>
        /// <param name="amount">Withdraw amount</param>
        /// <returns>Decreased bonus scores</returns>
        private double DecreaseBonusScores(decimal amount)
        {
            double decreaseScores = Math.Abs(BonuseScores - ((double)amount * WITHDRAWCOEFFICIENT * PERCENTS));

            if (decreaseScores > BonuseScores)
            {
                return 0;
            }
            else
            {
                return BonuseScores - decreaseScores;
            }
        }


        /// <summary>
        /// Returns a string representation of instance
        /// </summary>
        /// <returns>A string that represents instance</returns>
        public override string ToString()
        {
            return base.ToString() + " Account type: Gold.";
        }
    }
}
