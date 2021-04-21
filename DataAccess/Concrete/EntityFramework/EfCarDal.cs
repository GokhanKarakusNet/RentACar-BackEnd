using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in filter==null
                ? context.Cars
                :context.Cars.Where(filter)
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description
                             };
                return result.ToList();
            }
        }

        
    }
}
