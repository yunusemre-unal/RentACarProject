using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {

            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }
        public IResult Add(IFormFile formFile , CarImage carImage)
        {
            var result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(formFile,PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.CarImagesPath+carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
           var result = BusinessRules.Run(CheckImageExist(id));
            if (result!=null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultCarImage(id).Data);
            }
            var resultImage = _carImageDal.GetAll(p => p.CarId == id);
            return new SuccessDataResult<List<CarImage>>(resultImage);
        }

        public IResult Update(IFormFile formFile , CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.CarImagesPath + carImage.ImagePath,
                PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            return new SuccessResult();
        }


        private IResult CheckImageExist(int carId) 
        {
            var result = _carImageDal.GetAll(p=>p.CarId==carId).Count;
            if (result<=0)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            return new SuccessResult();

        }

        private IDataResult<List<CarImage>> GetDefaultCarImage(int id) 
        {
            return  new SuccessDataResult<List<CarImage>>(new List<CarImage>() { new CarImage { CarId = id, Date = DateTime.Now, ImagePath = "default.jpg" } });             
                
        }
    }
}
