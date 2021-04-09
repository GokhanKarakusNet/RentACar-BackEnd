using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

    }
}
