using System;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
	public class CarAndImageDto
	{
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public int FindeksPoint { get; set; }
        public IFormFile ImageData { get; set; }
    }
}

