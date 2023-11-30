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
using System.ComponentModel;
using System.Data;

namespace hw_2
{
    public class SqlCarRepository
    {
        private const string ConnectionString = @"Server=localhost,1433;Database=hw_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq@;TrustServerCertificate=true";
        private const string GetCarsSQL = @"SELECT * FROM Cars";
        private const string CreateCar = @"INSERT INTO Cars (Id, BrandCar, ModelCar, CoastCar) VALUES (NEWID(), @BrandCar, @ModelCar, @CoastCar)";
        private const string EditCar = @"UPDATE Cars SET BrandCar = @BrandCar, ModelCar = @ModelCar, CoastCar = @CoastCar WHERE Id = @GUID";
        private const string DeleteCar = @"DELETE FROM Cars WHERE Id = @GUID";
        public static void GetCarsSql()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(GetCarsSQL, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        string columnName4 = reader.GetName(3);
                        Console.WriteLine($"{columnName1} \t{columnName2} \t{columnName3} \t{columnName4}");

                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string brandCar = reader.GetString(1);
                            string modelCar = reader.GetString(2);
                            int coastCar = reader.GetInt32(3);
                            Console.WriteLine($"{id} \t{brandCar} \t{modelCar} \t{coastCar}");
                        }
                    }
                }
            }
        }

        public static void CreateCarSql(string brandCar, string modelCar, int coastCar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(CreateCar, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@BrandCar", SqlDbType.NVarChar, -1) { Value = brandCar});
                sqlCommand.Parameters.Add(new SqlParameter("@ModelCar", SqlDbType.NVarChar, -1) { Value = modelCar});
                sqlCommand.Parameters.Add(new SqlParameter("@CoastCar", SqlDbType.Int) { Value = coastCar});
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void EditCarSql(Guid carId, string brandCar, string modelCar, int coastCar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(EditCar, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = carId});
                sqlCommand.Parameters.Add(new SqlParameter("@BrandCar", SqlDbType.NVarChar, -1) { Value = brandCar});
                sqlCommand.Parameters.Add(new SqlParameter("@ModelCar", SqlDbType.NVarChar, -1) { Value = modelCar});
                sqlCommand.Parameters.Add(new SqlParameter("@CoastCar", SqlDbType.Int) { Value = coastCar});
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteCarSql(Guid carId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DeleteCar, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = carId});
                sqlCommand.ExecuteNonQuery();
            }
        }
        
    }

}
