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
        }
    }
}
