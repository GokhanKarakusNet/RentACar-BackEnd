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
       public List<CarRentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = 
                    from rental in filter is null 
                        ? context.Rentals 
                        : context.Rentals.Where(filter)
                    join car in context.Cars
                        on rental.CarId equals car.CarId
                    join brand in context.Brands 
                        on car.BrandId equals brand.BrandId 
                    join cus in context.Customers
                        on rental.CustomerId equals cus.CustomerId
                    join us in context.Users
                        on cus.UserId equals us.Id
                    select new CarRentalDetailDto
                    {
                        Id = rental.RentalId,
                        CarId = car.CarId,
                        CustomerId = cus.CustomerId,
                        BrandId = brand.BrandId,
                        CarName = car.CarName,
                        BrandName = brand.BrandName,
                        CompanyName = cus.CompanyName,
                        CustomerFullName = $"{us.FirstName} {us.LastName}",
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        
                    };
                return result.ToList();
            }
        }
    }
}
