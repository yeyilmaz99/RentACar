//using DataAccess.Abstract;
//using Entities.Concrete;
//using Entities.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {

//        List<Car> _cars;

//        public InMemoryCarDal()
//        {
//            _cars = new List<Car>()
//            {
//                new Car(){Id= 1,BrandId=1,ColorId=1, ModelYear=2020, DailyPrice=500,Description="Elekrikli"},
//                new Car(){Id= 2,BrandId=1,ColorId=2, ModelYear=2015, DailyPrice=570,Description="Hibrit"},
//                new Car(){Id= 3,BrandId=1,ColorId=1, ModelYear=2018, DailyPrice=580,Description="Yolcu"},
//                new Car(){Id= 4,BrandId=2,ColorId=2, ModelYear=2005, DailyPrice=1200,Description="Aile"},
//                new Car(){Id= 5,BrandId=2,ColorId=3, ModelYear=2010, DailyPrice=1500,Description="Yarış"},

//            };
//        }


//        public void Add(Car car)
//        {
//            _cars.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
//            _cars.Remove(carToDelete);
//        }

//        public Car Get(Expression<Func<Car, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> GetAll()
//        {
//            return _cars;
//        }

//        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> GetAllByBrandId(int id)
//        {
//            return _cars.Where(c => c.BrandId == id).ToList();
//        }

//        public Car GetById(int id)
//        {
//            Car car = _cars.SingleOrDefault(c => c.Id == id);
//            return car;
//        }

//        public List<CarDetailDto> GetCarDetails()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Car car)
//        {
//            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
//            carToUpdate.Id = car.Id;
//            carToUpdate.BrandId = car.BrandId;
//            carToUpdate.ColorId = car.ColorId;
//            carToUpdate.DailyPrice = car.DailyPrice;
//            carToUpdate.Description = car.Description;
//        }
//    }
//}
