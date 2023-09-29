using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, MyDatabaseContext>, ICarImageDal
    {
        public EfCarImageDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public List<CarImage> GetDefaultImage()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                return context.Set<CarImage>().ToList();
            }
        }
    }
}
