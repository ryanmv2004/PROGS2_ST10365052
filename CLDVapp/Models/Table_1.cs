using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDVapp.Models
{
    public class Table_1
    {
        private string name { get; set; }
        private string email { get; set; }
        private string password { get; set; }

        public static string con_string = "Server=tcp:st10365052cldva1.database.windows.net,1433;Initial Catalog=st10365052cdlbdatabse;Persist Security Info=False;User ID=ryanv2304;Password=AceVents12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int insert_User(Table_1 m) 
        {
            try 
            {
                string sql = "INSERT INTO Table_1 (UserName, UserEmail, UserPassword) VALUES (@name, @email, @password)";
                Console.WriteLine("SQL Query: " + sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                    
                cmd.Parameters.AddWithValue("@name", m.name);
                cmd.Parameters.AddWithValue("@email", m.email);
                cmd.Parameters.AddWithValue("@password", m.password);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return -1;
            }
        }
   
    }
}
