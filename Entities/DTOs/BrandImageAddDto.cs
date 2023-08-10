using System;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
	public class BrandImageAddDto
	{
        public int BranId { get; set; }
        public IFormFile Image { get; set; }
    }
}

