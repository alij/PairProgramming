using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    public class HourlyWorker : IWorker
    {
        public string FirstName { get; }
        public string LastName { get; }
        public double HourlyRate { get; }

        public HourlyWorker() { }

        public HourlyWorker(double hourlyRate, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
        }

        public double CalculateWeeklyPay(int hoursWorked)
        {
            int overtime = hoursWorked - 40;
            double pay = hoursWorked * HourlyRate;

            if (hoursWorked <= 40)
            {
                return pay;
            } else 
            {
                return (pay) + (overtime * (HourlyRate * 0.5));
            }

            
        }

    }
}
