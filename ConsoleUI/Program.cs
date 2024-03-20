// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryProductDal());

Car car=carManager.GetById(1);
Console.WriteLine(car.Description);

Console.WriteLine("/////////////////////////////////////////");

Car car1 = new Car();
car1.CarId = 6;
car1.BrandId = 8;
car1.ColorId = 4;
car1.Description = "Renault ss Araç";
car1.ModelYear = 2022;
car1.DailyPrice = 5000;
carManager.Add(car1);   


foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("/////////////////////////////////////////");


Car car2 = new Car();
car2 = carManager.GetById(6);

carManager.Delete(car2);

foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}