using Azure.Data.Tables;
using Azure;
using System.Data.SqlClient;
using System.Data;

namespace ST10390916CLDVPOE.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductCode { get; set; }
        public double ProductWeight { get; set; }

        public static string conString = "Server=tcp:st10390916-db-server.database.windows.net,1433;Initial Catalog=st10390916-db;Persist Security Info=False;User ID=st10390916;Password=6!n5J$J7asn7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(conString);

        //-----------------------------------------Insert Product------------------------------------------------------------

        public int InsertProduct(Product product)
        {
            string sql = "INSERT INTO products (ProductName, Price, ProductCode, ProductWeight) VALUES (@ProductName, @Price, @ProductCode, @ProductWeight)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            cmd.Parameters.AddWithValue("@ProductWeight", product.ProductWeight);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
