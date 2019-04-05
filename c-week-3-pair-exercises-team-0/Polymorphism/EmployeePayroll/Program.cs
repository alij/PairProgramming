using EmployeePayroll.CLasses;
using System;
using System.Collections.Generic;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorker> employeeList = new List<IWorker>();


            employeeList.Add(new SalaryWorker(52000.50, "Donald", "Alan"));
            employeeList.Add(new VolunteerWorker("Tzvi", "Seliger"));
            employeeList.Add(new HourlyWorker(8.00, "Warren", "Stowe"));
            employeeList.Add(new HourlyWorker(20.00, "Angela", "Garner"));

            int totalHours = 0;
            decimal totalPay = 0.00M;

            Console.WriteLine("Employee\t\tHours Worked\t\tPay");
            Console.WriteLine("================================================================");

            foreach (IWorker employee in employeeList)
            {
                Random r = new Random();
                int hours = r.Next(30, 50);

                decimal pay = (decimal)employee.CalculateWeeklyPay(hours);
                pay = Math.Round(pay, 2);
                
                Console.WriteLine($"{employee.LastName}, {employee.FirstName}\t\t{hours}\t\t\t${pay}");

                totalHours += hours;
                totalPay += pay;
            }

            totalPay = Math.Round(totalPay, 2);
            Console.WriteLine();
            Console.WriteLine($"Total Hours: {totalHours}");
            Console.WriteLine($"Total Pay: ${totalPay}");

            Console.ReadKey();
        }
    }
}
