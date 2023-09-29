using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarFindeksDal : EfEntityRepositoryBase<CarFindeks, MyDatabaseContext>, ICarFindeksDal
    {
        public EfCarFindeksDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}

