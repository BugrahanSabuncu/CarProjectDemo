using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDto>> GetAllCarDto();        
        IDataResult<List<CarDto>> GetFilters(int brandId = 0, int colorId = 0);
        IDataResult<List<CarDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDto>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        
    }
}
