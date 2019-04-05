using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeePayroll.CLasses;


namespace Polymorphism.Tests.Classes
{
    [TestClass]
    public class VolunteerWorkerTests
    {
        [TestMethod]
        public void CalculateWeeklyPay_Tests()
        {
            int hoursWorked = 10;
            double Result;
            VolunteerWorker volunteerWorker = new VolunteerWorker("Warren", "stowe");

            Result = volunteerWorker.CalculateWeeklyPay(hoursWorked);
            //assert is not null
            Assert.IsNotNull(Result, "should not be null");
            Assert.AreEqual(Result, 0, "result should be 0");
        }
    }
}
