﻿using System;
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

        public IResult CheckIfFPSufficient(int carFP, IDataResult<Findeks> findeks)
        {

            var userFP = 0;

            if(findeks.Data is not null)
            {
                userFP = findeks.Data.FindeksPoint;
            }


                if (userFP >= carFP)
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
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.UserId == userId), Messages.Listed);
        }

        public IResult Update(Findeks findeks)
        {
            var findeks1 = _findeksDal.Get(f => f.UserId == findeks.UserId);
            findeks1.FindeksPoint = findeks.FindeksPoint;
            _findeksDal.Update(findeks1);
            return new SuccessResult(Messages.Updated);
        }


        public IResult checkIfAlreadyExist(int userId)
        {
            var result = _findeksDal.Get(f => f.UserId == userId);

            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();   
        }

    }
}

