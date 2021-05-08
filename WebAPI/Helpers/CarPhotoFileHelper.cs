using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Helpers
{
    public class CarPhotoFileHelper /*: ICarPhotoFileHelper*/
    {
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly ICarService _carService;
        private ICarImageService _carImageService;
       // private int sayac = 0;
        //private string imagePath = _webHostEnvironment.WebRootPath + @"\CarImages\";
        //private string fileFolderPath = AppDomain.CurrentDomain + @"\CarImages\";
        public CarPhotoFileHelper(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService, ICarService carService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
            _carService = carService;
        }

        //public string AddImage(ImageForUpload imagesForUpload, int carId)
        //{
        //    var imagePath = _webHostEnvironment.WebRootPath + @"\CarImages\";
        //    //var imageCountByCar = _carImageService.GetListByCarId(carId).Data.Count;

        //    if (!Directory.Exists(imagePath))
        //    {
        //        Directory.CreateDirectory(imagePath);
        //    }


        //    for (int i = 0; i < imagesForUpload.UploadedImage.Count; i++)
        //    {
        //        if (ImageCounter(carId) >= 5)
        //        {
        //            if (sayac!=0)
        //            {
        //                return $"{sayac} adet araç sisteme yüklenerek bir araç için izin verilen maksimum fotoğraf sayısına ulaşıldı";
        //            }
        //            return "Bir araç için izin verilen maksimum fotoğraf sayısına ulaşıldı.";
        //        }
        //        if (ImageCounter(carId) < 5)
        //        {
        //            var guIdName = Guid.NewGuid().ToString("N") + "_" + carId + "_" + DateTime.Now.Second;
        //            var fileExtension = new System.IO.FileInfo(imagesForUpload.UploadedImage[i].FileName).Extension;

        //            using (FileStream fileStream = System.IO.File.Create(imagePath + guIdName + fileExtension))
        //            {
        //                imagesForUpload.UploadedImage[i].CopyTo(fileStream);
        //                fileStream.Flush();
        //                var carImageForDb = new CarImage
        //                { CarId = carId, ImagePath = guIdName + fileExtension, Date = DateTime.Now };
        //                //_carImageService.Add(carImageForDb);
        //            }

        //            sayac += 1;

        //        }

        //    }
        //    return $"{sayac} adet araç sisteme yüklendi.";

        //}

        //public IDataResult<List<CarDetailDto>> GetCarListWithSingleImage()
        //{
        //    var result = _carService.GetCarDetails();
        //    var resultList = new List<CarDetailDto>();
        //    var realSingleImage = _carImageService.GetImageForCarList().Data;


        //    foreach (var carDetailDto in result.Data)
        //    {

        //        if (realSingleImage.Find(i=>i.CarId==carDetailDto.CarId)!=null)
        //        {

        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage
        //                {
        //                    CarId = carDetailDto.CarId,
        //                    Date = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Date,
        //                    Id = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Id,
        //                    ImagePath = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).ImagePath
        //                }
        //            };

        //            resultList.Add(newDto);
        //        }
        //        else
        //        {
        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage { ImagePath = "CarRentalDefault.jpg" }
        //            };

        //            resultList.Add(newDto);
        //        }


        //    }
        //    result.Data.Clear();
        //    result.Data.AddRange(resultList);
        //    return result;
        //}


        //public IDataResult<List<CarDetailDto>> GetCarListByBrandIdWithSingleImage(int brandId)
        //{
        //    var result = _carService.GetCarDetailsByBrandId(brandId);
        //    var resultList = new List<CarDetailDto>();
        //    var realSingleImage = _carImageService.GetImageForCarList().Data;


        //    foreach (var carDetailDto in result.Data)
        //    {

        //        if (realSingleImage.Find(i=>i.CarId==carDetailDto.CarId)!=null)
        //        {

        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage
        //                {
        //                    CarId = carDetailDto.CarId,
        //                    Date = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Date,
        //                    Id = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Id,
        //                    ImagePath = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).ImagePath
        //                }
        //            };

        //            resultList.Add(newDto);
        //        }
        //        else
        //        {
        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage { ImagePath = "CarRentalDefault.jpg" }
        //            };

        //            resultList.Add(newDto);
        //        }


        //    }
        //    result.Data.Clear();
        //    result.Data.AddRange(resultList);
        //    return result;
        //}


        //public IDataResult<List<CarDetailDto>> GetCarListByColorIdWithSingleImage(int colorId)
        //{
        //    var result = _carService.GetCarDetailsByColorId(colorId);
        //    var resultList = new List<CarDetailDto>();
        //    var realSingleImage = _carImageService.GetImageForCarList().Data;


        //    foreach (var carDetailDto in result.Data)
        //    {

        //        if (realSingleImage.Find(i=>i.CarId==carDetailDto.CarId)!=null)
        //        {

        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage
        //                {
        //                    CarId = carDetailDto.CarId,
        //                    Date = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Date,
        //                    Id = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).Id,
        //                    ImagePath = realSingleImage.Find(i=>i.CarId==carDetailDto.CarId).ImagePath
        //                }
        //            };

        //            resultList.Add(newDto);
        //        }
        //        else
        //        {
        //            CarDetailDto newDto = new CarDetailDto
        //            {
        //                CarId = carDetailDto.CarId,
        //                BrandName = carDetailDto.BrandName,
        //                CarName = carDetailDto.CarName,
        //                DailyPrice = carDetailDto.DailyPrice,
        //                ColorName = carDetailDto.ColorName,
        //                Description = carDetailDto.Description,
        //                ImageForCarList = new CarImage { ImagePath = "CarRentalDefault.jpg" }
        //            };

        //            resultList.Add(newDto);
        //        }


        //    }
        //    result.Data.Clear();
        //    result.Data.AddRange(resultList);
        //    return result;
        //}

        //private int ImageCounter(int carId)
        //{
        //    //var imageCountByCar = _carImageService.GetListByCarId(carId).Data.Count;
        //    //return imageCountByCar;
        //}

    }
}