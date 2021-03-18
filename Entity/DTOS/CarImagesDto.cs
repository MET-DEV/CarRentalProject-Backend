using Microsoft.AspNetCore.Http;
using MyCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
    public class CarImagesDto : IDto
    {
        
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
