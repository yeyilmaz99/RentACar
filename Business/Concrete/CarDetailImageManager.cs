using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarDetailImageManager : ICarDetailImageService
    {
        ICarDetailImageDal _carDetailImageDal;

        public CarDetailImageManager(ICarDetailImageDal carImageDetailDal)
        {
            _carDetailImageDal = carImageDetailDal;
        }

        public IResult Add(CarDetailImage[] carDetailImages)
        {

            IResult result = BusinessRules.Run(CheckIfCarImagesFull(carDetailImages[0].CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.NumberOfImagesExceeded);
            }
            foreach (var image in carDetailImages)
            {
                CarDetailImage carImage = new CarDetailImage();
                carImage.CarId = image.CarId;

                carImage.ImageData = image.ImageData;

                carImage.ImageName = Guid.NewGuid().ToString();
                carImage.Date = DateTime.Now;
                carImage.ImagePath = carImage.ImageName + ".png";

                _carDetailImageDal.Add(carImage);
            }
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(List<byte[]> carImages)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailImage>> GetAllImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesNull(carId));
            if (result != null)
            {
               
            }

            return new SuccessDataResult<List<CarDetailImage>>(_carDetailImageDal.GetAll(c => c.CarId == carId));

        }

        public IResult Update(List<byte[]> carImages)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCarImagesFull(int carId)
        {
            var result = _carDetailImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 4)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImagesNull(int carId)
        {
            var result = _carDetailImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}

