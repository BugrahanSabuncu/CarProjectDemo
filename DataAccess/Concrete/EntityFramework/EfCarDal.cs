using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
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
            using (CarContext context=new CarContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailsDto()
                             {
                                 CarId = c.Id,
                                 Description = c.Description,
                                 ColorName = cl.ColorName
                             };
                return result.ToList();
            }
        }

    }
}
