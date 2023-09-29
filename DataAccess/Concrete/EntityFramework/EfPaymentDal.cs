using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, MyDatabaseContext>, IPaymentDal
    {
        public EfPaymentDal(DbContextOptions<MyDatabaseContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
