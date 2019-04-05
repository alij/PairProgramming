using System;
using BankTellerExercise.Classes;

namespace BankTellerExercise
{
    class Program
    {
        static void Main(string[] args)
        {

            BankAccount checkingAccount = new CheckingAccount();
            checkingAccount.Deposit(1000M);
            BankAccount savingsAccount = new SavingsAccount();
            savingsAccount.Deposit(500M);

            Console.WriteLine(checkingAccount.AccountNumber);
            Console.WriteLine(savingsAccount.AccountNumber);

            BankCustomer jayGatsby = new BankCustomer();
            jayGatsby.AddAccount(checkingAccount);
            jayGatsby.AddAccount(savingsAccount);

            bool customerBanking = true;

            while (customerBanking)
            {
                string action = BankAccount.ATM();

                if (action.Equals("b"))
                {
                    BankAccount.OutputBalances(jayGatsby.ListOfAccounts);
                    continue;
                }

                string accountInput = BankAccount.ChooseAccount(jayGatsby.ListOfAccounts);
                decimal money = BankAccount.AmountOfMoney();

                if (action.Equals("d"))
                {
                    foreach (BankAccount account in jayGatsby.ListOfAccounts)
                    {
                        if (account.AccountNumber == accountInput)
                        {
                            account.Deposit(money);
                        }
                    }

                }
                else if (action.Equals("w"))
                {
                    foreach (BankAccount account in jayGatsby.ListOfAccounts)
                    {
                        if (account.AccountNumber == accountInput)
                        {
                            account.Withdraw(money);
                        }
                    }
                }
                else if (action.Equals("t"))
                {
                    string accountTransfer = BankAccount.ChooseAccount(jayGatsby.ListOfAccounts);

                    foreach (BankAccount account in jayGatsby.ListOfAccounts)
                    {
                        if (account.AccountNumber == accountInput)
                        {
                            account.Withdraw(money);
                        }

                        if (account.AccountNumber == accountTransfer)
                        {
                            account.Deposit(money);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Exiting . . . ");
                    customerBanking = false;
                }
            }
            
            
                
            Console.ReadKey();
        }
    }
}
