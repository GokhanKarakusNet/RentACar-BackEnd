using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal:EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                    join car in context.Cars on rental.CarId equals car.CarId
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                    join user in context.Users on customer.UserId equals user.Id
                             select new CarRentalDetailDto
                    {
                        RentalId = rental.RentalId,
                        CustomerFirstName = user.FirstName,
                        CustomerLastName = user.LastName,
                        CustomerCompanyName = customer.CompanyName,
                        CarName = car.Description,
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };

                return result.ToList();
            }
        }
    }
}
