using Business.Abstract;
using Core.Utilities.Results;
using Entities.concrete;
using DataAccess.Abstract;
using Business.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Message.ErrorUserAdd);
            }
            _userDal.Add(user);
            return new SuccessResult(Message.UserAdd);
        }

        public IResult Delete(User user)
        {
            if (user.UserId == null)
            {
                return new ErrorResult(Message.ErrorUserDelete);
            }
            _userDal.Delete(user);
            return new SuccessResult(Message.UserDelete);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 23.59)
            {
                return new ErrorDataResult<List<User>>(Message.ErrorUserGetAll);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Message.UserGetAll);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            if (id == 0)
            {
                return new ErrorDataResult<User>(Message.ErrorGetByUserId);
            }
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == id), Message.GetByUserId);
        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
            return new SuccessResult(Message.UserUpdate);

        }
    }
}
