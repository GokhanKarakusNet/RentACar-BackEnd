using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1,BrandId = 1,ColorId = 1,DailyPrice = 100,Description = "Opel Corsa",ModelYear = 2019},
                new Car{CarId = 2,BrandId = 1,ColorId = 1,DailyPrice = 150,Description = "Peugout 3008",ModelYear = 2021},
                new Car{CarId = 3,BrandId = 2,ColorId = 2,DailyPrice = 200,Description = "Golf",ModelYear = 2021},
                new Car{CarId = 4,BrandId = 2,ColorId = 3,DailyPrice = 60,Description = "Hyundai",ModelYear = 2010}
            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
    }
}
