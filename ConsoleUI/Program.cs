// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());




foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("/////////////////////////////////////////");

foreach (var item in carManager.GetAllByBrandId(2))
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("/////////////////////////////////////////");

foreach (var item in carManager.GetAllByColorId(1))
{
    Console.WriteLine(item.Description);
}

Console.WriteLine("/////////////////////////////////////////");

