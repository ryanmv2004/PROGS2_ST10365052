using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDVapp.Models
{
    public class transactionTable 
    {
        public int transactionID { get; set; }
        public int userID { get; set; }
        public int productID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }

        public static string con_string = "Server=tcp:st10365052cldva1.database.windows.net,1433;Initial Catalog=st10365052cdlbdatabse;Persist Security Info=False;User ID=ryanv2304;Password=AceVents12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int orderProduct(transactionTable t)
        {
                string sql = "INSERT INTO transactionTable (UserID, ProductID, Name, Description, Price) VALUES (@userID, @productID, @name, @description, @price)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@userID", t.userID);
                cmd.Parameters.AddWithValue("@productID", t.productID);
                cmd.Parameters.AddWithValue("@name", t.name);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@price", t.price);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
        }

        public List<transactionTable> getTransactions(int userID)
        {
            List<transactionTable> transactions = new List<transactionTable>();
            try
            {
                string sql = "SELECT * FROM[dbo].[transactionTable]WHERE UserID = @userID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    transactions.Add(new transactionTable
                    {
                        transactionID = Convert.ToInt32(reader["transactionID"]),
                        userID = Convert.ToInt32(reader["userID"]),
                        productID = Convert.ToInt32(reader["productID"]),
                        name = reader["name"].ToString(),
                        description = reader["description"].ToString(),
                        price = reader["price"].ToString(),
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return transactions;
        }

    }

    
}


