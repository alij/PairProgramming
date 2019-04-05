using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAL
    {

        private string connectionString;

        public ProductSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"select * from products where product_id = @id;", connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        product.ProductId = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["name"]);
                        product.Description = Convert.ToString(reader["description"]);
                        product.Price = Convert.ToDecimal(reader["price"]);
                        product.ImageName = Convert.ToString(reader["image_name"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return product;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand($"select * from products;", connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.ProductId = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["name"]);
                        product.Description = Convert.ToString(reader["description"]);
                        product.Price = Convert.ToDecimal(reader["price"]);
                        product.ImageName = Convert.ToString(reader["image_name"]);

                        products.Add(product);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return products;
        }

        
    }

}
