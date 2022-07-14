
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
            GetCarDetailDto();
           
       
            //Car car1 = new Car { BrandId = 7, ColorId = 3, CarName = "Ferrari", DailyPrice = 1200, Description = "coupe" };
            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.add(car1);
        

        }


        public static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(3);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                Console.WriteLine(car.CarName +" "+ car.Description);
                }
            }
            
        }
        public static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result1 = carManager.GetCarsByColorId(1);
            if(result1.Success == true)
            {
                foreach (var car in result1.Data )
                {
                    Console.WriteLine(car.CarName + " " + car.Description);
                }
            }
           
        }
        
        public static void GetCarDetailDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success==true)
            {
                foreach(var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName);
                }
            }

        }

    }
}