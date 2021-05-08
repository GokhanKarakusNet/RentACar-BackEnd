using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            FileHelperForLocalStorage.Add(file, CreateNewPath(file, out var pathForDb));
            carImage.ImagePath = pathForDb;
            carImage.Date = DateTime.Now;
            carImage.MainPhoto = MainPhotoOperations(carImage);
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.ImageAddedSuccessfully);
        }


        public IResult Delete(CarImage carImage)
        {
            FileHelperForLocalStorage.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeletedSuccessfully);
        }

        public IDataResult<CarImage> GetImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == id));
        }


        public IDataResult<List<CarImage>> GetImageListByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);
            if (result.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(IfCarHasNoPhotoGetDefaultPhotoInTheList());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }

        public IDataResult<CarImage> GetCarMainImageByCarId(int carId)
        {
            var result = _carImageDal.Get(i => i.CarId == carId && i.MainPhoto);
            if (result == null)
            {
                return new SuccessDataResult<CarImage>(IfCarHasNoPhotoGetDefaultPhotoSingleImage());
            }

            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var carImageForUpdate = _carImageDal.Get(i => i.CarImageId == carImage.CarImageId);
            carImage.CarId = carImageForUpdate.CarId;
            carImage.Date = DateTime.Now;
            FileHelperForLocalStorage.Update(carImageForUpdate.ImagePath, file, CreateNewPath(file, out var pathForDb));
            carImage.ImagePath = pathForDb;
            carImage.MainPhoto = MainPhotoOperations(carImage);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdatedSuccessfully);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.MaksimumImageLimitReached);
            }
            return new SuccessResult();
        }

        private string CreateNewPath(IFormFile file, out string pathForDb)
        {

            var fileInfo = new FileInfo(file.FileName);
            pathForDb = $@"{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}_{DateTime.Now.Millisecond}{fileInfo.Extension}";
            var createdPathForHdd = $@"{Environment.CurrentDirectory}\wwwroot\CarImages\" + pathForDb;

            return createdPathForHdd;
        }


        private bool MainPhotoOperations(CarImage carImage)
        {
            var mainPhotoIndex = _carImageDal.GetAll(i => i.CarId == carImage.CarId && i.MainPhoto);

            if (mainPhotoIndex.Count == 0)
            {
                return true;
            }
            if (carImage.MainPhoto && mainPhotoIndex.Count > 0)
            {
                mainPhotoIndex.Find(i => i.MainPhoto);
                foreach (var imageToFalse in mainPhotoIndex)
                {
                    imageToFalse.MainPhoto = false;
                    _carImageDal.Update(imageToFalse);
                }

                return true;
            }
            return false;
        }

        private List<CarImage> IfCarHasNoPhotoGetDefaultPhotoInTheList()
        {
            //var realpath = ImagePath = $@"{Environment.CurrentDirectory}\wwwroot\CarImages\CarRentalDefault.jpg"
            var defaultImageInImageList = new List<CarImage>();
            var carImage = new CarImage
            {
                ImagePath = "CarRentalDefault.jpg"
            };
            defaultImageInImageList.Add(carImage);
            return defaultImageInImageList;
        }

        private CarImage IfCarHasNoPhotoGetDefaultPhotoSingleImage()
        {
            //var realpath = ImagePath = $@"{Environment.CurrentDirectory}\wwwroot\CarImages\CarRentalDefault.jpg"
            var carImage = new CarImage
            {
                ImagePath = "CarRentalDefault.jpg"
            };

            return carImage;
        }


    }
}