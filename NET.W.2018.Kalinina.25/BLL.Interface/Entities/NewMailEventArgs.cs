using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Represents a class containing account events arguments
    /// </summary>
    public class NewMailEventArgs : EventArgs
    {
        /// <summary>
        /// A field to hold deposit amount
        /// </summary>
        private readonly decimal depositAmount;

        /// <summary>
        /// A field to hold withdraw amount
        /// </summary>
        private readonly decimal withdrawAmount;

        /// <summary>
        /// A filed to hold bonus scores
        /// </summary>
        private readonly double bonusScores;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewMailEventArgs"/> with specified parametres
        /// </summary>
        /// <param name="depositAmount">Deposit amount</param>
        /// <param name="withdrawAmount">Withdraw amount</param>
        /// <param name="bonusScores">Bonus Scores</param>
        public NewMailEventArgs(decimal depositAmount, decimal withdrawAmount, double bonusScores)
        {
            this.depositAmount = depositAmount;
            this.withdrawAmount = withdrawAmount;
            this.bonusScores = bonusScores;
        }

        /// <summary>
        /// Gets deposit amount
        /// </summary>
        public decimal DepositAmount { get { return depositAmount; } }

        /// <summary>
        /// Gets withdraw amount
        /// </summary>
        public decimal WithdrawAmount { get { return withdrawAmount; } }

        /// <summary>
        /// Gets bonus scores
        /// </summary>
        public double BonusScores { get { return bonusScores; } }
    }
}
