using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using BLL.Interface.Entities;

namespace DAL.Entities
{
    /// <summary>
    /// A class that represents bank account entity
    /// </summary>
    public class DalBankAccount
    {
        /// <summary>
        /// A filed to hold account number
        /// </summary>
        [Key]
        public int BankAccountID { get; set; }

        public string BankAccountNumber { get; set; }

        /// <summary>
        /// A field to hold first name of the account owner
        /// </summary>
        public DalAccountOwner AccountOwner { get; set; }

        /// <summary>
        /// A field to hold balance amount
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        /// A filed to hold account bonus scores
        /// </summary>
        public double BonusScores { get; set; }

        /// <summary>
        /// A filed to hold account status
        /// </summary>
        public bool IsClosed { get; set; }

        public AccountType AccountType { get; set; }

        public DalBankAccount() { }

        public DalBankAccount(DalAccountOwner accountOwner, decimal invoiceAmount, double bonusScores, bool isClosed, AccountType type)
        {
            AccountOwner = accountOwner;
            InvoiceAmount = invoiceAmount;
            BonusScores = bonusScores;
            IsClosed = isClosed;
            AccountType = type;
        }
    }
}
