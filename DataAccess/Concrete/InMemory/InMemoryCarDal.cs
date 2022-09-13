using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id=1, BrandId = 1, ColorId = 1, ModelYear= 2000, DailyPrice= 5000, Description = "" },
                new Car{ Id=2, BrandId = 2, ColorId = 4, ModelYear= 2010, DailyPrice= 9000, Description = "" },
                new Car{ Id=3, BrandId = 3, ColorId = 5, ModelYear= 2020, DailyPrice= 20000, Description = "" },
                new Car{ Id=4, BrandId = 3, ColorId = 1, ModelYear= 2022, DailyPrice= 25000, Description = "" },
                new Car{ Id=5, BrandId = 1, ColorId = 3, ModelYear= 2002, DailyPrice= 5500, Description = "" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(x => x.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
