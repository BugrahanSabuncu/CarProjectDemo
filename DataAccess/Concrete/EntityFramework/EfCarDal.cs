using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> CarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             select new CarDetailsDto()
                             {
                                 CarId = c.Id,
                                 ColorName = cl.ColorName,
                                 BrandName = br.BrandName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
        public List<CarDto> GetAllCarDto(Expression<Func<CarDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             select new CarDto()
                             {
                                 CarId = c.Id,
                                 ColorId=c.ColorId,
                                 ColorName = cl.ColorName,
                                 BrandId=c.BrandId,
                                 BrandName = br.BrandName,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
