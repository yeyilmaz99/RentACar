using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface ICarDetailImageService
	{
        IDataResult<List<CarDetailImage>> GetAllImagesByCarId(int carId);
        IResult Add(CarDetailImage[] carDetailImages);
        IResult Update(List<byte[]> carImages);
        IResult Delete(List<byte[]> carImages);
    }
}

