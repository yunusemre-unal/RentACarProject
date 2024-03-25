// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());



RentalManager rentalManager = new RentalManager(new EfRentalDal());
Rental rental=new Rental();
rental.CarId = 1;
rental.CustomerId = 1;
rental.RentDate=DateTime.Now;
var result= rentalManager.Add(rental);
Console.WriteLine(result.Message);

