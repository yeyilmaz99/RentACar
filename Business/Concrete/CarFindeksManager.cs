using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class CarFindeksManager : ICarFindeksService
	{
        ICarFindeksDal _carFindeksDal;

        public CarFindeksManager(ICarFindeksDal carFindeksDal)
        {
            _carFindeksDal = carFindeksDal;
        }

        public IResult Add(CarFindeks carFindeks)
        {
            _carFindeksDal.Add(carFindeks);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarFindeks carFindeks)
        {
            _carFindeksDal.Delete(carFindeks);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarFindeks>> GetAll()
        {
            return new SuccessDataResult<List<CarFindeks>>(_carFindeksDal.GetAll());
        }

        public IDataResult<CarFindeks> GetById(int id)
        {
            return new SuccessDataResult<CarFindeks>(_carFindeksDal.Get(c => c.CarId == id));
        }

        public IResult Update(CarFindeks carFindeks)
        {
            _carFindeksDal.Update(carFindeks);
            return new SuccessResult(Messages.Updated);
        }
    }
}

