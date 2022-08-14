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
        private string owner;

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
        public string Owner
        {
            get { return owner; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Owner)} cannot be null");
                }
                
                if (value.Trim() == String.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} must have some text");
                }

                if (IsOwnerNameValid(value)) 
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Owner)} can be up to 20 characters, A-Z/spaces only.");

                }
            }
        }

        /// <summary>
        /// Checks if Owner name is less than or equal to 20 characters, A - Z and whitespace
        /// characters are allowed
        /// </summary>
        /// <param name="ownerName">Name of owner of the account</param>
        /// <returns>true if the owners name is a valid one, otherwise false</returns>
        private bool IsOwnerNameValid(string ownerName)
        {
            char[] validCharacters = {'A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g'
                    , 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P'
                    , 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x'
                    , 'Y', 'y', 'Z', 'z', ' '};

            const int MaxLengthOwnerName = 20;
            if (ownerName.Length > MaxLengthOwnerName)
            {
                return false;
            }

            foreach (char letter in ownerName)
            {
                if (letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specified amount of money to the account.Returns the new balance.
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        /// <returns>The new balance after the deposit.</returns>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
            }
            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws an amount of money from the balance and returns updated balance
        /// </summary>
        /// <param name="amt">The positive amount of money to be taken from the balance.</param>
        /// <returns>the updated balance after withdrawal</returns>
        public double Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new ArgumentException($"The {nameof(amt)} must be less than the {nameof(Balance)}");
            }
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
            }
            Balance -= amt;
            return Balance;
        }
    }
}
