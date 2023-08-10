using System;
using Core.Entities;

namespace Entities.Concrete
{
	public class BrandImage : IEntity
	{
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int BrandId { get; set; }
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

