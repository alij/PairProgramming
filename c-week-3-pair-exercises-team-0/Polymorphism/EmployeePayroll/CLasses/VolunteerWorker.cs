using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    public class VolunteerWorker : IWorker
    {

        public string FirstName { get; }

        public string LastName { get; }

        public VolunteerWorker() { }

        public VolunteerWorker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public double CalculateWeeklyPay(int hoursWorked)
        {
            return 0;
        }

    }
}
