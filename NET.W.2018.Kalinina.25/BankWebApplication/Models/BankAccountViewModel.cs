using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;

namespace BankWebApplication.Models
{
    public class BankAccountViewModel
    {
        public IEnumerable<BankAccount> AccountsList { get; set; }
    }
}