using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //InvalidDataNameTest();
            //AddUserTest();
            //AddCustomerTest();
            //AddSuccessRentalTest();

            //FailedAddRentalTest();

        }

        private static void FailedAddRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var failRentalTest = rentalManager.Add(new Rental { Id = 3, CarId = 1, CustomerId = 1, RentDate = DateTime.Today, ReturnDate = DateTime.Now });

            Console.WriteLine(failRentalTest.Message.ToString());
        }

        private static void AddSuccessRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var addRentalTest = rentalManager.Add(new Rental { Id = 2, CarId = 1, CustomerId = 1, RentDate = DateTime.Today, ReturnDate = null });

            Console.WriteLine(addRentalTest.Message);
        }

        private static void AddUserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Id = 1, FirstName = "David", LastName = "Johnson", Email = "d.johnson@mail.com", Password = "123" });
            userManager.Add(new User { Id = 2, FirstName = "Mark", LastName = "Braen", Email = "m.braen@mail.com", Password = "zdqf**2" });
            userManager.Add(new User { Id = 3, FirstName = "Zoey", LastName = "Len", Email = "z.len@mail.com", Password = "a123ad" });

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1} - {2}", user.FirstName, user.LastName, user.Email);
            }
        }

        private static void AddCustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { Id = 1, UserId = 1, CompanyName = "Company.AG" });
            customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "Another.AG" });
            customerManager.Add(new Customer { Id = 3, UserId = 2, CompanyName = "Another.AG" });
            customerManager.Add(new Customer { Id = 4, UserId = 3, CompanyName = "Something.AG" });

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} -- {2}", customer.CompanyName, customer.Id);
            }
        }

        private static void InvalidDataNameTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var newCar = carManager.Add(new Car { Description = " ", ColorId = 1, BrandId = 1, DailyPrice = 1000 });

            Console.WriteLine(newCar.Message);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }
    }
}


