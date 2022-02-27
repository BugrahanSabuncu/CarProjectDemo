using Bussines.Abstract;
using Bussines.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IDataResult<List<RentalDetailsDto>> RentalDetails()
        {            
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.rentalDetails(),Messages.RentalDetailListed);
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new  SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId).OrderByDescending(c => c.ReturnDate).First();
            return new SuccessDataResult<Rental>(result , Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
