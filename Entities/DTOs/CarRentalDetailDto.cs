using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarRentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int CustomerId { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
