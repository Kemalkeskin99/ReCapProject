using Business.Abstract;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

            }
            else {
                Console.WriteLine("Araba eklenemez....");
            }
        }
    }
}
