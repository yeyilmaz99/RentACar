using System;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
	public class BrandAndImageDto
	{
        public string BrandName { get; set; }
        public IFormFile ImageData { get; set; }
    }
}

