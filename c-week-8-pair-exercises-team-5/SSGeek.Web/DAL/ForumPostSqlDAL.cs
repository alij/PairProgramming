using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAL 
    {
        private string connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ForumPost> GetAllPosts()
        {
            List<ForumPost> forumPosts = new List<ForumPost>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"select * from forum_post;", connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        ForumPost forumPost = new ForumPost();

                        forumPost.Username = Convert.ToString(reader["username"]);
                        forumPost.Subject = Convert.ToString(reader["subject"]);
                        forumPost.Message = Convert.ToString(reader["message"]);
                        forumPost.PostDate = Convert.ToDateTime(reader["post_date"]);

                        forumPosts.Add(forumPost);

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return forumPosts;
        }

        public bool SaveNewPost(ForumPost post)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Insert into forum_post values (@username, @subject, @message, @date);", connection);
                    cmd.Parameters.AddWithValue("@username", post.Username);
                    cmd.Parameters.AddWithValue("@subject", post.Subject);
                    cmd.Parameters.AddWithValue("@message", post.Message);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
