using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    select new CarDetailDto
                    {
                        CarId = car.CarId,
                        BrandId = brand.BrandId,
                        ColorId = color.ColorId,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        Description = car.Description,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        MinFindeksValue = car.MinFindeksValue
                    };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}

