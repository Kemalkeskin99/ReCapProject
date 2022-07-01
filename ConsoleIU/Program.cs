
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using Entities.concrete;

namespace ConsoleIU
{
    public class Program
    {
        static void Main(string[] args)
        {
            //GetCarsByBrandId();
            //GetCarsByColorId();
           
       
            Car car1 = new Car { BrandId = 7, ColorId = 3, CarName = "Ferrai", DailyPrice = 1200, Description = "coupe" };
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.add(car1);
        

        }


        public static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CarName);
            }
        }
        public static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }
        


    }
}