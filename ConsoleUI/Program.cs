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

            var result = carManager.GetAll();

            if(result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Car car7 = new Car() { Id = 7, BrandId = 2, ColorId = 3, CarName = "car7", Description = "Family car", ModelYear = 2020, DailyPrice = 1500 };
            Car car8 = new Car() { Id = 8, BrandId = 2, ColorId = 3, CarName = "car8", Description = "Race Car", ModelYear = 2020, DailyPrice = 2500 };

            Console.WriteLine("After Adding");
            carManager.Add(car7);
            carManager.Add(car8);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("After Deleting");
            //carManager.Delete(car7);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("After Updating");
            carManager.Update(new Car() { Id = 8, BrandId = 2, ColorId = 3, CarName = "car8edited", Description = "Trip Car", ModelYear = 2020, DailyPrice = 2500 });
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            Console.WriteLine("GetCarsByBrandId");
            var result2 = carManager.GetCarsByBrandId(2);

            if(result2.Success == true)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("GetCarsByColorId");

            var result3 = carManager.GetCarsByColorId(2);

            if (result3.Success == true)
            {
                foreach (var car in result3.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("GetCarDetails");

            var result4 = carManager.GetCarDetails();

            if (result4.Success == true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Base Status");
            var result = brandManager.GetAll();

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Brand brand4 = new Brand() { BrandId = 4, BrandName = "Fiat" };
            Brand brand5 = new Brand() { BrandId = 5, BrandName = "Citroen" };
            Console.WriteLine("After Adding");
            brandManager.Add(brand4);
            brandManager.Add(brand5);

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("After Deleting");
            brandManager.Delete(brand4);

            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("After Updating");
            brandManager.Update(new Brand() { BrandId = 5, BrandName = "Peugeout" });
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Base status");

            var result = colorManager.GetAll();

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("After Adding");
            Color color4 = new Color() { ColorId = 4, ColorName = "acikmavi" };
            Color color5 = new Color() { ColorId = 5, ColorName = "acikyesil" };
            colorManager.Add(color4);
            colorManager.Add(color5);

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("After Deleting");
            colorManager.Delete(color4);

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("After Updating");
            colorManager.Update(new Color() { ColorId = 5, ColorName = "aciksari" });

            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

    }
}
