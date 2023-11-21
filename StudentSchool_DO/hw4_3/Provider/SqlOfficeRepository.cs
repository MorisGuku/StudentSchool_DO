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
    public class SqlOfficeRepository
    {
        private const string ConnectionString = @"Server=localhost,1433;Database=hw_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq@;TrustServerCertificate=true";
        private const string GetSalesOfficeSQL = @"SELECT * FROM SalesOffices";
        private const string CreateSalesOffice = @"INSERT INTO SalesOffices (Id, NameSalesOffice, AddressSalesOffice) VALUES (NEWID(), @NameSalesOffice, @AddressSalesOffice)";
        private const string EditSalesOffice = @"UPDATE SalesOffices SET NameSalesOffice = @NameSalesOffice, AddressSalesOffice = @AddressSalesOffice WHERE Id = @GUID";
        private const string DeleteSalesOffice = @"DELETE FROM SalesOffices WHERE Id = @GUID";
        public static void GetSalesOfficeSql()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var sqlCommand = new SqlCommand(GetSalesOfficeSQL, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        string columnName1 = reader.GetName(0);
                        string columnName2 = reader.GetName(1);
                        string columnName3 = reader.GetName(2);
                        Console.WriteLine($"{columnName1} \t{columnName2} \t{columnName3}");

                        while (reader.Read())
                        {
                            Guid id = reader.GetGuid(0);
                            string nameSalesOffice = reader.GetString(1);
                            string addressSalesOffice = reader.GetString(2);
                            Console.WriteLine($"{id} \t{nameSalesOffice} \t{addressSalesOffice}");
                        }
                    }
                }
            }
        }
        public static void CreateSalesOfficeSql(string nameSalesOffice, string addressSalesOffice)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(CreateSalesOffice, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@NameSalesOffice", SqlDbType.NVarChar, -1) { Value = nameSalesOffice});
                sqlCommand.Parameters.Add(new SqlParameter("@AddressSalesOffice", SqlDbType.NVarChar, -1) { Value = addressSalesOffice});
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void EditSalesOfficeSql(Guid salesOfficeId, string nameSalesOffice, string addressSalesOffice)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(EditSalesOffice, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@NameSalesOffice", SqlDbType.NVarChar, -1) { Value = nameSalesOffice});
                sqlCommand.Parameters.Add(new SqlParameter("@AddressSalesOffice", SqlDbType.NVarChar, -1) { Value = addressSalesOffice});
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = salesOfficeId});
                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteSalesOfficeSql(Guid salesOfficeId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DeleteSalesOffice, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@GUID", SqlDbType.UniqueIdentifier) { Value = salesOfficeId});
                sqlCommand.ExecuteNonQuery();
            }
        }
        
    }

}
