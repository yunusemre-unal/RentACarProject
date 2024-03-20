using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryProductDal()
        {
            _cars = new List<Car> 
            {
                new Car {CarId=1,BrandId=1,ColorId=1,ModelYear=2023,DailyPrice=200000,Description="Opel Araç"},
                new Car {CarId=2,BrandId=2,ColorId=1,ModelYear=2023,DailyPrice=150000,Description="Fiat Araç"},
                new Car {CarId=3,BrandId=3,ColorId=3,ModelYear=2022,DailyPrice=400000,Description="BMW Araç"},
                new Car {CarId=4,BrandId=3,ColorId=6,ModelYear=2021,DailyPrice=450000,Description="BMW Araç"},
                new Car {CarId=5,BrandId=4,ColorId=7,ModelYear=2024,DailyPrice=500000,Description="Mercedes Araç"}
            };    
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            _cars.Remove(deletedCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(x=>x.CarId==id);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(x => x.CarId == car.CarId);
            updateCar.BrandId = 2;
            updateCar.ColorId=3;

        }
    }
}
