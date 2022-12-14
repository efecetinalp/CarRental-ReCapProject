using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join m in context.Models
                             on c.ModelId equals m.ModelId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName,
                                 CarId = c.Id,
                                 Description = c.Description,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice,
                             };

                return result.ToList();
            }
        }
    }
}
