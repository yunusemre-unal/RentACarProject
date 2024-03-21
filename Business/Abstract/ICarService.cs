using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();    
        List<Car> GetAllByColorId(int colorId);    
        List<Car> GetAllByBrandId(int brandId);
        List<CarDetailDTO> GetCarDetailDTOs();
    }
}
