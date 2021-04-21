using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<CarRentalDetailDto>> GetRentalDetails();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(int rentalId);
        
    }
}
