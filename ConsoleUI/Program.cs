using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            Console.WriteLine("Get All Methodu");
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("Get All By BrandId Methodu");
            foreach (var c in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("Get By Id Methodu");
            Console.WriteLine(carManager.GetById(1).Description);

            Console.WriteLine("OR");
            Car car3 = carManager.GetById(1);

            Console.WriteLine(car3.Description);


            Console.WriteLine("Add Methodu Sonrası GetAll");
            Car car1 = new Car() {Id=6,BrandId=2,ColorId=3,DailyPrice=650,ModelYear=1999,Description="Aile Arabası" };
            carManager.Add(car1);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }


            Console.WriteLine("Delete Methodu Sonrası GetAll");
            carManager.Delete(car1);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }

            Console.WriteLine("Update Methodu sonrası GetAll");
            Car car2 = new Car() { Id = 1, BrandId = 2, ColorId = 3,ModelYear=2022,DailyPrice=1800,Description="Yeni Elektrikli" };
            carManager.Update(car2);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.Description);
            }




        }
    }
}
