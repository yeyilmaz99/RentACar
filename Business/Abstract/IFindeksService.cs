﻿using System;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
	public interface IFindeksService
	{
        IDataResult<List<Findeks>> GetAll();
        IDataResult<Findeks> GetById(int userId);
        IResult Add(Findeks findeks);
        IResult CheckIfFPSufficient(int carFP, IDataResult<Findeks> findeks);
        IResult checkIfAlreadyExist(int userId);
        IResult Update(Findeks findeks);
        IResult Delete(Findeks findeks);
    }
}

