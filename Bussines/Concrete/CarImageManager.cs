using Bussines.Abstract;
using Bussines.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
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
        [PerformanceAspect(5)]
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
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll());
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_CarImageDal.GetAll(c => c.CarId == carId));
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_CarImageDal.Get(i => i.Id == imageId));
        }
        [TransactionScopeAspect]//burada önce silne sonra tekrar yükleme yaptığı için kullanıma uygun.
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            _CarImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
