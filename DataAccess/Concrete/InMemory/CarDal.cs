using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccessLayer.InMemoryDal
{
    public class CarDal : ICarDal
    {
        private List<Car> _cars;

        public CarDal()
        {
            _cars=new List<Car>
            {
                new Car(){Id = 1,BrandId = 1,ColorId = 2,DailyPrice = 158000,Description = "Sıfır",ModelYear = 2021},
                new Car(){Id = 2,BrandId = 2,ColorId = 7,DailyPrice = 157000,Description = "Sıfır",ModelYear = 2020},
                new Car(){Id = 3,BrandId = 5,ColorId = 6,DailyPrice = 156000,Description = "Sıfır",ModelYear = 2020},
                new Car(){Id = 4,BrandId = 3,ColorId = 9,DailyPrice = 153000,Description = "Sıfır",ModelYear = 2021}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailsDto> CarDetails()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDto> GetAllCarDto(Expression<Func<CarDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
