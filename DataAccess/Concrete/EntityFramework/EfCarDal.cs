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
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from brand in context.Brands
                             join car in context.Cars on brand.BrandId equals car.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.ColorName,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();
            }
        }

    
    }
}
