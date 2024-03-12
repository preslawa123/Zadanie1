using CRUD_2.Common;
using CRUD_2.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_2.Data
{
    public class ProductData
    {
        public List<Product> GetAll()
        {
            var productList = new List<Product>();
            SqlConnection con = Database.GetConnection();
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand();
                command.Connection= con;
                command.CommandText = "Select * from product";
                SqlDataReader reader = command.ExecuteReader();
                using(reader)
                {
                    while (reader.Read())
                    {
                        Product product = new Product((int)reader.GetValue(0), (string)reader.GetValue(1), (decimal)reader.GetValue(2), (int)reader.GetValue(3));
                        productList.Add(product);

                    }
                }
            }
            con.Close();
            return productList;
            
        }

        public Product Get(int id)
        {
            Product product = null;
            SqlConnection con = Database.GetConnection();
            con.Open();
            using (con)
            {
                SqlCommand command = new SqlCommand();
                command.Connection= con;
                command.CommandText = "Select * from product where id = @id";
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                using(reader)
                {
                    if (reader.Read())
                    {
                         product = new Product((int)reader.GetValue(0), (string)reader.GetValue(1), (decimal)reader.GetValue(2), (int)reader.GetValue(3));
                        
                    }
                }
            }
            con.Close();
            return product;
        }


        public void Add(Product product)
        {
            var con = Database.GetConnection();
            using (con)
            {
                con.Open();
                var command = new SqlCommand("Inset into product(name, price, stock) values(@name, @price, @stock)",con);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
                con.Close();

            }
        }

        public void Update(Product product)
        {
            var con = Database.GetConnection();
            using (con)
            {
                var command = new SqlCommand("Update product set name = @name, price = @price, stock = @stock where id = @id", con);
                command.Parameters.AddWithValue("@id", product.ID);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@stock", product.Stock);
                command.ExecuteNonQuery();
                con.Close();

            }
        }
           
        public void Delete(int id)
        {
            var con = Database.GetConnection();
            using(con)
            {
                con.Open();
                var command = new SqlCommand("Delete from product where id = @id", con);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
       
    }
}
