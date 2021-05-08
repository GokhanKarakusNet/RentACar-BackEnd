using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car:IEntity
    {

        public Car()
        {
            CarImages = new List<CarImage>();
        }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public short MinFindeksValue { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
