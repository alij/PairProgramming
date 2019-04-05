using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise.Classes
{
    public abstract class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount()
        {
            Balance = 0.00M;
            BankCustomer.CurrentAccount += 1;
        }

        public decimal Deposit(decimal amountToDeposit)
        {
            Console.WriteLine($"Deposit successful, {amountToDeposit} added to account.");
            return Balance += amountToDeposit;
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Console.WriteLine($"Withdraw successful, {amountToWithdraw} removed from account.");
            Console.WriteLine($"Your balance is {Balance - amountToWithdraw}.");
            return Balance -= amountToWithdraw;
        }

        public void Transfer(BankAccount destinationAccount, decimal transferAmount)
        {
            Console.WriteLine($"Transfer successful, {transferAmount} transferred to {destinationAccount}.");
            Balance -= transferAmount;
            destinationAccount.Deposit(transferAmount);
        }

        public static string ATM()
        {
            Console.Write("Would you like to (d)eposit, (w)ithdraw, (t)ransfer, or view (b)alances? ");
            string input = Console.ReadLine().ToLower();
            return input;
        }

        public static string ChooseAccount(List<BankAccount> bankAccounts)
        {
            Console.WriteLine("Input account number: ");
            int number = 1;

            foreach (BankAccount account in bankAccounts)
            {
                Console.WriteLine($"{number}: {account.AccountNumber}");
                number += 1;
            }

            string input = Console.ReadLine();
            return input;
        }

        public static decimal AmountOfMoney()
        {
            Console.WriteLine("How much money?");
            decimal money = decimal.Parse(Console.ReadLine());
            return money;
        }

        public static void OutputBalances(List<BankAccount> bankAccounts)
        {
            foreach (BankAccount account in bankAccounts)
            {
                Console.WriteLine(account.Balance);
            }
        }
    }
}
