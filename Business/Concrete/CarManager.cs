using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(p=>p.BrandId==brandId);

        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(p=>p.ColorId==colorId);

        }

        public List<CarDetailDTO> GetCarDetailDTOs()
        {
            return _carDal.GetCarDetailDTOs();
        }
    }
}
