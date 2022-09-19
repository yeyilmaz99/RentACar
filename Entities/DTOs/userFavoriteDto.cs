using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserFavoriteDto
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string UserName { get; set; }    
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
