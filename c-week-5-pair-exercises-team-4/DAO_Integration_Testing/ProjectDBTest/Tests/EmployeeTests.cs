using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectDB.Models;
using ProjectDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace ProjectDBTest.Test
{
    [TestClass()]
    public class EmployeeTests
    {

        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=true";
        private int numberOfEmployees = 0;
        private int employeeID = 0;
        private int employeesWithoutProjects = 0;
        private TransactionScope transactionScope;

        // Set up the database before each test        
        [TestInitialize]
        public void Initialize()
        {
            transactionScope = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                connection.Open();
                             
                command = new SqlCommand("select count(*) from employee;", connection);
                numberOfEmployees = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("select count(*) from employee left outer join project_employee on project_employee.employee_id = employee.employee_id where project_employee.project_id is null;",connection);
                employeesWithoutProjects = Convert.ToInt32(command.ExecuteScalar());

                //Insert a Dummy Record 
                command = new SqlCommand("insert into employee values('1','Bobby','Tables','That Guy', '2-22-1999', 'M', '2-19-2019');SELECT @@IDENTITY", connection);
                employeeID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void GetAllEmployeesTest() // good test
        {
            // Arrange
            EmployeeSqlDAL employeeSqlDAL = new EmployeeSqlDAL(connectionString);

            // act
            IList<Employee> employees = employeeSqlDAL.GetAllEmployees();

            // Assert
            Assert.IsNotNull(employees);
            Assert.AreEqual(numberOfEmployees + 1, employees.Count);
        }
        [TestMethod]
        public void SearchTest() // good test
        {
            // Arrange
            EmployeeSqlDAL employeeSqlDAL = new EmployeeSqlDAL(connectionString);

            // act
            IList<Employee> employees = employeeSqlDAL.Search("Bobby", "Tables");

            // Assert
            Assert.IsNotNull(employees);
            Assert.AreEqual(employeeID, employees[0].EmployeeId);
        }
        [TestMethod]
        public void GetEmployeesWithoutProjectsTest() // good test
        {
            // Arrange
            EmployeeSqlDAL employeeSqlDAL = new EmployeeSqlDAL(connectionString);

            // act
            IList<Employee> employees = employeeSqlDAL.GetEmployeesWithoutProjects();

            // Assert
            Assert.IsNotNull(employees);
            Assert.AreEqual(employeesWithoutProjects + 1, employees.Count);
        }
    }
}