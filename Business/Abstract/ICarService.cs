using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IResult TransactionalOperation(Car car);
        IDataResult<CarDetailDto> GetCarDetails(int carId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailByBrandAndColor(int brandId, int colorId);
    }
}
