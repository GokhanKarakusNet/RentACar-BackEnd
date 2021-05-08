using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,RentACarContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(int id)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == id
                    select new OperationClaim
                    {
                        Id = operationClaim.Id,
                        Name = operationClaim.Name
                    };
                return result.ToList();
            }
        }

        public UserForDetail GetForUserDetailById(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new RentACarContext())
            {
                var result = from user in filter == null ? context.Users : context.Users.Where(filter)
                    select new UserForDetail
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                return result.FirstOrDefault();
            }
        }
    }
}
