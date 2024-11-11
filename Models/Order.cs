using System.Data.SqlClient;

namespace ST10390916CLDVPOE.Models
{
    public class Order
    {
        public static string conString = "Server=tcp:st10390916-db-server.database.windows.net,1433;Initial Catalog=st10390916-db;Persist Security Info=False;User ID=st10390916;Password=6!n5J$J7asn7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(conString);

        public string OrderID { get; set; }
        public string Message { get; set; }

        //-----------------------------------------Insert Order------------------------------------------------------------------

        public int InsertOrder(Order order)
        {
            string sql = "INSERT INTO orders (Message) VALUES (@Message)";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Message", order.Message);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
