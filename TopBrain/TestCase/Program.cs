using NUnit.Framework;   
using System;            
[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(100m);
        account.Deposit(50m);
        Assert.AreEqual(150m, account.Balance);
    }
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(100m);
        Assert.Throws<Exception>(() => account.Deposit(-20m));
    }
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(200m);
        account.Withdraw(50m);
        Assert.AreEqual(150m, account.Balance);
    }
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(100m);
        Assert.Throws<Exception>(() => account.Withdraw(200m));
    }
}
