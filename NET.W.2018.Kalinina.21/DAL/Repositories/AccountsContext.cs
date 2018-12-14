using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.Repositories
{
    public class AccountsContext : DbContext
    {
        public DbSet<DalAccountOwner> Owners { get; set; }
        public DbSet<DalBankAccount> Accounts { get; set; }
    }
}
