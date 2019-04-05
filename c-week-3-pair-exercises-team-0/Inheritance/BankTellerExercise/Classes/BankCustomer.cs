using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise.Classes
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool isVIP
        {
            get
            {
                decimal accountTotal = 0;

                foreach (BankAccount account in ListOfAccounts)
                {
                    accountTotal += account.Balance;
                }

                return accountTotal >= 25000M;
            }
        }

        public static int CurrentAccount { get; set; } = 100000;

        public List<BankAccount> ListOfAccounts = new List<BankAccount>();
        public BankAccount[] Accounts
        {
            get { return ListOfAccounts.ToArray(); }
        }

        public void AddAccount(BankAccount newAccount)
        {
            ListOfAccounts.Add(newAccount);
        }
    }
}
