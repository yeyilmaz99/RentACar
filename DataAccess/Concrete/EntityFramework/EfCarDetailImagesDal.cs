using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDetailImagesDal : EfEntityRepositoryBase<CarDetailImage, MyDatabaseContext>, ICarDetailImageDal
    {
        public EfCarDetailImagesDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}

