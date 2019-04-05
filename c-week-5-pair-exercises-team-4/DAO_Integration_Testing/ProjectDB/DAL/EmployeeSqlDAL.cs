using ProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDB.DAL
{
    public class EmployeeSqlDAL
    {
        private string connectionString;
        private const string SQL_GetAllEmployees = "select * from employee";
        private const string SQL_Search = @"select * from employee where first_name like '%' + @firstName + '%' 
                                            and last_name like '%' + @lastName + '%';";
        private const string SQL_EmployeesWithoutProjects = "select * from employee" +
            " left outer join project_employee on project_employee.employee_id = employee.employee_id" +
            " where project_employee.project_id is null;";

        // Single Parameter Constructor
        public EmployeeSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_GetAllEmployees;
                    cmd.Connection = connection;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempEmployee = new Employee();
                        tempEmployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempEmployee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        tempEmployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempEmployee.LastName = Convert.ToString(reader["last_name"]);
                        tempEmployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempEmployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        tempEmployee.Gender = Convert.ToString(reader["gender"]);
                        tempEmployee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        result.Add(tempEmployee);
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches the system for an employee by first name or last name.
        /// </summary>
        /// <remarks>The search performed is a wildcard search.</remarks>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>A list of employees that match the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_Search;
                    cmd.Parameters.AddWithValue("@firstName", firstname);
                    cmd.Parameters.AddWithValue("@lastName", lastname);
                    cmd.Connection = connection;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempEmployee = new Employee();
                        tempEmployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempEmployee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        tempEmployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempEmployee.LastName = Convert.ToString(reader["last_name"]);
                        tempEmployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempEmployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        tempEmployee.Gender = Convert.ToString(reader["gender"]);
                        tempEmployee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        result.Add(tempEmployee);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = SQL_EmployeesWithoutProjects;
                    cmd.Connection = connection;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempEmployee = new Employee();
                        tempEmployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempEmployee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        tempEmployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempEmployee.LastName = Convert.ToString(reader["last_name"]);
                        tempEmployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempEmployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        tempEmployee.Gender = Convert.ToString(reader["gender"]);
                        tempEmployee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        result.Add(tempEmployee);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
            throw new NotImplementedException();
        }
    }
}
