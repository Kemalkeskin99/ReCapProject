using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Entities.concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {

            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Message.ErrorCustomerAdd);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Message.CustomerAdd);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId == null)
            {
                return new ErrorResult(Message.ErrorCustomerDelete);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDelete);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 23.59)
            {
                return new ErrorDataResult<List<Customer>>(Message.ErrorCustomerGetAll);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Message.CustomerGetAll);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            if (id == 0)
            {
                return new ErrorDataResult<Customer>(Message.ErrorGetByCustomerId);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id), Message.GetByCustomerId);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerUpdate);
        }
    }
}
