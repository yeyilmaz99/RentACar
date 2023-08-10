﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int id);
        IResult Add(Brand brand);
        IDataResult<Brand> AddBrand(BrandAndImageDto brandAndImageDto);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<BrandDetailDto>> GetBrandDetails();

    }
}
