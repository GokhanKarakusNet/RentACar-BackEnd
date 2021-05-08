using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarDetailDto :CarDetailDtoWithoutImage,IDto
    {
        public CarImage MainImage { get; set; }
    }
}
