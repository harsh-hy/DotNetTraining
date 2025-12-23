using System;

namespace Github
{
    public class AtmWithdrawal
    {
        static void Main()
        {
            Console.Write("Insert card (true/false): ");
            bool isCardInserted = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter PIN correct? (true/false): ");
            bool isPinValid = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter account balance: ");
            decimal accountBalance = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter withdrawal amount: ");
            decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

            string result = WithdrawMoney(isCardInserted, isPinValid, accountBalance, withdrawalAmount);
            Console.WriteLine(result);
        }

        public static string WithdrawMoney(bool isCardInserted, bool isPinValid,
                                           decimal accountBalance, decimal withdrawalAmount)
        {
            if (!isCardInserted)
                return "Please insert your card to proceed.";

            if (!isPinValid)
                return "Invalid PIN. Please try again.";

            if (withdrawalAmount <= 0)
                return "Invalid withdrawal amount.";

            if (accountBalance < withdrawalAmount)
                return "Insufficient balance.";

            accountBalance -= withdrawalAmount;
            return $"Withdrawal successful! Remaining balance: ₹{accountBalance:F2}";
        }
    }
}
