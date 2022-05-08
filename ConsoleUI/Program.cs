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
            //ColorTest();
            //BrandTest();

            //CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Base Status");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
            Car car7 = new Car() { Id = 7, BrandId = 2, ColorId = 3, CarName = "car7", Description = "Family car", ModelYear = 2020, DailyPrice = 1500 };
            Car car8 = new Car() { Id = 8, BrandId = 2, ColorId = 3, CarName = "car8", Description = "Race Car", ModelYear = 2020, DailyPrice = 2500 };

            Console.WriteLine("After Adding");
            //carManager.Add(car7);
            //carManager.Add(car8);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
            Console.WriteLine("After Deleting");
            //carManager.Delete(car7);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
            Console.WriteLine("After Updating");
            //carManager.Update(new Car() { Id = 8, BrandId = 2, ColorId = 3, CarName = "car8edited", Description = "Trip Car", ModelYear = 2020, DailyPrice = 2500 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " / " + car.CarName);
            }
            Console.WriteLine("GetCarsByBrandId");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("GetCarsByColorId");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.CarName);
            }

            Console.WriteLine("GetCarDetails");

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " / " + car.BrandName, " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Base Status");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
            Brand brand4 = new Brand() { BrandId = 4, BrandName = "Fiat" };
            Brand brand5 = new Brand() { BrandId = 5, BrandName = "Citroen" };
            Console.WriteLine("After Adding");
            brandManager.Add(brand4);
            brandManager.Add(brand5);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
            Console.WriteLine("After Deleting");
            brandManager.Delete(brand4);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
            Console.WriteLine("After Updating");
            brandManager.Update(new Brand() { BrandId = 5, BrandName = "Peugeout" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + " / " + brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Base status");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("After Adding");
            Color color4 = new Color() { ColorId = 4, ColorName = "acikmavi" };
            Color color5 = new Color() { ColorId = 5, ColorName = "acikyesil" };
            colorManager.Add(color4);
            colorManager.Add(color5);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + color.ColorName);
            }
            Console.WriteLine("After Deleting");
            colorManager.Delete(color4);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + color.ColorName);
            }
            Console.WriteLine("After Updating");
            colorManager.Update(new Color() { ColorId = 5, ColorName = "aciksari" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId + color.ColorName);
            }
        }

    }
}
