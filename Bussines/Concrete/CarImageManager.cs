using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Helpers.FileHelperManager;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _CarImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _CarImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstans.ImagesPath);
            carImage.Date = DateTime.Now;
            _CarImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _CarImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_CarImageDal.Get(i => i.Id == imageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            _CarImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
