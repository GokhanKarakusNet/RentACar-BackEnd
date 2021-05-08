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
        IResult CheckRentability(Rental rental);
        IDataResult<List<CarRentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> Add(Rental rental,string nationalId);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult CheckIfFindeksScoreEnough(string nationalId, int carId);
    }
}
