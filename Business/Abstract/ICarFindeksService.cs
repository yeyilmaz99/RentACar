using System;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ICarFindeksService
	{
        IDataResult<List<CarFindeks>> GetAll();
        IDataResult<CarFindeks> GetById(int id);
        IResult Add(CarFindeks carFindeks);
        IResult Update(CarFindeks carFindeks);
        IResult Delete(CarFindeks carFindeks);
    }
}

