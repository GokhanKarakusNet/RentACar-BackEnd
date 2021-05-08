using WebAPI.Models;

namespace WebAPI.Helpers
{
    public interface ICarPhotoFileHelper
    {
        public string AddImage(ImageForUpload imageForUploads, int carId);
        //public IDataResult<List<CarDetailDto>> GetCarListWithSingleImage();
        //public IDataResult<List<CarDetailDto>> GetCarListByBrandIdWithSingleImage(int brandId);
        //public IDataResult<List<CarDetailDto>> GetCarListByColorIdWithSingleImage(int colorId);

    }
}