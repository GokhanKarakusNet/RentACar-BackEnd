using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(int id);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<UserForDetail> GetForUserDetailById(int id);
        IResult UpdateUserInfo(User user);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
