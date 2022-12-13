using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarDetailDto
    {
        public int CarId { get; set; }  
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public int FindeksPoint { get; set; }       
    }
}
