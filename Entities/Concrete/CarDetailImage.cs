using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.Concrete
{
    public class CarDetailImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageName { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
    }
}

