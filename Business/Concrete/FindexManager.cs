using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FindexManager : IFindeksService
    {
        private readonly IFindeksDal _findeksDal;

        public FindexManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<Findeks> GetById(int id)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(c => c.Id == id));
        }

        public IDataResult<Findeks> GetFindeksByUserId(int userId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(c => c.UserId == userId));
        }

        public IDataResult<Findeks> Add(Findeks findeks)
        {
            var nationalToCheck = GetFindeksByNationalId(findeks.NationalIdentity);
            if (nationalToCheck.Data == null)
            {
                Random value = new Random();
                findeks.FindeksValue = (short)value.Next(0, 1901);
                _findeksDal.Add(findeks);
                return new SuccessDataResult<Findeks>(findeks, Messages.FindexAdded);
                
            }
            return new ErrorDataResult<Findeks>(Messages.UserHasFindexAlreadyExist);

        }

        public IDataResult<Findeks> GetFindeksByNationalId(string nationalId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(c => c.NationalIdentity == nationalId));
        }
    }
}
