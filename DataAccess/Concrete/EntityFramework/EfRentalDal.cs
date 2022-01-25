using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailsDto> rentalDetails()
        {
            using (CarContext context=new CarContext())
            {
                //var priceDetail = from r in context.Rentals
                //                 join c in context.Cars
                //                 on r.UserId equals c.Id
                //                 select new { dayCount = r.ReturnDate - r.RentalDate, price = c.DailyPrice };
                
                var result = from r in context.Rentals
                             join u in context.Users on r.UserId equals u.Id
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 RentalDate = r.RentalDate,
                                 ReturnDate = r.ReturnDate,
                             };
                return result.ToList();
                             
            }
            
        }
    }
}
