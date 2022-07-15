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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate==null)
            {
                return new ErrorResult(Message.ErrorRentalAdd);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Message.RentalAdd);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId==null)
            {
                return new ErrorResult(Message.ErrorRentalDelete);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.ErrorRentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==00.00)
            {
                return new ErrorDataResult<List<Rental>>(Message.ErrorRentalGetAll);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Message.RentalGetAll);
        }

        public IDataResult<Rental> GetByRentalId(int id)
        {
            if (id<=0)
            {
                return new ErrorDataResult<Rental>(Message.ErrorGetByRentalId);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(P=>P.RentalId==id),Message.GetByRentalId);
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentDate == null)
            {
                return new ErrorResult(Message.ErrorRentalUpdate);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Message.RentalUpdate);
        }
    }
}
