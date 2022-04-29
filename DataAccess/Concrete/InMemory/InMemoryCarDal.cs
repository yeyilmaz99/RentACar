using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarManager : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarManager()
        {
            _cars = new List<Car>()
            {
                new Car(){Id= 1,BrandId=1,ColorId=1, DailyPrice=500,Description="Elekrikli"},
                new Car(){Id= 2,BrandId=1,ColorId=2, DailyPrice=570,Description="Hibrit"},
                new Car(){Id= 3,BrandId=1,ColorId=1, DailyPrice=580,Description="Yolcu"},
                new Car(){Id= 4,BrandId=2,ColorId=2, DailyPrice=1200,Description="Aile"},
                new Car(){Id= 5,BrandId=2,ColorId=3, DailyPrice=1500,Description="Yarış"},

            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public Car GetById(int id)
        {
            Car car = _cars.SingleOrDefault(c => c.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
