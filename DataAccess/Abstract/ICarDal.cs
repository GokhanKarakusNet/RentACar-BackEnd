using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        CarDetailDto GetCarDetails(int id);
        CarDetailDto GetWithDetails(int id);
        List<CarDetailDto> GetCarsDetails(Expression<Func<IDto, bool>> filter = null);
        List<CarDetailDto> GetCarsByBrandAndColor(Expression<Func<Car, bool>> filter = null); 
    }
}
