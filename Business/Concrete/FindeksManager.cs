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
            throw new NotImplementedException();
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Findeks> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Findeks findeks)
        {
            throw new NotImplementedException();
        }
    }
}

