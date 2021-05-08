using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        //[HttpPost("add")]
        //public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        //{
        //    var result = _carImageService.Add(carImage, file);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}



        //[HttpPost("update")]
        //public IActionResult Update([FromBody] CarImage carImage, IFormFile file)
        //{
        //    var result = _carImageService.Update(carImage, file);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        //[HttpPost("delete")]
        //public IActionResult Delete([FromBody] CarImage carImage)
        //{
        //    var result = _carImageService.Delete(carImage);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        ////[HttpGet("getcarmainimagebycarid")]
        ////public IActionResult GetCarMainImageByCarId(int carId)
        ////{
        ////    var result = _carImageService.GetCarMainImageByCarId(carId);
        ////    if (result.Success)
        ////    {
        ////        return Ok(result);
        ////    }

        ////    return BadRequest(result);
        ////}

        [HttpGet("getimagebyid")]
        public IActionResult GetImageById(int id)
        {
            var result = _carImageService.GetImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagelistbycarid")]
        public IActionResult GetImageListByCarId(int carId)
        {
            var result = _carImageService.GetImageListByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
