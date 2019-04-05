using System;
using System.Collections.Generic;
using System.Text;


namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount()
            : base()
        {
            AccountNumber += "CH";
            AccountNumber += BankCustomer.CurrentAccount.ToString();
        }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if ((Balance - amountToWithdraw < 0))
            {
                if (Balance - (amountToWithdraw + 10M) < -100M)
                {
                    Console.WriteLine("Inadequate funds, returning Balance.");
                    return Balance;
                }
                else
                {
                    base.Withdraw(amountToWithdraw + 10.00M);
                }
            }
            else
            {
                base.Withdraw(amountToWithdraw);
            }
            return Balance;
        }
    }
}
