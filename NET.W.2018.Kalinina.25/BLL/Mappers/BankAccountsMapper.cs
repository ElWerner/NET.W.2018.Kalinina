using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BLL.Interface.Entities;
using BLL.Mappers;

namespace BLL.Mappers
{
    public static class BankAccountsMapper
    {
        public static DalBankAccount ToDalBankAccount(BankAccount bankAccount, AccountType accountType)
        {
            DalBankAccount dalBankAccount = new DalBankAccount();
            dalBankAccount.AccountOwner = AccountOwnersMapper.ToDalAccountOwner(bankAccount.Owner);
            dalBankAccount.AccountType = accountType;
            dalBankAccount.BankAccountNumber = bankAccount.AccountID;
            dalBankAccount.BonusScores = bankAccount.BonuseScores;
            dalBankAccount.InvoiceAmount = bankAccount.InvoiceAmount;
            dalBankAccount.IsClosed = bankAccount.IsClosed;

            return dalBankAccount;
        }

        public static BankAccount ToBankAccount(DalBankAccount dalBankAccount)
        {
            BankAccount bankAccount;
            switch (dalBankAccount.AccountType)
            {
                case AccountType.Base:
                    {
                        bankAccount = new BaseAccount(AccountOwnersMapper.ToAccountOwner(dalBankAccount.AccountOwner), dalBankAccount.BankAccountNumber, dalBankAccount.InvoiceAmount, dalBankAccount.BonusScores, dalBankAccount.IsClosed);
                    }
                    break;
                case AccountType.Platinum:
                    {
                        bankAccount = new PlatinumAccount(AccountOwnersMapper.ToAccountOwner(dalBankAccount.AccountOwner), dalBankAccount.BankAccountNumber, dalBankAccount.InvoiceAmount, dalBankAccount.BonusScores, dalBankAccount.IsClosed);
                    }
                    break;
                case AccountType.Gold:
                    {
                        bankAccount = new GoldAccount(AccountOwnersMapper.ToAccountOwner(dalBankAccount.AccountOwner), dalBankAccount.BankAccountNumber, dalBankAccount.InvoiceAmount, dalBankAccount.BonusScores, dalBankAccount.IsClosed);
                    }
                    break;
                default:
                    {
                        bankAccount = new BaseAccount(AccountOwnersMapper.ToAccountOwner(dalBankAccount.AccountOwner), dalBankAccount.BankAccountNumber, dalBankAccount.InvoiceAmount, dalBankAccount.BonusScores, dalBankAccount.IsClosed);
                    }
                    break;
            }
            bankAccount.BankAccountId = dalBankAccount.BankAccountID;
            return bankAccount;
        }

        public static IEnumerable<BankAccount> ToBankAccounts(IEnumerable<DalBankAccount> dalBankAccounts)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            foreach(var dalAccount in dalBankAccounts)
            {
                bankAccounts.Add(ToBankAccount(dalAccount));
            }

            return bankAccounts;
        }
    }
}
