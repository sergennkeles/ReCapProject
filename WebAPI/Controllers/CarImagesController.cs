using Business.Abstract;
using Core.Utilities.FileManagaments;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
           
            _carImageService = carImageService;
        }

        [HttpGet]
        public IActionResult GetAllById(int carId)
        {
            var result = _carImageService.GetAll(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(IFormFile imageFile, int carId)
        {

            if (!FileManagament.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }
            string newImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.Add(new CarImage { CarId = carId, ImagePath = newImageName });
            if (result.Success)
            {
                FileManagament.AddImageFile(imageFile, @"wwwroot\uploads", newImageName);
                return Ok(result);
            }
            return BadRequest(result);
    
        }


        [HttpPut("update")]
        public IActionResult Update(IFormFile imageFile, int carId, int carImageId)
        {

            if (!FileManagament.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }
            else
            {
                var image = _carImageService.GetAll(carId).Data.Where(x => x.Id == carImageId).FirstOrDefault();
                string fileName = image.ImagePath;
  
                
                
                var result = _carImageService.Update(new CarImage
                {
                    Id = carImageId,
                    CarId = carId,
                    ImagePath = fileName
                });
                if (result.Success)
                {
                    FileManagament.AddImageFile(imageFile, @"wwwroot\uploads", fileName);
                   System.IO.File.Delete(fileName);
                    return Ok(result);
                }
                return BadRequest(result);

            }
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int carImageId)
        {
            var result = _carImageService.GetById(carImageId);
            if (result.Success)
            {
                FileManagament.DeleteImageFile(@"wwwroot\uploads\", result.Data.ImagePath);
                var deleteImage = _carImageService.Delete(new CarImage { Id = carImageId });
                if (deleteImage.Success)
                {
                    return Ok(deleteImage);
                }
            }
            return BadRequest(result);
        }
    }
}
