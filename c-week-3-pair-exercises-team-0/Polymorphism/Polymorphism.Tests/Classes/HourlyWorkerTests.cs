using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeePayroll.CLasses;


namespace Polymorphism.Tests.Classes
{
    [TestClass]
    public class HourlyWorkerTests
    {
        [TestMethod]
        public void CalculateWeeklyPay_Tests()
        {
            int hoursWorked = 10;
            double HoursWorked_Result;
            HourlyWorker hourlyWorker = new HourlyWorker(2.0, "Warren", "stowe");  

            HoursWorked_Result = hourlyWorker.CalculateWeeklyPay(hoursWorked);
            //assert is not null
            Assert.IsNotNull(HoursWorked_Result, "should not be null");
            Assert.AreEqual(HoursWorked_Result, 20.0, "result is  hours worked times hourly rate");
            Assert.IsTrue(HoursWorked_Result >= 0, "not a positive number");
        }
    }
}
