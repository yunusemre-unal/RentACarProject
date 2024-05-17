using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==15)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), Messages.CarListed);

        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId), Messages.CarListed);

        }

        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == id));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailDTOs()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<CarDetailDTO>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetailDTOs());
        }

        public IResult Update(Car car)
        {
            return new SuccessResult();
        }
    }
}
