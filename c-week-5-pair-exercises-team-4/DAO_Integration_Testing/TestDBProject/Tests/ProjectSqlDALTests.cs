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

namespace TestDBProject.Tests
{
    [TestClass]
    public class ProjectSqlDALTests
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True";
        private int numberOfProjects = 0;
        private int newProjectID = 0;
        private int newEmployeeID = 0;

        private TransactionScope transactionScope;

        [TestInitialize]
        public void Initialize()
        {
            transactionScope = new TransactionScope();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                sqlConnection.Open();


                command = new SqlCommand("insert into employee values (1, 'Mikael', 'Cheap', 'Student', '1989-04-17', 'M', '2019-01-14'); select @@IDENTITY;", sqlConnection);
                newEmployeeID = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("insert into project values ('The Newest Project', '2015-05-15', '2018-03-20'); select @@IDENTITY;", sqlConnection);
                newProjectID = Convert.ToInt32(command.ExecuteScalar());

                command = new SqlCommand("select count(*) from project;", sqlConnection);
                numberOfProjects = Convert.ToInt32(command.ExecuteScalar());

            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void GetAllProjectsTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);

            IList<Project> projects = projectSqlDAL.GetAllProjects();

            Assert.IsNotNull(projects, "GetAllProjects failed, the list was null.");
            Assert.AreEqual(numberOfProjects, projects.Count, "GetAllProjects failed, an incorrect number of projects has been returned.");
        }

        [TestMethod]
        public void AssignEmployeeToProjectTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);

            bool didItWork = projectSqlDAL.AssignEmployeeToProject(newProjectID, newEmployeeID);

            Assert.IsTrue(didItWork);
        }

        [TestMethod]
        public void RemoveEmployeeFromProjectTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);

            bool didItWork = projectSqlDAL.AssignEmployeeToProject(newProjectID, newEmployeeID);

            Assert.IsTrue(didItWork);
        }

        [TestMethod]
        public void CreateProjectTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);

            Project project = new Project
            {
                Name = "Integration Testing Is Great",
                StartDate = new DateTime(2015, 2, 15),
                EndDate = new DateTime(2019, 2, 19),
            };

            int didItWork = projectSqlDAL.CreateProject(project);

            Assert.AreNotEqual(0, didItWork, "Create Project failed, the method returned 0.");
        }
    }
}
