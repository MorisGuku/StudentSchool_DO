using DbModel;
using Microsoft.Data.SqlClient;
//using ConsoleHelperLib;
using hw_2;
using Microsoft.EntityFrameworkCore.Query;
using Provider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2
{
    public class UserRepository
    {
        private readonly OfficeDB _dbContext = new();

        private const string ConnectionString = @"Server=localhost,10001;Database=hw_3;Trusted_Connection=True;Integrated Security=False;Encrypt=False;User=sa;Password=12345Qq!;TrustServerCertificate=true";
        private const string GetUsersSQL = @"SELECT * FROM Users";
        private const string GetUserSQL = @"SELECT * FROM Users WHERE Id = '{0}'";
        private const string GetLastUserSQL = @"SELECT * FROM Users WHERE Id = '{0}' ORDER BY ID";


        public List<DbUser> GetUsersEF()
        {
            return _dbContext.Users.ToList();
        }

        public DbUser GetUserEF(Guid userId)
        {
            return _dbContext.Users.Where(u => u.UserId == userId).FirstOrDefault();
        }

        public void CreateUser(DbUser user)
        {
            _dbContext.Add(user);

            _dbContext.SaveChanges();
        }

        public void EditUser(Guid userId, string firstName, string lastName, Guid? keyCar)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if(!string.IsNullOrEmpty(firstName))
            {
                user.FirstName = firstName;
            }

            if(!string.IsNullOrEmpty(lastName))
            {
                user.LastName = lastName;
            }

            if(keyCar.HasValue)
            {
                var carRepository = new CarRepository();
                var carData = carRepository.GetCarEF((Guid)keyCar);
                user.CarId = carData.Id;
            }

            user.CreatedTime = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);

            _dbContext.Remove(user);

            _dbContext.SaveChanges();
        }

    }

}
