using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Message.ErrorBrandAdd);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Message.BrandAdd);
        }

        public IResult Delete(Brand brand)
        {
          
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandDelete);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Message.BrandGetAll);
        }

        public IDataResult<Brand> GetByBrandId(int id)
        {
            
            return new SuccessDataResult <Brand>(_brandDal.Get(p=>p.BrandId==id),Message.GetByBrandId);
        }

        public IResult Update(Brand brand)
        {
            
            _brandDal.Delete(brand);
            return new SuccessResult(Message.BrandUpdate);
        }
    }
}
