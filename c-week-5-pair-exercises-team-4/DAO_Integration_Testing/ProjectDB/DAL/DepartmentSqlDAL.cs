using ProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjectDB.DAL
{
    public class DepartmentSqlDAL
    {
        private string connectionString;
        private const string SQL_CreateDepartment = @"insert into Department values (@name);select @@IDENTITY;";
        private const string SQL_DepartmentNumber = @"select department_id from Department where name = @name;";
        private const string SQL_AllDepartments = @"select *  from Department order by department_id;";
        private const string SQL_UpdateDepartment = @"update Department set name = @name where department_id = @department_id;";

        // Single Parameter Constructor
        public DepartmentSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            List<Department> output = new List<Department>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_AllDepartments;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Department tempDept = new Department();
                        tempDept.Name = Convert.ToString(reader["name"]);
                        tempDept.Id = Convert.ToInt32(reader["department_id"]);
                        output.Add(tempDept);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return output;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            int newID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_CreateDepartment;
                    command.Parameters.AddWithValue("@name", newDepartment.Name);
                    command.Connection = connection;
                    newID = Convert.ToInt32(command.ExecuteScalar());                                              
                    
                }
                return newID;
               
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        
        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_UpdateDepartment;
                    command.Parameters.AddWithValue("@name", updatedDepartment.Name);
                    command.Parameters.AddWithValue("@department_id", updatedDepartment.Id);
                    command.Connection = connection;
                    int rowsAffected = command.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
