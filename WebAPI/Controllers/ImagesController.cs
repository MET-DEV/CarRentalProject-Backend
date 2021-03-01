using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public ImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var context = _carImageService.GetAll();
            if (!context.Success)
            {
                return BadRequest(context);
            }
            return Ok(context);
            
        }
        
        [HttpPost("add")]
        public IActionResult Add([FromForm] ImagesUploadDetail imagesUpload)
        {
            try
            {
                CarImage carImage = new CarImage();
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                carImage.ImagePath =path;
                carImage.Date = DateTime.Now;
                carImage.CarId = imagesUpload.CarId;
                _carImageService.Add(carImage);
               
                if (imagesUpload.Files.Length > 0)
                {
                    
                    
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    
                    var fileExtension = Path.GetExtension(imagesUpload.Files.FileName);
                    using (FileStream fileStream = System.IO.File.Create(path + Guid.NewGuid().ToString("D") + fileExtension))
                    {
                       

                        imagesUpload.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        

                        return Ok("Success");


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var context = _carImageService.Delete(carImage);
            if (context.Success)
            {
                return Ok(context);
            }
            return BadRequest(context);
        }
    }
}
