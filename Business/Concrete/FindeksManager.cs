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

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Findeks> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.Added);
        }
    }
}

