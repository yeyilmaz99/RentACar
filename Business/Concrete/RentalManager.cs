using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }



        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarOfRentalIsReturned(rental.CarId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult CheckIfCarOfRentalIsReturned(int id)
        {
            var result = _rentalDal.GetAll(c => c.CarId == id).FindLast(c => c.CarId == id);

            if (result == null)
            {
                return new SuccessResult();
            }
            if (result.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarIsAlreadyTaken);
            }
            return new SuccessResult();
        }


    }
}
