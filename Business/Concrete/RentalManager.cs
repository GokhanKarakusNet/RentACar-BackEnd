using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result,Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(r => r.RentalId == rentalId);
            return new SuccessDataResult<Rental>(result);
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails());
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && !r.ReturnDate.HasValue);
            if (!result.Any())
            {
                rental.RentDate = DateTime.Now;
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            return new ErrorResult(Messages.RentalNotComeBack);

        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(int rentalId)
        {
            _rentalDal.Delete(new Rental { RentalId = rentalId });
            return new SuccessResult(Messages.RentalDeleted);
        }
    }
}
