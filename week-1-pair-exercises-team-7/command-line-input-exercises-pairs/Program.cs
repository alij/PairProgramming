using System;

namespace command_line_input_exercises_pairs
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            bool runAgain = true;

            do
            {
                // Prompt the user for the total bill, read the input
                Console.Write("Enter the total bill: ");
                string billInput = Console.ReadLine();
                decimal totalBill = decimal.Parse(billInput);

                // Prompt the user for the amount tendered, read the input
                Console.Write("Enter the amount paid: ");
                string paidInput = Console.ReadLine();
                decimal totalPaid = decimal.Parse(paidInput);

                // Calculate the change, output the result
                decimal change = CalculateChange(totalBill, totalPaid);
                Console.WriteLine($"The total change is ${change}.");

                Console.Write("Enter y if you would like to run the program again: ");
                string choice = Console.ReadLine();

                if (choice != "y")
                {
                    runAgain = false;
                }
            }
            while (runAgain);


        }

        public static decimal CalculateChange(decimal bill, decimal paid)
        {
            return paid - bill;
        } 
    }
}
