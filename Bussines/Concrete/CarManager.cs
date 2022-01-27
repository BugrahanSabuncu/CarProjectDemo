using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstact;
using Bussines.BussinesAspect.Autofac;
using Bussines.Constants.Messages;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Aspects.Autofac.Performance;
using Core.Bussines;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [PerformanceAspect(5)]
        public IResult Add(Car car)
        {
            var result=BussinesRules.Run(CheckColorCountControl(car.ColorId),
                CheckIfBrandGreaterThanLimit(car.BrandId,car.DailyPrice));
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedMessage);
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteMessage);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedMessage);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {           
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateFailedMessage);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailsDto>> CarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.CarDetails(), "Detay Listeleme başarılı");
        }

        private IResult CheckColorCountControl(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result<10)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bu renkte 10 adetten fazla ürün olamaz.");
        }
        private IResult CheckIfBrandGreaterThanLimit(int brandId,Decimal dailyPrice)
        {
            if (brandId==2)
            {
                if (dailyPrice > 400)
                {
                    return new SuccessResult();
                }                
            }
            return new ErrorResult("Bu marka için kiralama bedeli 400 tlden az olamaz ");

        }

        public IDataResult<List<CarDto>> GetByBrandId(int brandId)
        {
            var result = _carDal.GetAllCarDto().Where(c => c.BrandId == brandId).ToList();
            return new SuccessDataResult<List<CarDto>>(result, Messages.ListedByBrand);
        }

        public IDataResult<List<CarDto>> GetByColorId(int colorId)
        {
            var result = _carDal.GetAllCarDto().Where(c => c.ColorId == colorId).ToList();
            return new SuccessDataResult<List<CarDto>>(result, Messages.ListedByColor);
        }

        public IDataResult<List<CarDto>> GetAllCarDto()
        {
            return new SuccessDataResult<List<CarDto>>(_carDal.GetAllCarDto(),Messages.CarDtoListed);
        }
    }
}
