using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<User> GetByMail(string email);
    }
}
