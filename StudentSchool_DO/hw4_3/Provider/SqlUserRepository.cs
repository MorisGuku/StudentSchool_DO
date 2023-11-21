using DbModel;
using Microsoft.Data.SqlClient;
using hw_2;
using Microsoft.EntityFrameworkCore.Query;
using Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hw_2
{
    public class SqlUserRepository
    {
        private const string ConnectionString = @"Server=localhost,1433;Database=hw_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq@;TrustServerCertificate=true";
        private const string GetUsersSQL = @"SELECT * FROM Users";
        private const string CreateUser = @"INSERT INTO Users (UserId, FirstName, LastName, CreatedTime) VALUES (NEWID(), @FirstName, @LastName, @CreatedTime)";
        private const string EditUser = @"UPDATE Users SET FirstName = @FirstName, LastName = @LastName WHERE UserId = @GUID";
        private const string DeleteUser = @"DELETE FROM Users WHERE UserId = @GUID";
        public static void GetUsersSql()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(GetUsersSQL, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        string columnName5 = reader.GetName(4);

                        Console.WriteLine($"{columnName1} \t{columnName2} \t{columnName3} \t{columnName4} \t{columnName5}");

                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            Guid carId = reader.GetGuid(4);
                            string firstName = reader.GetString(1);
                            string lastName = reader.GetString(2);
                            DateTime createdTime = reader.GetDateTime(3);
                            Console.WriteLine($"{id} \t{firstName} \t{lastName} \t{createdTime} \t{carId}");
                        }
                    }
                }
            }

        }

        public static async void CreateUserSql(string firstName, string lastName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(CreateUser, sqlConnection);
                SqlParameter firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, -1);
                firstNameParam.Value = firstName;
                sqlCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, -1);
                lastNameParam.Value = lastName;
                sqlCommand.Parameters.Add(lastNameParam);
                sqlCommand.Parameters.Add(new SqlParameter("@CreatedTime", SqlDbType.DateTime) { Value = DateTime.UtcNow });
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void EditUserSql(Guid userId, string firstName, string lastName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(EditUser, sqlConnection);
                SqlParameter firstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar, -1);
                firstNameParam.Value = firstName;
                sqlCommand.Parameters.Add(firstNameParam);
                SqlParameter lastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar, -1);
                lastNameParam.Value = lastName;
                sqlCommand.Parameters.Add(lastNameParam);
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = userId });
                sqlCommand.ExecuteNonQuery();
            }

        }

        public static void DeleteUserSql(Guid userId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DeleteUser, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = userId });
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
    
}
