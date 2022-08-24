using Business.Abstract;
using Business.Contants;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Message.ErrorColorAdd);
            }
            _colorDal.Add(color);
            return new SuccessResult(Message.ColorAdd);
        }

        public IResult Delete(Color color)
        {
         
            _colorDal.Delete(color);
            return new SuccessResult(Message.ColorDelete);
        }

        public IDataResult<List<Color>> GetAll()
        {
            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Message.ColorGetAll);
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == id), Message.GetByColorId);
        }

        public IResult Update(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Message.ColorUpdate);
        }
    }
}
