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

namespace hw_2
{
    public class OfficeRepository
    {
        private readonly OfficeDB _dbContext = new();
        public List<DbSalesOffice> GetSalesOfficeEF()
        {
            return _dbContext.SalesOffices.ToList();
        }

        public DbSalesOffice GetSaleOfficeEF(Guid salesOfficeId)
        {
            return _dbContext.SalesOffices.Where(u => u.Id == salesOfficeId).FirstOrDefault();
        }

        public void CreateSalesOffice(DbSalesOffice salesOffice)
        {
            _dbContext.Add(salesOffice);

            _dbContext.SaveChanges();
        }

        public void EditSalesOffice(Guid salesOfficeId, string nameSalesOffice, string addressSalesOffice, Guid? keyCar)
        {
            var salesOffice = _dbContext.SalesOffices.FirstOrDefault(s => s.Id == salesOfficeId);
            if(!string.IsNullOrEmpty(nameSalesOffice))
            {
                salesOffice.NameSalesOffice = nameSalesOffice;
            }

            if(!string.IsNullOrEmpty(addressSalesOffice))
            {
                salesOffice.AddressSalesOffice = addressSalesOffice;
            }
            
            if(keyCar.HasValue)
            {
                var carRepository = new CarRepository();
                var carData = carRepository.GetCarEF((Guid)keyCar);
                salesOffice.Cars.Add(carData);
            }

            _dbContext.SaveChanges();
        }

        public void DeleteSalesOffice(Guid salesOfficeId)
        {
            var salesOffice = _dbContext.SalesOffices.FirstOrDefault(s => s.Id == salesOfficeId);

            _dbContext.Remove(salesOffice);

            _dbContext.SaveChanges();
        }
        
    }

}
