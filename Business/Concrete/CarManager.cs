using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        //[SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);

        }
        public IDataResult<Car> AddCar(CarAndImageDto carAndImageDto)
        {
            Car car = new Car();

            car.BrandId = carAndImageDto.BrandId;
            car.CarName = carAndImageDto.CarName;
            car.ColorId = carAndImageDto.ColorId;
            car.DailyPrice = carAndImageDto.DailyPrice;
            car.Description = carAndImageDto.Description;
            car.FindeksPoint = carAndImageDto.FindeksPoint;
            car.ModelYear = carAndImageDto.ModelYear;
            car.Id = carAndImageDto.Id;
            //IDataResult result = BusinessRules.Run(CheckIfCarNameExist(car.CarName));

            //if (result != null)
            //{
            //    return result;
            //}
            _carDal.Add(car);

            return new SuccessDataResult<Car>(car);
        }



        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.NotDeleted);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsColorId(int id)
        {
            var result = _carDal.GetCarsDetails(c => c.ColorId == id);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdAndColorId(int colorId, int brandId)
        {
            var result = _carDal.GetCarsByBrandIdAndColorId(colorId, brandId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id)); 
        }

        public IDataResult<CarDetailDto> GetCarDetails(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetail(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id)
        {
            var result = _carDal.GetCarsDetails(c => c.BrandId == id);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id)) ;
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(Messages.NotUpdated);
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }


        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarNameIsAlreadyExist);
            }
            return new SuccessResult();

        }


    }


}
