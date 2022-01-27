using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailsDto> CarDetails();
        public List<CarDto> GetAllCarDto(Expression<Func<CarDto, bool>> filter=null);


    }
}
