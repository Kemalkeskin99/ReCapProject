using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void add(Car car)
        {
            if (car.CarName.Length>=2 && car.DailyPrice >= 0 )
            {
                _carDal.Add(car);
                Console.WriteLine("Araba sisteme eklenmiştir..."+car.CarName);

            }
            else {
                Console.WriteLine("Araba eklenemez....");
            }
        }

     

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

       

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    return _carDal.GetCarDetails();

        //}
    }
}
