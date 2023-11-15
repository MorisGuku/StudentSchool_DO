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

namespace hw_2
{
    public class CarRepository
    {
        private readonly OfficeDB _dbContext = new();
        public List<DbCar> GetCarsEF()
        {
            return _dbContext.Cars.ToList();
        }

        public DbCar GetCarEF(Guid carId)
        {
            return _dbContext.Cars.Where(c => c.Id == carId).FirstOrDefault();
        }

        public void CreateCar(DbCar car)
        {
            _dbContext.Add(car);

            _dbContext.SaveChanges();
        }

        public void EditCar(Guid carId, string brandCar, string modelCar, int? coastCar, Guid? keySalesOffice)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Id == carId);
            if(!string.IsNullOrEmpty(brandCar))
            {
                car.BrandCar = brandCar;
            }

            if(!string.IsNullOrEmpty(modelCar))
            {
                car.ModelCar = modelCar;
            }

            if(coastCar.HasValue)
            {
                car.CoastCar = (int)coastCar;
            }
            
            if(keySalesOffice.HasValue)
            {
                var officeRepository = new OfficeRepository();
                var officeData = officeRepository.GetSaleOfficeEF((Guid)keySalesOffice);
                car.SalesOffices.Add(officeData);
            }
            
            _dbContext.SaveChanges();
        }

        public void DeleteCar(Guid carId)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Id == carId);

            _dbContext.Remove(car);

            _dbContext.SaveChanges();
        }
        
    }

}
