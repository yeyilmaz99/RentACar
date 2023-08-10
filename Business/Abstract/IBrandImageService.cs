using System;
using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IBrandImageService
	{
        IResult Add(BrandImage brandImage);
        IDataResult<BrandImage> GetBrandImageById(int carId);
    }
}

