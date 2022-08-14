using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount() 
        {
            acc = new Account("J Doe");
        }
        
        
        [TestMethod]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9999.99)]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA = Arrange Act Assert
            // Arrange
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add


            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));

            
        }

        // Withdrawing a positive amount - decrease balance


        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_DecreasesBalance() 
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedReturn = initialDeposit - withdrawAmount;


            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedReturn, actualBalance);
        }

        [TestMethod]
        [DataRow(100, 50)] 
        [DataRow(100, .99)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawAmount;
            
            
            // Act
            acc.Deposit(initialDeposit);
            double returnedBalance = acc.Withdraw(withdrawAmount);
            
            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
        }
        
        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount)
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));

        }
        
        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            // Arrange
            double withdrawAmount = 1000;
            // Act

            // Assert
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }
        
        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }
        
        [TestMethod]
        [TestCategory("Owner")]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>((() => acc.Owner = String.Empty));
            Assert.ThrowsException<ArgumentException>((() => acc.Owner = "  "));
        }
        
        [TestMethod]
        [TestCategory("Owner")]
        [DataRow("John")]
        [DataRow("John Doe")]
        [DataRow("Joseph Ortizio Smith")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [TestCategory("Owner")]
        [DataRow("Joe 3rd")]
        [DataRow("Joseph Ortizio Smiths")]
        [DataRow("#$%$@!&")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}
// Withdrawing 0 - throws ArgumentOutOfRange exception
// Withdrawing a negative amount - throws ArgumentOutOfRange exception
// Withdrawing more than the available balance - throws ArgumentException