using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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
                return new ErrorResult(ColorMessages.NameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(ColorMessages.MaintenanceTime);
            }

            _colorDal.Delete(color);
            return new SuccessResult(ColorMessages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IResult Update(Color color)
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorResult(ColorMessages.MaintenanceTime);
            }

            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }
    }
}
