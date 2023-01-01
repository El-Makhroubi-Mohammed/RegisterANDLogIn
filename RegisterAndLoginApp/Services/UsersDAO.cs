using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public class UsersDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool FindUserByNameAndPassword(UserModel user)
        {

            bool success = false;

            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username  AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                }
            }

            return success;
            // return true if found in db.
        }

        public bool RegisterUser(UserModel user)
        {
            bool success = false;

            string sqlStatement = "INSERT INTO dbo.Users (username, password) VALUES (@username, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    Int32 rowAffected = command.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message); ;
                }
            }


            return success;
        }

    }
}
