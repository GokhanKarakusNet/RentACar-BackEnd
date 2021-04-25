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
        public List<CarDetailDto> GetCarsDetails(Expression<Func<IDto, bool>> filter = null)
        {
            List<CarDetailDto> detailedCar = new List<CarDetailDto>();
            var cars = GetAll();
            using (RentACarContext context = new RentACarContext())
            {
                foreach (var car in cars)
                {
                    var result = from i in context.CarImages
                                 join b in context.Brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.Colors
                                 on car.ColorId equals c.ColorId
                                 where car.CarId == i.CarId
                                 select new CarImage
                                 {
                                     CarId = car.CarId,
                                     Date = i.Date,
                                     CarImageId = i.CarImageId,
                                     ImagePath = i.ImagePath
                                 };
                    detailedCar.Add(new CarDetailDto()
                    {
                        BrandName = car.BrandName,
                        ColorName = car.ColorName,
                        CarName = car.CarName,
                        BrandId = car.BrandId,
                        ColorId = car.ColorId,
                        DailyPrice = car.DailyPrice,
                        CarImages = result.ToList(),
                        CarId = car.CarId,
                        Description = car.Description,
                        ModelYear = car.ModelYear
                    });
                }
                return detailedCar;
            }
        }


        public CarDetailDto GetWithDetails(int id)
        {
            CarDetailDto detailedCar;
            var car = GetCarDetails(id);
            using (RentACarContext context = new RentACarContext())
            {
                var result = from i in context.CarImages
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             where car.CarId == i.CarId
                             select new CarImage
                             {
                                 CarId = car.CarId,
                                 Date = i.Date,
                                 CarImageId = i.CarImageId,
                                 ImagePath = i.ImagePath
                             };
                detailedCar = new CarDetailDto()
                {
                    BrandName = car.BrandName,
                    ColorName = car.ColorName,
                    CarName = car.CarName,
                    BrandId = car.BrandId,
                    ColorId = car.ColorId,
                    DailyPrice = car.DailyPrice,
                    CarImages = result.ToList(),
                    CarId = car.CarId,
                    Description = car.Description,
                    ModelYear = car.ModelYear
                };

                return detailedCar;
            }
        }

        private List<CarDetailDto> GetAll()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join clr in context.Colors
                             on c.ColorId equals clr.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetails(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             where c.CarId == id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId into gj
                             from subpet in gj.DefaultIfEmpty()
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId into gj2
                             from subpet2 in gj2.DefaultIfEmpty()
                             where c.CarId == id
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandId = c.BrandId,
                                 BrandName = subpet.BrandName,
                                 ColorId = c.ColorId,
                                 ColorName = subpet2.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> DetailManager(List<CarDetailDto> list)
        {
            List<CarDetailDto> detailedCar = new List<CarDetailDto>();
            using (RentACarContext context = new RentACarContext())
            {
                foreach (var car in list)
                {
                    var result = from i in context.CarImages
                                 join b in context.Brands
                                 on car.BrandId equals b.BrandId
                                 join c in context.Colors
                                 on car.ColorId equals c.ColorId
                                 where car.CarId == i.CarId
                                 select new CarImage
                                 {
                                     CarId = car.CarId,
                                     Date = i.Date,
                                     CarImageId = i.CarImageId,
                                     ImagePath = i.ImagePath
                                 };
                    detailedCar.Add(new CarDetailDto()
                    {
                        BrandName = car.BrandName,
                        ColorName = car.ColorName,
                        CarName = car.CarName,
                        BrandId = car.BrandId,
                        ColorId = car.ColorId,
                        DailyPrice = car.DailyPrice,
                        CarImages = result.ToList(),
                        CarId = car.CarId,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                    });
                }
                return detailedCar;
            }
        }
        public List<CarDetailDto> GetCarsByBrandAndColor (Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in filter == null
                        ? context.Cars
                        : context.Cars.Where(filter)
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

