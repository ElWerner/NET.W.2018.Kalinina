using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class AccountOwnersMapper
    {
        public static DalAccountOwner ToDalAccountOwner(AccountOwner owner)
        {
            DalAccountOwner dalAccountOwner = new DalAccountOwner();

            dalAccountOwner.FirstName = owner.FirstName;
            dalAccountOwner.LastName = owner.LastName;

            return dalAccountOwner;
        }

        public static AccountOwner ToAccountOwner(DalAccountOwner dalAccountOwner)
        {
            AccountOwner accountOwner = new AccountOwner(dalAccountOwner.FirstName, dalAccountOwner.LastName);
            accountOwner.AccountOwnerId = dalAccountOwner.AccountOwnerID;

            return accountOwner;
        }
    }
}
