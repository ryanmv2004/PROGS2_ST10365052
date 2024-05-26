using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDVapp.Models
{
    public class LoginFeature
    {
        public static string con_string = "Server=tcp:st10365052cldva1.database.windows.net,1433;Initial Catalog=st10365052cdlbdatabse;Persist Security Info=False;User ID=ryanv2304;Password=AceVents12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int FetchUser(string email, string password)
        {
            int userID = -1;
            using (con)
            {
                string sql = "SELECT UserID FROM userTable WHERE UserEmail = @Email AND UserPassword = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    userID = Convert.ToInt32(result);
                }
            }
            return userID;
        }
    }
}
