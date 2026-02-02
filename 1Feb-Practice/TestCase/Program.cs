using NUnit.Framework;   // NUnit framework for unit testing
using System;            // Required for Exception class

// TestFixture attribute marks this class as a test class
[TestFixture]
public class UnitTest
{
    // ============================
    // TEST CASE 1: Deposit Valid Amount
    // ============================
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        // Arrange:
        // Create an account with an initial balance of 100
        Program account = new Program(100m);

        // Act:
        // Deposit a valid amount (50)
        account.Deposit(50m);

        // Assert:
        // Check if balance becomes 150 after deposit
        Assert.AreEqual(150m, account.Balance);
    }

    // ============================
    // TEST CASE 2: Deposit Negative Amount
    // ============================
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        // Arrange:
        // Create an account with an initial balance of 100
        Program account = new Program(100m);

        // Act & Assert:
        // Depositing a negative amount should throw an Exception
        Assert.Throws<Exception>(() => account.Deposit(-20m));
    }

    // ============================
    // TEST CASE 3: Withdraw Valid Amount
    // ============================
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        // Arrange:
        // Create an account with an initial balance of 200
        Program account = new Program(200m);

        // Act:
        // Withdraw a valid amount (50)
        account.Withdraw(50m);

        // Assert:
        // Check if balance becomes 150 after withdrawal
        Assert.AreEqual(150m, account.Balance);
    }

    // ============================
    // TEST CASE 4: Withdraw with Insufficient Funds
    // ============================
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        // Arrange:
        // Create an account with insufficient balance
        Program account = new Program(100m);

        // Act & Assert:
        // Withdrawing more than balance should throw an Exception
        Assert.Throws<Exception>(() => account.Withdraw(200m));
    }
}
