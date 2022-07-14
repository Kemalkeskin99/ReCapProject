using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
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

        public IResult add(Car car)
        {
            if (car.CarName.Length<2 && car.DailyPrice <= 0 )
            {
                
                return new ErrorResult(Message.CarAddInValid);

            }
            _carDal.Add(car);
            return new SuccessResult(Message.CarAdded);

        }

       

        public IDataResult<List<Car>> GetAll()
        {
             if (DateTime.Now.Hour == 00)
             {
               return new ErrorDataResult<List<Car>>(Message.listedCarInValid);
             }
            _carDal.GetAll();
             return new SuccessDataResult<List<Car>>(Message.listedCar);
          
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int id)
        { 
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        

        //public List<CarDetailDto> GetCarDetails()
        //{
        //    return _carDal.GetCarDetails();

        //}
    }
}
