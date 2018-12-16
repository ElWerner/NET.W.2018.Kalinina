using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;
using BLL.Interface.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Entities;

namespace DependencyResolver
{
    /// <summary>
    /// Represents a class providing binding interfaces to service and DAL
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Binds interfaces to implementaton
        /// </summary>
        /// <param name="kernel"></param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<BankAccountService>();
            kernel.Bind<IRepository<BankAccount>>().To<Repository>();
            kernel.Bind<IRepository<DalBankAccount>>().To<BankRepository>();
        }
    }
}
