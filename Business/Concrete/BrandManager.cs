﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }


        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(BrandValidator))]
        public IDataResult<Brand> AddBrand(BrandAndImageDto brandAndImageDto)
        {
            Brand brand = new Brand();
            brand.BrandName = brandAndImageDto.BrandName;
            _brandDal.Add(brand);
            return new SuccessDataResult<Brand>(brand);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            if(DateTime.Now.Hour == 21)
            {
                return new ErrorResult(Messages.NotDeleted);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<BrandDetailDto>> GetBrandDetails()
        {
            var result = _brandDal.GetBrandsDetails();
            return new SuccessDataResult<List<BrandDetailDto>>(result);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.NotUpdated);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
