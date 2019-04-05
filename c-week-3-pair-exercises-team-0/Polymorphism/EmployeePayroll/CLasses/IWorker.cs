using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll.CLasses
{
    interface IWorker
    {
        string FirstName { get; }
        string LastName { get; }

        double CalculateWeeklyPay(int hoursWorked);
    }
}
