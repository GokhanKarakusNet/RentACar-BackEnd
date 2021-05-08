using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Models
{
    public class ImageForUpload
    {
        public List<IFormFile> UploadedImage { get; set; }
    }
}
