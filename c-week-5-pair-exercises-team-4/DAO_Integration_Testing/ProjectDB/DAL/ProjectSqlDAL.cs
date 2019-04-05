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
    public class ProjectSqlDAL
    {
        private string connectionString;
        private const string SQL_CreateProject = @"insert into Project values (@name, @from_date, @to_date);select @@IDENTITY;";

        private const string SQL_RemoveEmployeeFromProject = @"delete project_employee where project_id = @project_id and employee_id = @employee_id;";

        private const string SQL_AllProjects = @"select *  from Project order by project_id;";

        private const string SQL_AssignEmployeeToProject = @"insert into project_employee values (@project_id, @employee_id);";

        // Single Parameter Constructor
        public ProjectSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects() // good
        {
            List<Project> output = new List<Project>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_AllProjects;
                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Project tempProject = new Project();
                        tempProject.Name = Convert.ToString(reader["name"]);
                        tempProject.ProjectId = Convert.ToInt32(reader["project_id"]);
                        tempProject.StartDate = Convert.ToDateTime(reader["from_date"]);
                        tempProject.EndDate = Convert.ToDateTime(reader["to_date"]);
                        output.Add(tempProject);
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
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId) // good
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_AssignEmployeeToProject;
                    command.Parameters.AddWithValue("@project_id", projectId);
                    command.Parameters.AddWithValue("@employee_id", employeeId);
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

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_RemoveEmployeeFromProject;
                    command.Parameters.AddWithValue("@project_id", projectId);
                    command.Parameters.AddWithValue("@employee_id", employeeId);
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

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject) // good
        {
            int newID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = SQL_CreateProject;
                    command.Parameters.AddWithValue("@name", newProject.Name);
                    command.Parameters.AddWithValue("@from_date", newProject.StartDate);
                    command.Parameters.AddWithValue("@to_date", newProject.EndDate);
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

    }
}
