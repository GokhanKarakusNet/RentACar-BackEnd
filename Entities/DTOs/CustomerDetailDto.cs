using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerFullName { get; set; }
        public string EMail { get; set; }
        public string CompanyName { get; set; }
        public short FindeksScore { get; set; }

    }
}