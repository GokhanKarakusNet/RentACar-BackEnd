using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            // ColorTest();
            //UserTest();
            //RentalTest();

            //CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(customerManager.Add(new Customer {CompanyName = "haydar"}).Message);
        }

        //private static void RentalTest()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    var addedRental = rentalManager.Add(new Rental
        //        {CarId = 4, CustomerId = 2, RentDate = DateTime.Now});
        //    Console.WriteLine(addedRental.Message);
        //}

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //var userAdded = userManager.Add(new User
            //    {FirstName = "Gökhan", LastName = "Karakuş", Email = "a@b", Password = "12345"});
            //Console.WriteLine(userAdded.Message);
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var colorAdded= colorManager.Add(new Color { ColorName = "Mavi" });
            Console.WriteLine(colorAdded.Message);
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
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brandResult =brandManager.Add(new Brand { BrandName = "Leon" });
            Console.WriteLine(brandResult.Message);
            var result = brandManager.GetAll();
            if (result.Success==true)
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

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    var addedResult= carManager.Add(new Car {CarName = "deneme",BrandId = 1,ColorId = 2});
        //    //var updatedResult = carManager.Update(new Car{ CarName = "Seat", DailyPrice = 600, Description = "Seat", ModelYear = 2020,CarId = 4,BrandId = 1002,ColorId = 1});
        //    //var deletedResult = carManager.Delete(5);
        //    Console.WriteLine(addedResult.Message);
        //    var result = carManager.GetCarsDetails();
        //    if (result.Success == true)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine("CarName : {0}, BrandName : {1}, ColorName : {2}, DailyPrice : {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}
    }
}
