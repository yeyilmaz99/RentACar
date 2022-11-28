using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
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
            throw new NotImplementedException();
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

