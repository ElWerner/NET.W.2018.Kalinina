using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// A class that represents account owner entity
    /// </summary>
    public class DalAccountOwner
    {
        [Key]
        public int AccountOwnerID { get; set; }
        /// <summary>
        /// A field to hold owner's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// A field to hold owner's last name
        /// </summary>
        public string LastName { get; set; }

        public DalAccountOwner() { }

        public DalAccountOwner (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
