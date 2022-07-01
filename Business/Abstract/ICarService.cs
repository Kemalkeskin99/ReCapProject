﻿using Entities.concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        void add(Car car);
        // List<CarDetailDto> GetCarDetails();

       // void delete(int id);   
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

       

    }
}
