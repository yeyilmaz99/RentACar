using System;
namespace Entities.DTOs
{
	public class BrandDetailDto
	{
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public byte[] ImageData { get; set; }
    }
}

