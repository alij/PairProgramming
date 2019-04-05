using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    { 
        public SavingsAccount()
            : base()
        {
            AccountNumber += "SV";
            AccountNumber += BankCustomer.CurrentAccount.ToString();
        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > Balance)
            {
                Console.WriteLine("Invalid withdraw.  There are not enough funds.");
                return Balance;
            } else if (Balance < 150.00M)
            {
                Console.WriteLine("Available funds are less than $150, a two dollar surcharge has been applied.");
                return base.Withdraw(amountToWithdraw + 2.00M);
            } else
            {
                Console.WriteLine("Withdraw successful.");
                return base.Withdraw(amountToWithdraw);
            }
        }
    }
}
