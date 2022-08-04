using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner and a balance of $0.
        /// </summary>
        /// <param name="accOwner">The customer full name that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }
        
        /// <summary>
        /// The account holders full name(first and last)
        /// </summary>
        public string Owner { get; set; }

        
        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specified amount of money to the account
        /// </summary>
        /// <param name="amount">The positive amount to deposit</param>
        public void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Withdraws an amount of money from the balance
        /// </summary>
        /// <param name="amount">The positive amount of money to be taken from the balance.</param>
        public void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
