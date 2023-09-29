using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFindeksDal : EfEntityRepositoryBase<Findeks, MyDatabaseContext>, IFindeksDal
    {
        public EfFindeksDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}

