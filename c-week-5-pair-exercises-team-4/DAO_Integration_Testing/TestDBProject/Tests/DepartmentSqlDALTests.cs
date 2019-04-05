using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using ProjectDB.Models;
using System.Data;

namespace TestDBProject
{
    [TestClass()]
    public class DepartmentSqlDALTests
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True";
        private int numberOfDepartments = 0;
        private int departmentID = 0;

        private TransactionScope transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            transactionScope = new TransactionScope();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                sqlConnection.Open();

                command = new SqlCommand("select count(*) from department;", sqlConnection);
                numberOfDepartments = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("Insert into department values ('Hogwarts');select @@IDENTITY;", sqlConnection);
                departmentID = Convert.ToInt32(command.ExecuteScalar());


            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void GetDepartmentsTest()
        {
            DepartmentSqlDAL departmentSqlDAL = new DepartmentSqlDAL(connectionString);

            IList<Department> departments = departmentSqlDAL.GetDepartments();

            Assert.IsNotNull(departments, "GetDepartments failed, the list was null.");
            Assert.AreEqual(numberOfDepartments + 1, departments.Count, "GetDepartments failed, an incorrect number of departments has been returned.");
        }

        [TestMethod]
        public void CreateDepartmentTest()
        {
            DepartmentSqlDAL departmentSqlDAL = new DepartmentSqlDAL(connectionString);
            Department department = new Department
            {
                Name = "A New Department"
            };

            int didItWork = departmentSqlDAL.CreateDepartment(department);

            Assert.AreNotEqual(0, didItWork, "CreateDepartment failed, it returned 0.");
        }

        [TestMethod]
        public void UpdateDepartmentTest()
        {
            DepartmentSqlDAL departmentSqlDAL = new DepartmentSqlDAL(connectionString);
            Department department = new Department
            {
                Name = "The Next Department",
                Id = 2
            };

            bool didItWork = departmentSqlDAL.UpdateDepartment(department);

            Assert.IsTrue(didItWork);
        }
    }
}
