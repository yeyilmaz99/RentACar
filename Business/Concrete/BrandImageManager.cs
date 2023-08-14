using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandImageManager : IBrandImageService
    {

        IBrandImageDal _brandImageDal;

        public BrandImageManager(IBrandImageDal brandImageDal)
        {
            _brandImageDal = brandImageDal;
        }

        public IResult Add(BrandImage brandImage)
        {
            var result = _brandImageDal.Get(img => img.BrandId == brandImage.BrandId);
            if(result != null)
            {
                return new ErrorResult(Messages.NumberOfImagesExceeded);
            }
            _brandImageDal.Add(brandImage);
            return new SuccessResult(); 
        }

        public IDataResult<BrandImage> GetBrandImageById(int brandId)
        {
            var result = _brandImageDal.Get(img => img.BrandId == brandId);
            return new SuccessDataResult<BrandImage>(result);
        }
    }
}

