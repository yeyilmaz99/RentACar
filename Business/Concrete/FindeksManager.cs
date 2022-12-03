using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult(Messages.Added);
        }

        public IResult CheckIfFPSufficient(int carFP, int userId)
        {
            var userFP = _findeksDal.Get(user => user.Id == userId).FindeksPoint;
            if(userFP >= carFP)
            {
                return new SuccessResult(Messages.FPIsSufficient);
            }
            else
            {
                return new ErrorResult(Messages.FPIsNotSufficient);
            }
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Findeks> GetById(int userId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.UserId == userId));
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.Updated);
        }

    }
}

