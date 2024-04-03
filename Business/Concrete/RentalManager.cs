using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            bool isRentalAvailabilityCheck = RentalAvailabilityCheck(rental.CarId);
            if (isRentalAvailabilityCheck)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
            return new ErrorResult(Messages.CarIsAlreadyRented);
        }

        public IResult Delete(Rental rental)
        {
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.Id==id));
        }

        public bool RentalAvailabilityCheck(int carId)
        {
            var rentals= _rentalDal.GetAll();
            bool isCarRented = rentals.Any(r => r.CarId == carId);            
            if (isCarRented)
            {
                bool isADateEmpty = rentals.Any(r => r.CarId == carId && r.RentDate == null);
                if (isADateEmpty==false)
                {
                    return false;
                }
            }
            return true;
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult();

        }
    }
}
