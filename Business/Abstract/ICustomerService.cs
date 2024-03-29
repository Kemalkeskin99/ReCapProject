﻿using Core.Utilities.Results;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);

        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCustomerId(int id);
    }
}
