using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MyDatabaseContext>, IUserDal
    {
        public EfUserDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new MyDatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (var context = new MyDatabaseContext())
            {
                var result = from u in context.Users
                             join f in context.Findeks
                             on u.Id equals f.UserId
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Status = u.Status,
                                 FindeksPoint = f.FindeksPoint
                                 
                             };
                return result.ToList();
            }
        }
    }
}
