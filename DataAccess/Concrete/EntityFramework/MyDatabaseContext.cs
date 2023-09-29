using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyDatabaseContext:DbContext
    {
        public MyDatabaseContext()
        {
        }
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options):base(options)
        {
        }

        public DbSet<Car> Cars{ get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Findeks> Findeks { get; set; }
        public DbSet<CarFindeks> CarFindeks { get; set; }
        public DbSet<CarDetailImage> CarDetailImages { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }

    }
}
