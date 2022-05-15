using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if(user.FirstName.Length <2)
            {
                return new ErrorResult();
            }
            _userDal.Add(user);
            return new SuccessResult();

        }

        public IResult Delete(User user)
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }
            _userDal.Delete(user);
            return new SuccessResult();

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());

        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.Id == id));
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult();
            }
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}
