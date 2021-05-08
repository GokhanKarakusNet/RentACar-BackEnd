using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<List<Findeks>> GetAll();
        IDataResult<Findeks> GetById(int id);
        IDataResult<Findeks> GetFindeksByUserId(int userId);
        IDataResult<Findeks> Add(Findeks findeks);
        IDataResult<Findeks> GetFindeksByNationalId(string nationalId);
    }
}
