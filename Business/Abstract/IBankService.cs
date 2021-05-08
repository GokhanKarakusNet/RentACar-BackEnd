using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBankService
    {
        IDataResult<Bank> Add(BankDto bankDto);
        IDataResult<List<Bank>> GetAll();
    }
}
