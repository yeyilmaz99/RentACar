﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter);
        List<CarDetailDto> GetCarsByBrandIdAndColorId(int colorId, int brandId);
    }
}
