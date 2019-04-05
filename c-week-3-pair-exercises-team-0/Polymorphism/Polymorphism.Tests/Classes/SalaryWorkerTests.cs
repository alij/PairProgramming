using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeePayroll.CLasses;


namespace Polymorphism.Tests.Classes
{
    [TestClass]
    public class SalaryWorkerTests
    {
        [TestMethod]
        public void CalculateWeeklyPay_Tests()
        {
            int hoursWorked = 10;
            double Result;
            SalaryWorker salaryWorker = new SalaryWorker(52000.0, "Warren", "stowe");

            Result = salaryWorker.CalculateWeeklyPay(hoursWorked);
            //assert is not null
            Assert.IsNotNull(Result, "should not be null");
            Assert.AreEqual(Result, 1000.0, "result is salary / 52");
            Assert.IsTrue(Result >= 0, "not a positive number");
        }
    }
}
