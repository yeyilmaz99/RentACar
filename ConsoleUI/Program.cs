using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach(var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("***********************");
            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine(car.CarName);
            }

            Car car7 = new Car() {Id= 7,BrandId=2,ColorId=1,CarName="Araba7",DailyPrice=5500,ModelYear=2021,Description="Offroad arabası" };

            carManager.Add(car7);


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }


        }
    }
}
