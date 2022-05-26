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
            //Console.WriteLine("************ColorTest*************");
            //ColorTest();
            //Console.WriteLine("*************BrandTest*************");
            //BrandTest();
            //Console.WriteLine("*************CarTest***************");
            //CarTest();
            //Console.WriteLine("*************RentalTest************");

            RentalTest();



        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental() { CarId = 33, CustomerId = 33, RentDate = new DateTime(2022, 05, 10)};

            var result = rentalManager.Add(rental1);
            Console.WriteLine(result.Message);
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
            var result2 = carManager.GetAll();
            if (result2.Success == true)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }
            Console.WriteLine("After Deleting");
            carManager.Delete(car7);
            var result3 = carManager.GetAll();
            if (result3.Success == true)
            {
                foreach (var car in result3.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }else
            {
                Console.WriteLine(result3.Message);
            }


            Console.WriteLine("After Updating");
            carManager.Update(new Car() { Id = 8, BrandId = 2, ColorId = 3, CarName = "car8edited", Description = "Trip Car", ModelYear = 2020, DailyPrice = 2500 });
            var result4 = carManager.GetAll();
            if (result4.Success == true)
            {
                foreach (var car in result4.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result4.Message);
            }


            Console.WriteLine("GetCarsByBrandId");
            var result5 = carManager.GetCarsByBrandId(2);

            if(result5.Success == true)
            {
                foreach (var car in result5.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result5.Message);
            }

            Console.WriteLine("GetCarsByColorId");

            var result6 = carManager.GetCarsByColorId(2);

            if (result6.Success == true)
            {
                foreach (var car in result6.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result6.Message);
            }

            Console.WriteLine("GetCarDetails");

            var result7 = carManager.GetCarDetails();

            if (result7.Success == true)
            {
                foreach (var car in result7.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result7.Message);
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

            var result2 = brandManager.GetAll();
            if (result2.Success == true)
            {
                foreach (var brand in result2.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }
            Console.WriteLine("After Deleting");
            brandManager.Delete(brand4);
            var result3 = brandManager.GetAll();
            if (result3.Success == true)
            {
                foreach (var brand in result3.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            Console.WriteLine("After Updating");
            brandManager.Update(new Brand() { BrandId = 5, BrandName = "Peugeout" });
            var result4 = brandManager.GetAll();
            if (result4.Success == true)
            {
                foreach (var brand in result4.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result4.Message);
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
            var result2 = colorManager.GetAll();
            if (result2.Success == true)
            {
                foreach (var color in result2.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

            Console.WriteLine("After Deleting");
            colorManager.Delete(color4);
            var result3 = colorManager.GetAll();
            if (result3.Success == true)
            {
                foreach (var color in result3.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            Console.WriteLine("After Updating");
            colorManager.Update(new Color() { ColorId = 5, ColorName = "aciksari" });
            var result4 = colorManager.GetAll();
            if (result4.Success == true)
            {
                foreach (var color in result4.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result4.Message);
            }
        }

    }
}
