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
using Core.Utilities.Business;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly IFindeksService _findexService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findexService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findexService = findexService;
        }

    

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

       // [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IDataResult<Rental> Add(Rental rental,string nationalId)
        {
            var result = BusinessRules.Run(CheckRentability(rental), CheckIfFindeksScoreEnough(nationalId, rental.CarId));
            if (result != null)
            {
                return new ErrorDataResult<Rental>(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(rental,Messages.RentalAddedSuccessfully);
        }

        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckRentability(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdatedSuccessfully);
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeletedSuccessfully);
        }

        public IResult CheckIfFindeksScoreEnough(string nationalId,int carId)
        {
            var selectedCar = _carService.GetById(carId).Data;
            var targetfindeks = _findexService.GetFindeksByNationalId(nationalId).Data;
            if (targetfindeks == null)
            {
                return new ErrorResult(Messages.UserHasNoFindex);
            }

            if (targetfindeks.FindeksValue < selectedCar.MinFindeksValue)
            {
                return new ErrorResult(Messages.NotEnoughFindeks);
            }

            return new SuccessResult(Messages.FindexIsEnough);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetAllRentalsSuccessfully);
        }
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.GetRentalByIdSuccessfully);
        }

        public IResult CheckRentability(Rental rental)
        {
            var rentals = _rentalDal.GetRentalDetails(r => r.CarId == rental.CarId);

            if (rentals.Any(r => r.ReturnDate >= rental.RentDate && r.RentDate <= rental.ReturnDate))
            {
                return new ErrorResult(Messages.RentalDateError);
            }
            return new SuccessResult(Messages.CarIsRentable);
        }

      
    }
}
