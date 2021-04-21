using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from cus in filter is null ? context.Customers : context.Customers.Where(filter)
                    join usr in context.Users on cus.UserId equals usr.Id
                    select new CustomerDetailDto
                    {
                        CustomerId = cus.CustomerId,
                        UserId = usr.Id,
                        FirstName = usr.FirstName,
                        LastName = usr.LastName,
                        CompanyName = cus.CompanyName,
                        EMail = usr.Email
                    };
                return result.ToList();
            }
        }
    }
}
