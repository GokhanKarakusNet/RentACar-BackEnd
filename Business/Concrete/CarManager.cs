using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddedSuccessfully);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeletedSuccessfully);
        }

        [CacheAspect] // key = Business.Concrete.CarManager.GetAll
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllCarsListedSuccessfully);
        }
        
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            var carDetailDtoList = _carDal.GetCarsDetails();
            return new SuccessDataResult<List<CarDetailDto>>(MainImageAssignerForCarDetailDtos(carDetailDtoList), Messages.GetCarDetailDtoSuccessfully);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId)
        {
            var carDetailDtoListByBrandId = _carDal.GetCarsDetails(c => c.BrandId == brandId);
            return new SuccessDataResult<List<CarDetailDto>>(MainImageAssignerForCarDetailDtos(carDetailDtoListByBrandId),
                Messages.GetCarDetailsByBrandIdSuccessfully);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            var carDetailDtoListByColorId = _carDal.GetCarsDetails(c => c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(MainImageAssignerForCarDetailDtos(carDetailDtoListByColorId)
                , Messages.GetCarDetailsByColorIdSuccessfully);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            var carDetailDtoListByBrandIdAndColorId = _carDal.GetCarsDetails(c =>
                c.BrandId == brandId && c.ColorId == colorId);
            return new SuccessDataResult<List<CarDetailDto>>(MainImageAssignerForCarDetailDtos(carDetailDtoListByBrandIdAndColorId));
        }

        public IDataResult<CarDetailDtoWithoutImage> GetCarDetailsByCarId(int carId)
        {

            return new SuccessDataResult<CarDetailDtoWithoutImage>(_carDal.GetCarsDetails(c => c.CarId == carId).Single(), Messages.GetCarDetailDtoSuccessfully);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.GetCarsByBrandIdSuccessfully);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.GetCarsByColorIdSuccessfully);
        }

        
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdatedSuccessfully);
        }

        
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarUpdatedSuccessfully);
        }
        

        
        private List<CarDetailDto> MainImageAssignerForCarDetailDtos(List<CarDetailDto> dtoListToCheck)
        {
            var carDetailDtoList = new List<CarDetailDto>();

            foreach (var carDetailDto in dtoListToCheck)
            {
                var mainImage = _carImageService.GetCarMainImageByCarId(carDetailDto.CarId);

                CarDetailDto carDetail = new CarDetailDto
                {
                    CarId = carDetailDto.CarId,
                    BrandId = carDetailDto.BrandId,
                    ColorId = carDetailDto.ColorId,
                    CarName = carDetailDto.CarName,
                    BrandName = carDetailDto.BrandName,
                    ColorName = carDetailDto.ColorName,
                    DailyPrice = carDetailDto.DailyPrice,
                    Description = carDetailDto.Description,
                    ModelYear = carDetailDto.ModelYear,
                    MinFindeksValue = carDetailDto.MinFindeksValue,
                    MainImage = mainImage.Data
                };
                carDetailDtoList.Add(carDetail);
            }

            return carDetailDtoList;
        }

    }
}
