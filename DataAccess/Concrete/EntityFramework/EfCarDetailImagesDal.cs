using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDetailImagesDal : EfEntityRepositoryBase<CarDetailImage, MyDatabaseContext>, ICarDetailImageDal
    {
	}
}

