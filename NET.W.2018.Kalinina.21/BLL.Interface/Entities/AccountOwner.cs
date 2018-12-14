using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// A class that represents account owner entity
    /// </summary>
    public class AccountOwner
    {
        /// <summary>
        /// A field to hold owner's first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// A field to hold owner's last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountOwner"/> class
        /// </summary>
        /// <param name="firstName">Owner's first name</param>
        /// <param name="lastName">Owner's last name</param>
        public AccountOwner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Gets or sets owner's first name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when first name is empty or null</exception>
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name is not initialized.");
                }

                firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets owner's last name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when last name is empty or null</exception>
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
    }
}
