using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate);
        }
    }
}